using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities;
using Website.Areas.Shared;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Areas.Co.Pages.Tags {
    public class IndexModel : RootPage<TblTags> {

        public IndexModel (AppDbContext context) : base (context) { }

        public class InputModel {
            [Display (Name = "عنوان : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Title { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync ([FromQuery] FilterQs vm) {
            var entity = _dbSet.AsNoTracking ();
            if (!string.IsNullOrEmpty (vm.Filter)) {
                entity = _dbSet.Where (x => x.Title.Contains (vm.Filter));
            }
            List = await PaginatedList<ListModel>.CreateAsync (
                entity.Select (x => new ListModel {
                    Id = x.Id, Title = x.Title
                }), vm.P, _pageSize
            );
        }

        public async Task<IActionResult> OnPostAsync () => await base.AddWithCheckState<InputModel> (Input);

        // handler
        public PartialViewResult OnGetCreate () => base.HandlerCreate<InputModel> ();

        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);

        public async Task<IActionResult> OnGetTagsListAsync () {
            try {
                var tags = await _dbSet
                    .Select (x => new TagsVm () {
                        Id = x.Id, Title = x.Title
                    }).ToListAsync ();
                return new OkObjectResult (tags);
            } catch {
                return BadRequest (ConstValues.ErOnFetchingData);
            }
        }

        public class TagsVm {
            public long Id { get; set; }

            public string Title { get; set; }
        }
    }
}