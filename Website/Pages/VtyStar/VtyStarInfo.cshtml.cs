using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities;
using DbLayer.Identity;
using HpLayer.Helper;
using Website.Helper.Utils;
using Website.Helper.Vmodel;
using Website.Service.SrcIdentity.Configure;

namespace Website.Pages.VtyStar {
    public class VtyStarInfoModel : PageModel {
        private readonly AppDbContext _context;

        public VtyStarInfoModel (AppDbContext context) { _context = context; }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public long OptionId { get; set; }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }

            public string Jenre { get; set; }

            public string FriendlyUrl { get; set; }

            public string Question { get; set; }

            public string VideoUrl { get; set; }

            public string KeyWord { get; set; }

            public string ReleaseDate { get; set; }

            public string Source { get; set; }

            public List<OptionsHelperVm> Options { get; set; }

            public List<CommentVm> Comments { get; set; }
        }

        public ListModel List { get; set; }

        public async Task OnGetAsync () {
            string userId = null;
            if (User.Identity.IsAuthenticated) {
                userId = User.Identity.GetUserId<string> ();
            }
            var vtyStarWar = await _context.TblVtyStarsWar
                .AsNoTracking ().FirstOrDefaultAsync (x => x.Id == Id);
            var options = await _context.TblVtyStarsWarOptions
                .Where (x => x.VtyStarsWarId == Id)
                .Include (x => x.TblVtyStarWarUserVote)
                .Select (x => new OptionsHelperVm {
                    OptionId = x.Id,
                        Option = x.Option,
                        VoteCount = x.TblVtyStarWarUserVote.Count (),
                        IsSelected = x.TblVtyStarWarUserVote.Any (x => x.UserId == userId)
                }).AsNoTracking ().ToListAsync ();
            var comments = await _context.TblComment
                .Where (x => x.VtyStarsWarId == Id && x.IsApproved)
                .Include (x => x.AppUser).Select (x => new CommentVm {
                    Id = x.Id,
                        Extract = x.Extract,
                        UserId = x.AppUser.Id,
                        DisplayName = x.AppUser.DisplayName,
                        PersianCreatedDate = x.PersianCreatedDate
                }).OrderBy (x => x.Id).ToListAsync ();

            List = new ListModel {
                Id = vtyStarWar.Id,
                Title = vtyStarWar.Title,
                FriendlyUrl = vtyStarWar.FileUrl.ToFriendlyImage (DefaultImageType.DEF),
                Question = vtyStarWar.Question,
                VideoUrl = vtyStarWar.VideoUrl,
                KeyWord = vtyStarWar.KeyWord,
                ReleaseDate = vtyStarWar.PersianCreatedDate,
                Source = vtyStarWar.Source,
                Options = options,
                Comments = comments
            };
        }

        public async Task<IActionResult> OnPostSetVoteAsync () {
            try {
                var userId = User.Identity.GetUserId<string> ();
                var vtyStarwarOptions = await _context
                    .TblVtyStarsWarOptions.Where (x => x.VtyStarsWarId == Id)
                    .Include (x => x.TblVtyStarWarUserVote.Where (x => x.UserId == userId))
                    .ToListAsync ();

                var usedVote = vtyStarwarOptions.SelectMany (x => x.TblVtyStarWarUserVote).FirstOrDefault ();
                if (usedVote != null) {
                    var exOption = vtyStarwarOptions.FirstOrDefault (x => x.Id == usedVote.VtyStarsWarOptionsId);
                    exOption.TblVtyStarWarUserVote.Remove (usedVote);
                    await _context.SaveChangesAsync ();
                }
                var newOption = vtyStarwarOptions.FirstOrDefault (x => x.Id == OptionId);
                var newVote = new TblVtyStarWarUserVote {
                    UserId = userId,
                    VtyStarsWarOptionsId = OptionId
                };
                newOption.TblVtyStarWarUserVote.Add (newVote);
                await _context.SaveChangesAsync ();
                return new OkObjectResult (ApiResult.Succeeded (OptionId));
            } catch {
                // ModelState.AddModelError ("", ex.Message);
                // var errors = ModelState.ModelStateErrorAsApiResult ();
                return new BadRequestObjectResult (ApiResult.Failed ("", "درخواست شما با خطا مواجه شد."));
            }
        }

        public async Task<IActionResult> OnPostSetCommentAsync (string extract) {
            try {
                if (string.IsNullOrEmpty (extract)) {
                    throw new Exception ("شرح نظر خال می باشد");
                }
                var userId = User.Identity.GetUserId<string> ();
                await _context.TblComment.AddAsync (new TblComment {
                    Extract = extract,
                        VtyStarsWarId = Id,
                        UserId = userId
                });
                return new OkObjectResult (ApiResult.Succeeded ());
            } catch (Exception ex) {
                ModelState.AddModelError ("", ex.Message);
                var errors = ModelState.ModelStateErrorAsApiResult ();
                return new BadRequestObjectResult (ApiResult.Failed (errors));
            }
        }
    }
}