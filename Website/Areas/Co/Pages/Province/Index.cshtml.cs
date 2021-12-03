using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

// 
using DbLayer.Identity;

namespace Website.Areas.Co.Pages.Province {
    public class IndexModel : PageModel {
        public IndexModel () { }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }
        }

        public List<ListModel> List { get; set; }

        public void OnGet () {
            List = ProvinceHelper.All ()
                .Select (x => new ListModel () {
                    Id = x.Id,
                        Title = x.Title
                }).ToList ();
        }
    }
}