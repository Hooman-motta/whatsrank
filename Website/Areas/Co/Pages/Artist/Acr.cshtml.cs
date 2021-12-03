using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities;
using Website.Areas.Shared;
using Website.Helper.Utils;

namespace Website.Areas.Co.Pages.Artist {
    public class AcrModel : RootPage<TblArtist> {
        public AcrModel (AppDbContext context) : base (context) { }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        public class InputModel {
            [Display (Name = "نقش : ")]
            [Range (1, long.MaxValue, ErrorMessage = ConstValues.RqError)]
            public long CinemaRoleId { get; set; }

            public List<SelectListItem> Roles { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel {
            public string RoleName { get; set; }

            public long CinemaRoleId { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync () {
            var artist = await _dbSet.Where (x => x.Id == Id)
                .Include (x => x.TblArtistCinemaRole).ThenInclude (x => x.TblCinemaRole).FirstOrDefaultAsync ();
            List = artist.TblArtistCinemaRole.Select (x => new ListModel {
                CinemaRoleId = x.CinemaRoleId,
                    RoleName = x.TblCinemaRole.Title
            }).ToList ();
        }

        public async Task<IActionResult> OnPostAsync () {
            if (ModelState.IsValid) {
                try {
                    var artist = await FindAsync (Id);
                    var artistCinemaRole = new List<TblArtistCinemaRole> ();
                    artistCinemaRole.Add (new TblArtistCinemaRole {
                        CinemaRoleId = Input.CinemaRoleId
                    });
                    artist.TblArtistCinemaRole = artistCinemaRole;
                    await _context.SaveChangesAsync ();
                    Alert = ModelStateType.A200.ModelStateAsText ();
                } catch {
                    ModelState.AddModelError ("", ConstValues.ErAlready);
                    Alert = ModelState.ModelStateAsError ();
                }
            }
            return RedirectToPage ("./Acr");
        }

        // handler
        public async Task<PartialViewResult> OnGetCreate () {
            var roles = await _context
                .TblCinemaRole.Select (x => new SelectListItem () {
                    Value = x.Id.ToString (),
                        Text = x.Title
                }).ToListAsync ();
            roles.Insert (0, new SelectListItem () {
                Text = "انتخاب کنید"
            });
            return Partial ("_AcrCreate", new InputModel {
                Roles = roles
            });
        }

        public async Task<IActionResult> OnPostRemove (long cinemaRoleId) {
            try {
                var artist = await _dbSet.Include (x => x.TblArtistCinemaRole
                        .Where (x => x.ArtistId == Id && x.CinemaRoleId == cinemaRoleId))
                    .FirstOrDefaultAsync (x => x.Id == Id);
                var cinemaRole = artist.TblArtistCinemaRole.FirstOrDefault (x => x.CinemaRoleId == cinemaRoleId && x.ArtistId == Id);
                artist.TblArtistCinemaRole.Remove (cinemaRole);
                await _context.SaveChangesAsync ();
                Alert = ModelStateType.A200.ModelStateAsText ();
            } catch (Exception ex) {
                ModelState.AddModelError ("", ex.Message);
                Alert = ModelState.ModelStateAsError ();
            }
            return RedirectToPage ("./Acr");
        }
    }
}