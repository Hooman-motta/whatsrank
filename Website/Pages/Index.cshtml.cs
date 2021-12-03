using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

//
using DbLayer.Context;
using DbLayer.Enums;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Pages {

    public class IndexModel : PageModel {
        public readonly AppDbContext _context;

        public IndexModel (AppDbContext context) {
            _context = context;
        }

        public string ReturnUrl { get; set; }
        public HomePageVm Film { get; set; }
        public HomePageVm Serial { get; set; }
        public HomePageVm Theater { get; set; }
        public HomePageVm StarWar { get; set; }
        public HomePageVm Vty { get; set; }
        public HomePageVm JustLover { get; set; }

        public async Task OnGet (string returnUrl = null) {
            // film
            var resultFile = await _context.TblMovie
                .Where (x => x.Type == (byte) MovieType.Film)
                .OrderByDescending (x => x.Id).Take (5)
                .Select (x => new HomePageVm {
                    Id = x.Id, Title = x.Title,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF)
                }).ToListAsync ();
            if (resultFile.Any ()) {
                Film = resultFile.OrderBy (g => Guid.NewGuid ()).FirstOrDefault ();
            }

            // serial
            var resultSerial = await _context.TblMovie
                .Where (x => x.Type == (byte) MovieType.Serial)
                .OrderByDescending (x => x.Id).Take (5)
                .Select (x => new HomePageVm {
                    Id = x.Id, Title = x.Title,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF)
                }).ToListAsync ();
            if (resultSerial.Any ()) {
                Serial = resultSerial.OrderBy (g => Guid.NewGuid ()).FirstOrDefault ();
            }

            // theater
            var resultTheater = await _context.TblMovie
                .Where (x => x.Type == (byte) MovieType.Theater)
                .OrderByDescending (x => x.Id).Take (5)
                .Select (x => new HomePageVm {
                    Id = x.Id, Title = x.Title,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF)
                }).ToListAsync ();
            if (resultTheater.Any ()) {
                Theater = resultTheater.OrderBy (g => Guid.NewGuid ()).FirstOrDefault ();
            }

            // starwar
            var resultStarWar = await _context.TblVtyStarsWar
                .Where (x => x.Type == VtyStarsWarType.StarsWar)
                .OrderByDescending (x => x.Id).Take (5)
                .Select (x => new HomePageVm {
                    Id = x.Id, Title = x.Title,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF)
                }).ToListAsync ();
            if (resultStarWar.Any ()) {
                StarWar = resultStarWar.OrderBy (g => Guid.NewGuid ()).FirstOrDefault ();
            }

            // vty
            var resultVty = await _context.TblVtyStarsWar
                .Where (x => x.Type == VtyStarsWarType.Vty)
                .OrderByDescending (x => x.Id).Take (5)
                .Select (x => new HomePageVm {
                    Id = x.Id, Title = x.Title,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF)
                }).ToListAsync ();
            if (resultVty.Any ()) {
                Vty = resultVty.OrderBy (g => Guid.NewGuid ()).FirstOrDefault ();
            }

            // justlover
            var resultJustlover = await _context.TblJustLover
                .OrderByDescending (x => x.Id).Take (3)
                .Select (x => new HomePageVm {
                    Id = x.Id, Title = x.Title,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF)
                }).ToListAsync ();

            if (resultJustlover.Any ()) {
                JustLover = resultJustlover.OrderBy (g => Guid.NewGuid ()).FirstOrDefault ();
            }

            ReturnUrl = returnUrl;
        }
    }
}