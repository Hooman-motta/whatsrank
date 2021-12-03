using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Pages.Artist {
    public class IndexModel : PageModel {
        private const short _pageSize = 10;
        private readonly AppDbContext _context;
        public IndexModel (AppDbContext context) { _context = context; }

        public class ListModel {
            public string Title { get; set; }
            public List<TopTenVm> TopTenList { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync (int p = 1) {
            var count = await _context.TblArtistMovieRole
                .GroupBy (x => new { x.ArtistId, x.CinemaRoleId }).CountAsync ();
            var result = _context.TblArtistMovieRole
                .Include (x => x.TblArtistVote).AsEnumerable ()
                .GroupBy (x => new { x.ArtistId, x.CinemaRoleId })
                .Select (x => new TopTenVm {
                    ArtistId = x.Key.ArtistId,
                        CinemaRoleId = x.Key.CinemaRoleId,
                        VoteCount = x.Sum (y => y.TblArtistVote.Count ()),
                        VoteAverage = x.Any (y => y.TblArtistVote.Any ()) ? x.Average (y => y.TblArtistVote.Sum (z => z.Mark)) : 0,
                }).OrderByDescending (x => x.DisplayVoteAverage)
                .Skip ((p - 1) * _pageSize).Take (_pageSize).ToList ();

            var idsArtists = result.GroupBy (x => x.ArtistId).Select (x => x.Key).ToArray ();
            var artists = await _context.TblArtist.Where (x => idsArtists.Any (y => y == x.Id))
                .Select (x => new ArtistVm {
                    Id = x.Id, FullName = x.FullName,
                        ThumbnailsUrl = x.ThumbnailsUrl,
                }).ToListAsync ();

            foreach (var item in result) {
                var artist = artists.FirstOrDefault (x => x.Id == item.ArtistId);
                item.FullName = artist.FullName;
                item.FriendlyUrl = artist.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF_MOVIIE);
            }

            var cinemaRoleIds = result
                .GroupBy (x => x.CinemaRoleId)
                .Select (x => x.Key).ToArray ();
            var cinemaRoles = await _context.TblCinemaRole
                .Where (x => cinemaRoleIds.Any (y => y == x.Id))
                .Select (x => new CinemaRoleVm {
                    Id = x.Id,
                        Tile = x.Title,
                }).ToListAsync ();

            var topTenList = new List<ListModel> ();
            foreach (var item in cinemaRoles) {
                var topTenItem = new ListModel ();
                topTenItem.Title = item.Tile;
                topTenItem.TopTenList = result.Where (x => x.CinemaRoleId == item.Id).ToList ();
                topTenList.Add (topTenItem);
            }
            List = topTenList;
        }

        public class ArtistVm {
            public long Id { get; set; }
            public string FullName { get; set; }
            public byte? Mark { get; set; } = null;
            public string ThumbnailsUrl { get; set; }
        }

        public class CinemaRoleVm {
            public long Id { get; set; }
            public string Tile { get; set; }
        }

        public class TopTenListVm {
            public string Title { get; set; }
            public List<TopTenVm> TopTenList { get; set; }
        }

        public class TopTenVm : VoteHelperVm {
            public long ArtistId { get; set; }

            public long CinemaRoleId { get; set; }

            public string FullName { get; set; }

            public string FriendlyUrl { get; set; }
        }
    }
}