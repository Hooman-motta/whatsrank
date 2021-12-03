using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities;
using Website.Areas.Shared;
using Website.Helper.Utils;

namespace Website.Areas.Co.Pages.Comment {
    public class IndexModel : RootPage<TblComment> {
        public IndexModel (AppDbContext context) : base (context) { }

        public class ListModel {
            public long Id { get; set; }

            public string PostType { get; set; }

            public string PostTitle { get; set; }

            public string Extract { get; set; }

            public bool IsApproved { get; set; }

            public string DisplayName { get; set; }

            public string PersianCreatedDate { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync ([FromQuery] int p = 1) {
            var entity = _dbSet.Include (x => x.AppUser)
                .Include (x => x.TblVtyStarsWar).AsQueryable ();
            List = await PaginatedList<ListModel>.CreateAsync (
                entity.Select (x => new ListModel {
                    Id = x.Id,
                        Extract = x.Extract,
                        IsApproved = x.IsApproved,
                        PersianCreatedDate = x.PersianCreatedDate,
                        DisplayName = x.AppUser.DisplayName,
                        PostTitle = x.TblVtyStarsWar.Title,
                        PostType = x.TblVtyStarsWar.TypeTitle
                }), p, _pageSize
            );
        }

        // handler
        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);

        public async Task<IActionResult> OnGetChangeAsync (long id) {
            try {
                var result = await FindAsync (id);
                result.IsApproved = !result.IsApproved;
                await EditItem (result);
                return new OkObjectResult (ConstValues.OkUpdate);
            } catch {
                return BadRequest (ConstValues.ErOnFetchingData);
            }
        }
    }
}