using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Enums;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.ViewComponents {
    public class MovieTopTenViewComponent : ViewComponent {
        private readonly AppDbContext _context;

        public MovieTopTenViewComponent (AppDbContext context) { _context = context; }
        public async Task<IViewComponentResult> InvokeAsync (MovieType type) {
            var grouped = await _context.TblMovie.Where (x => x.Type == (byte) type)
                .Include (x => x.TblMovieVote).SelectMany (x => x.TblMovieVote)
                .GroupBy (x => x.MovieId).Select (x => new TopTenHelperVm {
                    Id = x.Key, VoteAverage = x.Average (x => x.Mark), VoteCount = x.Count (),
                        SortType = x.Average (x => x.Mark)
                }).OrderByDescending (x => x.SortType).Take (10).ToListAsync ();
            var topTen = await _context.TblMovie
                .Where (x => grouped.Select (x => x.Id).Any (y => y == x.Id))
                .Select (x => new TopTenHelperVm {
                    Id = x.Id,
                        Value = x.Title,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF_MOVIIE),
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