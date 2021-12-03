using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//
using DbLayer.Identity;
using Website.Helper.Utils;
using Website.Service.SrcIdentity.Configure;

namespace Website.Pages.Account {

    public class ChangePasswordModel : PageModel {
        private readonly UserManager<AppUser> _userManager;

        public ChangePasswordModel (UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel {
            [Display (Name = "کلمه عبور فعلی")]
            [Required (ErrorMessage = "اجباری می باشد")]
            [StringLength (100, ErrorMessage = "حداقل {2} حرف میتواند می باشد.", MinimumLength = 5)]
            public string OldPassword { get; set; }

            [DataType (DataType.Password)]
            [Display (Name = "کلمه عبور جدید")]
            [Required (ErrorMessage = "اجباری می باشد")]
            [StringLength (100, ErrorMessage = "حداقل {2} حرف میتواند می باشد.", MinimumLength = 5)]
            public string Password { get; set; }

            [DataType (DataType.Password)]
            [Display (Name = "تکرار کلمه عبور")]
            [Compare ("Password", ErrorMessage = "کلمه عبور و تکرار آن تطابق ندارند.")]
            public string ConfirmPassword { get; set; }
        }

        public IActionResult OnGet (string code = null) {
            return Page ();
        }

        public async Task<IActionResult> OnPostAsync () {
            if (!ModelState.IsValid) {
                return Page ();
            }
            var userId = User.Identity.GetUserId<string> ();
            var user = await _userManager.FindByIdAsync (userId);
            var result = await _userManager.ChangePasswordAsync (user, Input.OldPassword, Input.Password);
            if (result.Succeeded) {
                Message = ConstValues.OkUpdate;
                return RedirectToPage ("./ChangePassword");
            }
            foreach (var error in result.Errors) {
                Message += $"{error.Description}";
            }
            return RedirectToPage ("./ChangePassword");
        }
    }
}