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

namespace Website.Areas.Co.Pages.User {
    public class ResumeModel : RootPage<TblUserResume> {
        private static PgAddr pgAddr = new PgAddr {
            CreateName = "_CreateResume",
            redirectUrl = "./Resume"
        };
        public ResumeModel (AppDbContext context) : base (context, pgAddr) { }

        [BindProperty (SupportsGet = true)]
        public string Id { get; set; }

        public class InputModel {
            [Display (Name = "عنوان : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Title { get; set; }

            [Display (Name = "آدرس : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string VideoUrl { get; set; }

            public string UserId { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }

            public string VideoUrl { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync () {
            List = await _dbSet.Where (x => x.UserId == Id)
                .Select (x => new ListModel () {
                    Id = x.Id,
                        Title = x.Title, VideoUrl = x.VideoUrl
                }).ToListAsync ();
        }

        public async Task<IActionResult> OnPostAsync () {
            Input.UserId = Id;
            return await base.AddWithCheckState<InputModel> (Input);
        }

        // handler
        public PartialViewResult OnGetCreate () => base.HandlerCreate<InputModel> ();

        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);
    }
}