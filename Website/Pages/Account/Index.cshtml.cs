using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// 
using DbLayer.Context;
using DbLayer.Enums;
using DbLayer.Identity;
using HpLayer.Attributes;
using HpLayer.Services;
using Website.Helper.Utils;

namespace Website.Pages.Account {

    public class IndexModel : PageModel {
        private readonly AppDbContext _context;
        private readonly IUploadServices _uploadServices;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public IndexModel (
            AppDbContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUploadServices uploadServices) {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _uploadServices = uploadServices;
        }

        public class ProvinceCity {
            public string Province { get; set; }
            public string City { get; set; }
        }

        public string ReturnUrl { get; set; }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel {
            [Display (Name = "نام و نام خانوادگی")]
            public string FullName { get; set; }

            [Display (Name = "مقطع تحصیلی")]
            public EducationType? Education { get; set; }

            [Display (Name = "در دسترس")]
            public bool IsAvailable { get; set; }

            [Display (Name = "تصویر پروفایل")]
            [AllowedExtensions (new string[] { ".jpg", ".png", ".jpeg" })]
            [AttrRequestSizeLimit (ConstValues.UPLOAD_SIZE_IMAGE_IN_MB)]
            public IFormFile FormFile { get; set; }

            [Display (Name = "پست الکترونیک")]
            [EmailAddress (ErrorMessage = "معتبر نمی باشد")]
            public string Email { get; set; }

            [CellNumberRegular]
            [Display (Name = "شماره تماس")]
            [DataType (DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }

            [Display (Name = "استان")]
            public long? ProvinceId { get; set; }

            [Display (Name = "خلاصه وضعیت")]
            public string Bio { get; set; }
        }

        public List<SelectListItem> Provinces { get; set; }

        public async Task OnGet (string returnUrl = null) {
            Provinces = await _context.TblProvince
                .Where (x => x.ParentId == null)
                .Select (x => new SelectListItem () {
                    Value = x.Id.ToString (),
                        Text = x.Title
                }).ToListAsync ();
            Provinces.Insert (0, new SelectListItem () {
                Text = "انتخاب کنید",
                    Value = "0"
            });
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync () {
            if (!ModelState.IsValid) {
                return Page ();
            }
            var user = await _userManager.GetUserAsync (User);
            if (Input.FormFile != null) {
                if (!string.IsNullOrEmpty (user.Avatar)) {
                    _uploadServices.PhysicalDeleteFile (user.Avatar);
                }
                var uploadFile =
                    await _uploadServices.SavePostedFileAsync (Input.FormFile, new BITMAPSIZE {
                        W = 160,
                            H = 180
                    });
                user.Avatar = uploadFile.Item1;
            }
            if (Input.ProvinceId.HasValue) {
                user.ProvinceId = Input.ProvinceId;
            }
            user.Email = Input.Email;
            user.PhoneNumber = Input.PhoneNumber;
            user.FullName = Input.FullName;
            user.Education = Input.Education ?? EducationType.None;
            user.IsAvailable = Input.IsAvailable;
            user.Bio = Input.Bio;
            await _userManager.UpdateAsync (user);
            Message = ConstValues.OkUpdate;
            return RedirectToPage ("./Index");
        }

        public async Task<IActionResult> OnPostLogout () {
            await _signInManager.SignOutAsync ();
            return LocalRedirect (Url.Content ("~/"));
        }

        public async Task<ProvinceCity> SetProvinceCityAsync (long cityId) {
            var provinceCity = new ProvinceCity ();
            var result = await _context.TblProvince
                .Include (x => x.Parent)
                .FirstOrDefaultAsync (x => x.Id == cityId);
            if (result != null) {
                provinceCity = new ProvinceCity {
                City = result.Title,
                Province = result.Parent.Title,
                };
            } else {
                provinceCity = default;
            }
            return provinceCity;
        }
    }
}