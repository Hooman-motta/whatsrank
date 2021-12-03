using System.ComponentModel.DataAnnotations;

// 
using DbLayer.Enums;
using HpLayer.Attributes;

namespace Website.Helper.Vmodel {
    public class RegisterInputVm {
        [Display (Name = "نام کاربری")]
        [Required (ErrorMessage = "اجباری می باشد")]
        public string UserName { get; set; }

        [Display (Name = "پست الکترونیک")]
        [EmailAddress (ErrorMessage = "معتبر نمی باشد")]
        public string Email { get; set; }

        [CellNumberRegular]
        [Display (Name = "شماره تماس")]
        [DataType (DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType (DataType.Password)]
        [Display (Name = "کلمه عبور")]
        [Required (ErrorMessage = "اجباری می باشد")]
        [StringLength (100, ErrorMessage = "حداقل {2} حرف میتواند می باشد.", MinimumLength = 5)]
        public string Password { get; set; }

        [DataType (DataType.Password)]
        [Display (Name = "تکرار کلمه عبور")]
        [Compare ("Password", ErrorMessage = "کلمه عبور و تکرار آن تطابق ندارند.")]
        public string ConfirmPassword { get; set; }

        [Display (Name = "تخصص")]
        public CinemaRoleType? CinemaRoleType { get; set; }

        // [Display (Name = "استان")]
        // public long? ProvinceId { get; set; }
    }
}