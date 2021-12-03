using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Identity;
using HpLayer.Helper;
using Website.Helper.Utils;
using Website.Helper.Vmodel;
using Website.Service.SrcIdentity.Configure;

namespace Website.Pages.User {
    public class UserInfoModel : PageModel {
        private readonly DbSet<AppUser> _users;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private const string voteError = "درخواست رای شما با خطا مواجعه شد.";

        public UserInfoModel (UserManager<AppUser> userManager, AppDbContext context) {
            _context = context;
            _userManager = userManager;
            _users = _context.Set<AppUser> ();
        }

        [BindProperty (SupportsGet = true)]
        public string Id { get; set; }
        public class ListModel : VoteHelperVm {
            public string Id { get; set; }

            public string Avatar { get; set; }

            public string DisplayName { get; set; }

            public bool IsAvailable { get; set; }

            public DateTime DateCreated { get; set; }

            public string PersianDateCreated { get; set; }

            public string Roles { get; set; }

            public string Province { get; set; }

            public string Bio { get; set; }

            public string Email { get; set; }

            public string PhoneNumber { get; set; }

            public string Education { get; set; }

            public byte? UserMark { get; set; } = null;
        }

        public ListModel ViewResult { get; set; }

        public async Task OnGetAsync () {
            string userId = null;
            if (User.Identity.IsAuthenticated) {
                userId = User.Identity.GetUserId<string> ();
            }
            ViewResult = await _users
                .Include (x => x.TblUserVote)
                .Include (x => x.TblProvince).ThenInclude (x => x.Parent)
                .Include (x => x.TblUserCinemaRole).ThenInclude (x => x.TblCinemaRole)
                .Select (x => new ListModel {
                    Id = x.Id,
                        DisplayName = x.DisplayName,
                        IsAvailable = x.IsAvailable,
                        Avatar = x.Avatar.ToFriendlyImage (DefaultImageType.DEF_AVATAR),
                        Roles = x.TblUserCinemaRole.Any () ? String.Join (" , ", x.TblUserCinemaRole.Select (x => x.TblCinemaRole.Title)) : "---",
                        Province = x.ProvinceId.HasValue ? $"{x.TblProvince.Title} , {x.TblProvince.Parent.Title}" : "---",
                        VoteCount = x.TblUserVote.Count (),
                        VoteAverage = x.TblUserVote.Any () ? x.TblUserVote.Average (x => x.Mark) : 0,
                        Bio = x.Bio,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber ?? "---",
                        Education = x.EducationTitle ?? "---",
                        UserMark = x.TblUserVote.Any (x => x.VoterId == userId) ?
                        x.TblUserVote.FirstOrDefault (y => y.VoterId == userId).Mark : null
                }).SingleAsync (x => x.Id == Id);
        }

        public async Task<IActionResult> OnPostSetVoteAsync (byte markValue) {
            try {
                if (markValue < 0 && markValue > 10) {
                    throw new Exception (voteError);
                }
                var userId = User.Identity.GetUserId<string> ();
                var userVote = await _context.TblUserVote
                    .FirstOrDefaultAsync (x => x.UserId == Id && x.VoterId == userId);
                if (userVote != null) {
                    userVote.Mark = markValue;
                    _context.TblUserVote.Update (userVote);
                    await _context.SaveChangesAsync ();
                } else {
                    await _context.TblUserVote.AddAsync (
                        new TblUserVote {
                            UserId = Id,
                                Mark = markValue,
                                VoterId = userId
                        }
                    );
                    await _context.SaveChangesAsync ();
                }
                // 
                var responseVote = new VoteResponseVm ();
                responseVote.MarkValue = markValue;
                responseVote.Vote = await _context.TblUserVote
                    .Where (x => x.UserId == userId)
                    .GroupBy (x => x.UserId)
                    .Select (x => new VoteHelperVm {
                        VoteCount = x.Count (),
                            VoteAverage = x.Average (y => y.Mark),
                    }).FirstOrDefaultAsync ();
                return new OkObjectResult (ApiResult.Succeeded (responseVote));
            } catch (Exception ex) {
                ModelState.AddModelError ("", ex.Message);
                var errors = ModelState.ModelStateErrorAsApiResult ();
                return new BadRequestObjectResult (ApiResult.Failed (errors));
            }
        }
    }
}