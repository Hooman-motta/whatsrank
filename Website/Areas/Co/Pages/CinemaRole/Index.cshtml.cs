using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities;
using Website.Areas.Shared;

namespace Website.Areas.Co.Pages.CinemaRole {
    public class IndexModel : RootPage<TblCinemaRole> {
        public IndexModel (AppDbContext context) : base (context) { }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGet () {
            List = await _dbSet.Where (x => x.Parent == null)
                .Select (x => new ListModel {
                    Id = x.Id,
                        Title = x.Title
                }).ToListAsync ();
        }
    }
}