using System.ComponentModel.DataAnnotations;

namespace Website.Helper.Vmodel {
    public class LoginInputVm {
        [Display (Name = "نام کاربری")]
        [Required (ErrorMessage = "اجباری می باشد")]
        public string UserName { get; set; }

        [DataType (DataType.Password)]
        [Display (Name = "کلمه عبور")]
        [Required (ErrorMessage = "اجباری می باشد")]
        [StringLength (100, ErrorMessage = "حداقل {2} حرف میتواند می باشد.", MinimumLength = 5)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}