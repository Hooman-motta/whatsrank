using System.ComponentModel.DataAnnotations;

namespace DbLayer.Enums {
    public enum EducationType : byte {
        [Display (Name = "بدون انتخاب")]
        None = 1,

        [Display (Name = "زیر دیپلم")]
        LessHighSchool = 2,

        [Display (Name = "دیپلم")]
        HighSchool = 3,

        [Display (Name = "فوق دیپلم")]
        Associate = 4,

        [Display (Name = "لیسانس")]
        Bachelor = 5,

        [Display (Name = "فوق لیسانس")]
        Master = 6,

        [Display (Name = "دکترا")]
        Phd = 7,
    }
}