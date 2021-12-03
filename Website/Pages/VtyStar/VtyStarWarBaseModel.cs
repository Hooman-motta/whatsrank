using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Enums;
using Website.Helper.Utils;

namespace Website.Pages.VtyStar {
    public class VtyStarWarBaseModel : PageModel {
        private const int _pageSize = 12;
        private readonly VtyStarsWarType _type;
        private readonly AppDbContext _context;

        public VtyStarWarBaseModel (VtyStarsWarType type, AppDbContext context) {
            _type = type;
            _context = context;
        }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }

            public string SubjectTitle { get; set; }

            public string FriendlyUrl { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync (int p = 1) {
            List = await PaginatedList<ListModel>.CreateAsync (
                _context.TblVtyStarsWar.Where (x => x.Type == _type).AsNoTracking ()
                .Select (x => new ListModel {
                    Id = x.Id,
                        Title = x.Title,
                        SubjectTitle = x.SubjectTitle,
                        FriendlyUrl = x.ThumbnailsUrl.ToFriendlyImage (DefaultImageType.DEF),
                }), p, _pageSize
            );
        }
    }
}