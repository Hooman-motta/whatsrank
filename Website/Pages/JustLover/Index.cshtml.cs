using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Enums;
using Website.Helper.Utils;

namespace Website.Pages.JustLover {
    public class IndexModel : PageModel {
        private const int _pageSize = 12;
        private readonly AppDbContext _context;

        public IndexModel (AppDbContext context) {
            _context = context;
        }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }

            public JustLoverType Type { get; set; }

            public string FriendlyUrl { get; set; }

            public string MusicFramUrl { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync (int p = 1) {
            List = await PaginatedList<ListModel>.CreateAsync (
                _context.TblJustLover.AsNoTracking ()
                .Select (x => new ListModel {
                    Id = x.Id,
                        Title = x.Title,
                        Type = x.Type,
                        FriendlyUrl = x.Type == JustLoverType.Fram ? x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF) :
                        x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF_MUSIC),
                }), p, _pageSize
            );
        }
    }
}