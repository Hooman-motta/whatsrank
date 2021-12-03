using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using Website.Helper.Utils;
using Website.Service.SrcIdentity.Configure;

namespace Website.Pages.Account {

    public class ResumeModel : PageModel {
        private readonly AppDbContext _context;
        public ResumeModel (AppDbContext context) { _context = context; }

        [TempData]
        public string Message { get; set; }

        public class ListModel {
            public long Id { get; set; }

            public string Title { get; set; }

            public string VideoUrl { get; set; }
        }

        public List<ListModel> List { get; set; }

        public async Task OnGetAsync () {
            var userId = User.Identity.GetUserId<string> ();
            List = await _context.TblUserResume.Where (x => x.UserId == userId)
                .Select (x => new ListModel () {
                    Id = x.Id,
                        Title = x.Title, VideoUrl = x.VideoUrl
                }).ToListAsync ();
        }

        public async Task<IActionResult> OnPostDeleteAsync (long id) {
            try {
                var resume = await _context.TblUserResume.FindAsync (id);
                _context.TblUserResume.Remove (resume);
                await _context.SaveChangesAsync ();
                Message = ConstValues.OkRemove;
                return RedirectToPage ("./Resume");
            } catch (Exception ex) {
                Message = ex.Message;
                return RedirectToPage ("./Resume");
            }
        }
    }
}