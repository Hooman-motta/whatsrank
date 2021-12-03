using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.ViewComponents {
    public class ArtistTopTenViewComponent : ViewComponent {
        private readonly AppDbContext _context;

        public ArtistTopTenViewComponent (AppDbContext context) { _context = context; }

        public async Task<IViewComponentResult> InvokeAsync () {
            var grouped = await _context
                .TblArtistVote.GroupBy (x => x.ArtistId)
                .Select (x => new TopTenHelperVm {
                    Id = x.Key, VoteAverage = x.Average (x => x.Mark), VoteCount = x.Count (),
                        SortType = x.Average (x => x.Mark)
                }).OrderByDescending (x => x.SortType).Take (10).ToListAsync ();

            var arr = grouped.Select (x => x.Id).ToArray ();
            var topTen = await _context.TblArtist.Where (x => arr.Any (y => y == x.Id))
                .Select (x => new TopTenHelperVm {
                    Id = x.Id, Value = x.FullName,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF),
                }).ToListAsync ();
            foreach (var item in topTen) {
                item.VoteCount = grouped.FirstOrDefault (x => x.Id == item.Id).VoteCount;
                item.VoteAverage = grouped.FirstOrDefault (x => x.Id == item.Id).VoteAverage;
            }
            var result = topTen.OrderByDescending (x => x.VoteAverage).ToList ();
            return View (result);
        }
    }
}