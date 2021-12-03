using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// 
using DbLayer.Identity;

namespace Website.Areas.Co.Pages {
    public class IndexModel : PageModel {
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel (SignInManager<AppUser> signInManager) {
            _signInManager = signInManager;
        }
        public void OnGet () { }

        public async Task<IActionResult> OnGetLogOutAsync () {
            await _signInManager.SignOutAsync ();
            return RedirectToAction ("");
        }
    }
}