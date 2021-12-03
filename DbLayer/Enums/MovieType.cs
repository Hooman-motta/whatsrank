using System.ComponentModel.DataAnnotations;

namespace DbLayer.Enums {
    public enum MovieType : byte {
        [Display (Name = "فیلم")]
        Film = 1,

        [Display (Name = "سریال")]
        Serial = 2,

        [Display (Name = "تئاتر")]
        Theater = 3,
    }
}