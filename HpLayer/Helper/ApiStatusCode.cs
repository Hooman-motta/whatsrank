using System.ComponentModel.DataAnnotations;

namespace HpLayer.Helper {
    public enum ApiStatusCode : int {
        [Display (Name = "عملیات با موفقیت انجام شد")]
        Success = 200,

        [Display (Name = "مقادیر ارسالی نامعتبر است")]
        BadRequest = 400,

        [Display (Name = "خطای احراز هویت رخ داده است")]
        Unauthorized = 401,

        [Display (Name = "خطای عدم دسترسی به صفحه مورد نظر رخ داده است")]
        Forbid = 403,

        [Display (Name = "موردی یافت نشد")]
        NotFound = 404,

        [Display (Name = "خطای تداخل رخ داده است")]
        Conflict = 409,

        [Display (Name = "خطا در سمت سرور رخ داده است")]
        ServerError = 500,
    }
}