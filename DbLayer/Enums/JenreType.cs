using System.ComponentModel.DataAnnotations;

namespace DbLayer.Enums {
    public enum JenreType : byte {
        [Display (Name = "کودک")]
        Teenager = 1,

        [Display (Name = "انیمیشن")]
        Animation = 2,

        [Display (Name = "اکشن")]
        Action = 3,

        [Display (Name = "کمدی")]
        Comedy = 4,

        [Display (Name = "عاشقانه")]
        Romance = 5,

        [Display (Name = "کمدی عاشقانه")]
        RomanticComedy = 6,

        [Display (Name = "ترسناک")]
        Horror = 7,

        [Display (Name = "درام")]
        Drama = 8,

        [Display (Name = "تاریخی")]
        Historic = 9,

        [Display (Name = "مستند")]
        Documentary = 10,

        [Display (Name = "خانوادگی")]
        Family = 11,

        [Display (Name = "جنایی")]
        Criminal = 12,

        [Display (Name = "اجتماعی")]
        Social = 13,

        [Display (Name = "ورزشی")]
        Sport = 14,

        [Display (Name = "دینی")]
        Religion = 15,

        [Display (Name = "جنگی")]
        War = 16,
    }
}