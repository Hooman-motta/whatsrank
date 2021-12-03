using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Identity;
using Website.Areas.Shared;
using Website.Helper.Utils;

namespace Website.Areas.Co.Pages.Province {
    public class CityModel : RootPage<TblProvince> {
        private static PgAddr pgAddr = new PgAddr {
            CreateName = "_Create",
            redirectUrl = "./City"
        };

        public CityModel (AppDbContext context) : base (context, pgAddr) { }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        public class InputModel {
            [Display (Name = "عنوان : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Title { get; set; }

            public long ParentId { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel : InputModel {
            public long Id { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync () {
            List = await _dbSet.Where (x => x.ParentId == Id)
                .Select (x => new ListModel () {
                    Id = x.Id,
                        Title = x.Title
                }).ToListAsync ();
        }

        public async Task<IActionResult> OnPostAsync () {
            Input.ParentId = Id;
            return await base.AddWithCheckState<InputModel> (Input);
        }

        // handler
        public PartialViewResult OnGetCreate () => base.HandlerCreate<InputModel> ();

        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);
    }
}