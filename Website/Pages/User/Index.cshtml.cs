using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

//
using DbLayer.Context;
using DbLayer.Identity;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Pages.User {
    public class IndexModel : PageModel {
        private const short _pageSize = 12;
        private readonly DbSet<AppUser> _users;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public IndexModel (UserManager<AppUser> userManager, AppDbContext context) {
            _context = context;
            _userManager = userManager;
            _users = _context.Set<AppUser> ();
        }

        public class FilterVm {
            public int p { get; set; } = 1;

            public long? province { get; set; }

            public long? cinemarole { get; set; }

            public long? scinemarole { get; set; }
        }

        public FilterVm filter { get; set; }

        public class ListModel : VoteHelperVm {
            public string Id { get; set; }

            public string Avatar { get; set; }

            public string DisplayName { get; set; }

            public bool IsAvailable { get; set; }

            public DateTime DateCreated { get; set; }

            public string PersianDateCreated { get; set; }

            public string Roles { get; set; }

            public string Province { get; set; }
        }

        public List<SelectListItem> Roles { get; set; }

        public List<SelectListItem> Provinces { get; set; }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync ([FromQuery] FilterVm filter) {
            var users = _users.AsQueryable ();
            if (filter.province != 0) {
                users = users.Where (x => x.ProvinceId == filter.province)
                    .Include (x => x.TblProvince).ThenInclude (x => x.Parent).AsQueryable ();
            } else {
                users = users.Include (x => x.TblProvince)
                    .ThenInclude (x => x.Parent).AsQueryable ();
            }
            if (filter.cinemarole != 0) {
                users = users.Where (x => x.TblUserCinemaRole
                        .Any (y => y.CinemaRoleId == filter.cinemarole))
                    .Include (x => x.TblUserCinemaRole).ThenInclude (x => x.TblCinemaRole).AsQueryable ();
            } else {
                users = users.Include (x => x.TblUserCinemaRole).ThenInclude (x => x.TblCinemaRole).AsQueryable ();
            }
            List = await PaginatedList<ListModel>.CreateAsync (
                users.OrderByDescending (x => x.DateCreated)
                .Select (x => new ListModel {
                    Id = x.Id,
                        DisplayName = x.DisplayName,
                        IsAvailable = x.IsAvailable,
                        DateCreated = x.DateCreated,
                        Avatar = x.Avatar.ToFriendlyImage (DefaultImageType.DEF_AVATAR),
                        Roles = x.TblUserCinemaRole.Any () ?
                        String.Join (" , ", x.TblUserCinemaRole.Select (x => x.TblCinemaRole.Title)) : "---",
                        VoteAverage = x.TblUserVote.Any () ? x.TblUserVote.Average (x => x.Mark) : 0,
                        Province = x.ProvinceId.HasValue ? $"{x.TblProvince.Title} , {x.TblProvince.Parent.Title}" : "---"
                }), filter.p, _pageSize
            );

            // Provinces
            Provinces = await _context.TblProvince
                .Where (x => x.ParentId == null)
                .Select (x => new SelectListItem () {
                    Value = x.Id.ToString (),
                        Text = x.Title
                }).ToListAsync ();
            Provinces.Insert (0, new SelectListItem () {
                Text = "انتخاب کنید",
                    Value = "0"
            });
            // Roles
            Roles = await _context.TblCinemaRole
                .Where (x => x.ParentId == null)
                .Select (x => new SelectListItem () {
                    Value = x.Id.ToString (),
                        Text = x.Title
                }).ToListAsync ();
            Roles.Insert (0, new SelectListItem () {
                Text = "انتخاب کنید",
                    Value = "0"
            });
        }

        public async Task<IActionResult> OnGetCinemaRoleAsSelectAsync (int id) {
            try {
                var result = await _context.TblCinemaRole
                    .Where (x => x.ParentId == id)
                    .Select (x => new SelectListItem () {
                        Value = x.Id.ToString (),
                            Text = x.Title
                    }).ToListAsync ();
                result.Insert (0, new SelectListItem () {
                    Text = "انتخاب کنید",
                        Value = "0"
                });
                return new OkObjectResult (result);
            } catch {
                return BadRequest (ConstValues.ErOnFetchingData);
            }
        }
    }
}