using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Enums;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Pages.Movie {
    public class MovieBaseModel : PageModel {
        private readonly MovieType _type;
        private const int _pageSize = 12;
        private readonly AppDbContext _context;

        public MovieBaseModel (MovieType type, AppDbContext context) {
            _type = type;
            _context = context;
        }

        public class ListModel : VoteHelperVm {
            public long Id { get; set; }

            public string Title { get; set; }

            public string ReleaseDate { get; set; }

            public string KeyWord { get; set; }

            public string FriendlyUrl { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync (int p = 1) {
            List = await PaginatedList<ListModel>.CreateAsync (
                _context.TblMovie.Where (x => x.Type == (byte) _type)
                .Include (x => x.TblMovieVote).Select (x => new ListModel {
                    Id = x.Id,
                        Title = x.Title,
                        KeyWord = x.KeyWord,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF),
                        VoteCount = x.TblMovieVote.Any () ? x.TblMovieVote.Count () : 0,
                        VoteAverage = x.TblMovieVote.Any () ? x.TblMovieVote.Average (x => x.Mark) : 0
                }), p, _pageSize
            );
        }
    }
}