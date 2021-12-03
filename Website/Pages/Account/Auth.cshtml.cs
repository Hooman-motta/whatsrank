using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Helper;
using DbLayer.Identity;
using HpLayer.Helper;
using Website.Helper.Vmodel;

namespace Website.Pages.Account {

    public class AuthModel : PageModel {
        public readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthModel (AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string ReturnUrl { get; set; }

        public void OnGet (string returnUrl = null) {
            ReturnUrl = returnUrl;
        }

        public PartialViewResult OnGetRegister () {
            return Partial ("_Register");
        }

        public async Task<IActionResult> OnPostRegisterAsync (RegisterInputVm model) {
            if (ModelState.IsValid) {
                var user = new AppUser {
                    Email = model.Email,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber,
                    // ProvinceId = model.ProvinceId,
                };

                // set province
                // if (model.ProvinceId.HasValue) {
                //     user.ProvinceId = model.ProvinceId;
                // }

                // set role
                if (model.CinemaRoleType.HasValue) {
                    var userCinemaRole = new List<TblUserCinemaRole> () {
                        new TblUserCinemaRole {
                        AppUser = user,
                        CinemaRoleId = (long) model.CinemaRoleType
                        }
                    };
                    user.TblUserCinemaRole = userCinemaRole;
                }

                // register
                var result = await _userManager.CreateAsync (user, model.Password);
                if (result.Succeeded) {
                    var callbackUrl = Url.Page ("/Account/Index");
                    // if (model.ProvinceId.HasValue || model.CinemaRoleType.HasValue) {
                    if (model.CinemaRoleType.HasValue) {
                        await _userManager.AddToRoleAsync (user, ConstRoles.Artist);
                    } else {
                        await _userManager.AddToRoleAsync (user, ConstRoles.User);
                    }
                    await _signInManager.SignInAsync (user, isPersistent : true);
                    return new OkObjectResult (ApiResult.Succeeded (callbackUrl));
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError (string.Empty, error.Description);
                }
            }
            // error
            var errors = ModelState.Values.SelectMany (v => v.Errors)
                .Select (x => new ApiMessage { Key = "", Value = x.ErrorMessage }).ToArray ();
            return new BadRequestObjectResult (ApiResult.Failed (errors));
        }

        public PartialViewResult OnGetLogin () {
            return Partial ("_Login");
        }

        public async Task<IActionResult> OnPostLoginAsync (LoginInputVm model) {
            if (ModelState.IsValid) {
                var result = await _signInManager
                    .PasswordSignInAsync (model.UserName, model.Password, model.RememberMe, lockoutOnFailure : false);
                if (result.Succeeded) {
                    var callbackUrl = Url.Page ("/Account/Index");
                    return new OkObjectResult (ApiResult.Succeeded (callbackUrl));
                }
                if (result.IsLockedOut) {
                    ModelState.AddModelError ("", "حساب کاربری شما مسدود شده است.");
                }
                ModelState.AddModelError ("", "اطلاعات وارد شده صحیح نمی باشد.");
            }
            // error
            var errors = ModelState.Values.SelectMany (v => v.Errors)
                .Select (x => new ApiMessage { Key = "", Value = x.ErrorMessage }).ToArray ();
            return new BadRequestObjectResult (ApiResult.Failed (errors));
        }

        public async Task<JsonResult> OnGetTowns (long id) {
            var towns = await _context.TblProvince
                .Where (x => x.ParentId == id)
                .Select (x => new SelectListItem () {
                    Value = x.Id.ToString (), Text = x.Title,
                }).ToListAsync ();
            var selectList = new SelectList (towns, "Value", "Text");
            return new JsonResult (selectList);
        }
    }
}