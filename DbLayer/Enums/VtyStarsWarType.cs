using System.ComponentModel.DataAnnotations;

namespace DbLayer.Enums {
    public enum VtyStarsWarType : byte {
        [Display (Name = "جنگ ستارگان")]
        StarsWar = 1,

        [Display (Name = "واریته")]
        Vty = 2
    }
    public enum VtyStarsWarSubject : byte {
        // 
        [Display (Name = "اخبار سینما و سریال")]
        CinemaAndSerialNews = 1,

        // 
        [Display (Name = "اخبار تئاتر")]
        TheaterNews = 2,

        // 
        [Display (Name = "حواشی سینما و سریال")]
        CinemaAndSerialMargin = 2,

        // 
        [Display (Name = "حواشی تئاتر")]
        TheaterMargin = 2,

        // 
        [Display (Name = "نقد و تحلیل سینما و سریال")]
        CinemaAndSerialReview = 2,

        // 
        [Display (Name = "نقد و تحلیل تئاتر")]
        TheaterReview = 2,
    }
}