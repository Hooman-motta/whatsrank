using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

//
using DbLayer.Context;
using DbLayer.Entities;
using DbLayer.Identity;
using Website.Helper.Utils;
using Website.Service.SrcIdentity.Configure;

namespace Website.Pages.Account {

    public class CinemaRoleModel : PageModel {
        private readonly DbSet<AppUser> _users;
        public readonly DbSet<TblCinemaRole> _dbSet;

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CinemaRoleModel (UserManager<AppUser> userManager, AppDbContext context) {
            _context = context;
            _userManager = userManager;
            _users = _context.Set<AppUser> ();
            _dbSet = _context.Set<TblCinemaRole> ();
        }

        [TempData]
        public string Message { get; set; }

        public string ReturnUrl { get; set; }

        [BindProperty]
        [Range (0, long.MaxValue, ErrorMessage = "اجباری می باشد")]
        public long CinemaRoleId { get; set; }

        public List<SelectListItem> Roles { get; set; }

        public class ListModel {
            public long Id { get; set; }

            public string Role { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGet (string returnUrl = null) {
            var userId = User.Identity.GetUserId<string> ();
            var cinemaRole = await _users.Include (x => x.TblUserCinemaRole)
                .ThenInclude (x => x.TblCinemaRole).FirstOrDefaultAsync (x => x.Id == userId);
            var result = new List<ListModel> ();
            foreach (var item in cinemaRole.TblUserCinemaRole) {
                result.Add (new ListModel {
                    Id = item.CinemaRoleId,
                        Role = item.TblCinemaRole.Title
                });
            }
            List = result;

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

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync () {
            try {
                if (!ModelState.IsValid) {
                    return Page ();
                }
                var userId = User.Identity.GetUserId<string> ();
                var cinemaRole = await _dbSet.Include (x => x.TblUserCinemaRole)
                    .SingleAsync (x => x.Id == CinemaRoleId);
                cinemaRole.TblUserCinemaRole.Add (new TblUserCinemaRole {
                    UserId = userId
                });
                await _context.SaveChangesAsync ();
                Message = ConstValues.OkSave;
            } catch (Exception ex) {
                Message = ex.Message;
            }
            return RedirectToPage ("./CinemaRole");
        }

        public async Task<IActionResult> OnPostDeleteAsync (long id) {
            try {
                var userId = User.Identity.GetUserId<string> ();
                var cinemaRole = await _context.TblCinemaRole
                    .Include (x => x.TblUserCinemaRole.Where (x => x.UserId == userId && x.CinemaRoleId == id))
                    .FirstOrDefaultAsync (x => x.Id == id);
                var userCinemaRole = cinemaRole.TblUserCinemaRole.FirstOrDefault (x => x.UserId == userId && x.CinemaRoleId == id);
                cinemaRole.TblUserCinemaRole.Remove (userCinemaRole);
                await _context.SaveChangesAsync ();
                Message = ConstValues.OkRemove;
            } catch (Exception ex) {
                Message = ex.Message;
            }
            return RedirectToPage ("./CinemaRole");
        }

        public async Task<JsonResult> OnGetCinemaRoleAsSelectAsync (long id) {
            var towns = await _context.TblCinemaRole
                .Where (x => x.ParentId == id)
                .Select (x => new SelectListItem () {
                    Value = x.Id.ToString (), Text = x.Title,
                }).ToListAsync ();
            var selectList = new SelectList (towns, "Value", "Text");
            return new JsonResult (selectList);
        }
    }
}