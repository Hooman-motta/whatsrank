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
using Website.Helper.Vmodel;

namespace Website.Areas.Co.Pages.Movie {
    public class AmrModel : RootPage<TblArtistMovieRole> {
        private static PgAddr pgAddr = new PgAddr {
            CreateName = "_AmrCreate",
            redirectUrl = "./Amr"
        };
        public AmrModel (AppDbContext context) : base (context, pgAddr) { }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        public class InputModel {
            [Display (Name = "هنرمند : ")]
            [Range (1, long.MaxValue, ErrorMessage = ConstValues.RqError)]
            public long ArtistId { get; set; }

            [Display (Name = "نقش : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            [Range (1, long.MaxValue, ErrorMessage = ConstValues.RqError)]
            public long CinemaRoleId { get; set; }
            public List<SelectListItem> Artists { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel : VoteHelperVm {
            public long Id { get; set; }

            public string Artist { get; set; }

            public string CinemaRole { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync () {
            List = await _dbSet.Where (x => x.MovieId == Id)
                .Include (x => x.TblArtist)
                .Include (x => x.TblCinemaRole)
                .Include (x => x.TblArtistVote)
                .Select (x => new ListModel {
                    Id = x.Id,
                        Artist = x.TblArtist.FullName,
                        CinemaRole = x.TblCinemaRole.Title,
                        VoteCount = x.TblArtistVote.Count (),
                        VoteAverage = x.TblArtistVote.Any () ? x.TblArtistVote.Average (x => x.Mark) : 0,
                }).ToListAsync ();
        }

        public async Task<IActionResult> OnPostAsync () {
            if (ModelState.IsValid) {
                try {
                    var artistMovieRole = await _dbSet
                        .FirstOrDefaultAsync (x => x.MovieId == Id &&
                            x.CinemaRoleId == Input.CinemaRoleId && x.ArtistId == Input.ArtistId);
                    if (artistMovieRole != null) {
                        throw new Exception (ConstValues.ErAlready);
                    }
                    await AddItem (new TblArtistMovieRole {
                        MovieId = Id,
                            ArtistId = Input.ArtistId,
                            CinemaRoleId = Input.CinemaRoleId
                    });
                    Alert = ModelStateType.A200.ModelStateAsText ();
                } catch (Exception ex) {
                    ModelState.AddModelError ("", ex.Message);
                    Alert = ModelState.ModelStateAsError ();
                }
            }
            return RedirectToPage (pgAddr.redirectUrl);
        }

        // handler
        public async Task<PartialViewResult> OnGetCreate () {
            var artistsAsSelect = await _context.TblArtist
                .Select (x => new SelectListItem () {
                    Value = x.Id.ToString (),
                        Text = x.FullName
                }).ToListAsync ();
            artistsAsSelect.Insert (0, new SelectListItem () {
                Text = "انتخاب کنید",
                    Value = "0"
            });
            return Partial (pgAddr.CreateName, new InputModel {
                Artists = artistsAsSelect
            });
        }

        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);
    }
}