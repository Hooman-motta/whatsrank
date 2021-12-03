using System;
using System.Collections.Generic;
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

namespace Website.Areas.Co.Pages.VtyStar {
    public class OptionModel : RootPage<TblVtyStarsWarOptions> {

        private static PgAddr pgAddr = new PgAddr {
            CreateName = "_CreateOption",
            redirectUrl = "./Option"
        };

        public OptionModel (AppDbContext context) : base (context, pgAddr) { }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        public class InputModel {
            [Display (Name = "عنوان : ")]
            [Required (ErrorMessage = ConstValues.RqError)]
            public string Option { get; set; }

            public long VtyStarsWarId { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class ListModel {
            public long Id { get; set; }

            public string Option { get; set; }

            public int VoteCount { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync () {
            List = await _dbSet
                .Where (x => x.VtyStarsWarId == Id)
                .Include (x => x.TblVtyStarWarUserVote)
                .Select (x => new ListModel {
                    Id = x.Id,
                        Option = x.Option,
                        VoteCount = x.TblVtyStarWarUserVote.Count (),
                }).ToListAsync ();
        }

        public async Task<IActionResult> OnPostAsync () {
            Input.VtyStarsWarId = Id;
            return await base.AddWithCheckState<InputModel> (Input);
        }

        // handler
        public PartialViewResult OnGetCreate () => base.HandlerCreate<InputModel> ();

        public async Task<IActionResult> OnPostRemove (long id) => await base.HandlerRemove (id);
    }
}