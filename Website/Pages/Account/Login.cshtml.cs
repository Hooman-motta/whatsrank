using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// 
using DbLayer.Identity;
namespace Website.Pages.Account {

    [AllowAnonymous]
    public class LoginModel : PageModel {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        public LoginModel (UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager) {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public void OnGet () {
            if (_signInManager.IsSignedIn (User)) {
                RedirectToPage ("Index", new { area = "Co" });
            }
            // return RedirectToPage ("./Login");
        }

        [BindProperty]
        public InputModel Input { get; set; }

        // public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel {
            [Required]
            [Display (Name = "Username")]
            public string Email { get; set; }

            [Required]
            [DataType (DataType.Password)]
            public string Password { get; set; }

            [Display (Name = "Remember me")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnPostAsync (string returnUrl = null) {
            returnUrl = returnUrl ?? Url.Content ("~/");

            if (ModelState.IsValid) {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var userName = Input.Email;
                if (IsValidEmail (Input.Email)) {
                    var user = await _userManager.FindByEmailAsync (Input.Email);
                    if (user != null) {
                        userName = user.UserName;
                    }
                }
                var result = await _signInManager
                    .PasswordSignInAsync (userName, Input.Password, isPersistent : Input.RememberMe,
                        lockoutOnFailure : false);

                if (result.Succeeded) {
                    // _logger.LogInformation ("User logged in.");
                    // return LocalRedirect (returnUrl);
                    return LocalRedirect ("/Co");
                }
                if (result.RequiresTwoFactor) {
                    return RedirectToPage ("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut) {
                    // _logger.LogWarning ("User account locked out.");
                    return RedirectToPage ("./Lockout");
                } else {
                    ModelState.AddModelError (string.Empty, "Invalid login attempt.");
                    return Page ();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page ();
        }

        public bool IsValidEmail (string emailaddress) {
            try {
                MailAddress m = new MailAddress (emailaddress);
                return true;
            } catch (FormatException) {
                return false;
            }
        }
    }
}