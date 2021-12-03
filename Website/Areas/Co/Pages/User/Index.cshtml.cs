using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// 
using CldLayer.Persian;
using DbLayer.Context;
using DbLayer.Identity;
using Website.Helper.Utils;
using Website.Helper.Vmodel;

namespace Website.Areas.Co.Pages.User {
    public class IndexModel : PageModel {
        private const int _pageSize = 10;
        private readonly AppDbContext _context;
        private readonly DbSet<AppUser> _users;
        private readonly UserManager<AppUser> _userManager;

        public IndexModel (AppDbContext context, UserManager<AppUser> userManager) {
            _context = context;
            _userManager = userManager;
            _users = _context.Set<AppUser> ();
        }

        public class ListModel {
            public string Id { get; set; }

            public string Avatar { get; set; }

            public string DisplayName { get; set; }

            public string EnrollmentDate { get; set; }
        }

        public PaginatedList<ListModel> List { get; set; }

        public async Task OnGetAsync ([FromQuery] FilterQs vm) {
            var entity = _users.AsNoTracking ();
            if (!string.IsNullOrEmpty (vm.Filter)) {
                entity = _users.Where (x => x.UserName.Contains (vm.Filter));
            }
            List = await PaginatedList<ListModel>.CreateAsync (
                entity.Select (x => new ListModel {
                    Id = x.Id, DisplayName = x.DisplayName,
                        EnrollmentDate = x.DateCreated.ToShortPersianDateString ()
                }), vm.P, _pageSize
            );
        }
    }
}