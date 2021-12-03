using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Entities;
using Website.Areas.Shared;

namespace Website.Areas.Co.Pages.JustLover {
    public class AnswerModel : RootPage<TblJustLoverAnswers> {
        public AnswerModel (AppDbContext context) : base (context) { }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }

        public class ListModel {
            public long Id { get; set; }

            public string Username { get; set; }

            public string PersianCreatedDate { get; set; }

            public int AnswerNO { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync () {
            List = await _dbSet.Where (x => x.JustLoverId == Id)
                .Include (x => x.AppUser).Include (x => x.TblJustLover)
                .Select (x => new ListModel {
                    Id = x.Id,
                        Username = x.AppUser.UserName,
                        PersianCreatedDate = x.PersianCreatedDate,
                        AnswerNO = x.AnswerNO
                }).ToListAsync ();
        }
    }
}