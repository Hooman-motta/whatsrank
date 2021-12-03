using System.ComponentModel.DataAnnotations;

namespace DbLayer.Enums {

    public enum CinemaRoleType : byte {
        [Display (Name = "تهیه کننده")]
        Producer = 1,

        [Display (Name = "کارگردان")]
        Director = 2,

        [Display (Name = "بازیگر")]
        Actor = 3,

        [Display (Name = "فیلم نامه نویس")]
        Writer = 4,

        [Display (Name = "مدیر تصویر برداری")]
        ImagineManager = 5,

        [Display (Name = "تدوین گر")]
        Editing = 6,

        [Display (Name = "آهنگساز")]
        SongMaker = 7,

        [Display (Name = "طراح صحنه")]
        SceneDesigner = 8,

        [Display (Name = "طراح لباس")]
        DressDesigner = 9,

        [Display (Name = "صدابردار")]
        GetVoice = 10,

        [Display (Name = "صداگذار")]
        SetVoice = 11,

        [Display (Name = "طراح گریم")]
        MakeupDesigner = 12,

        [Display (Name = "نمایشنامه نویس")]
        ShoWWriter = 13,

        [Display (Name = "دراماتورژ")]
        Dramaturgie = 14,

        [Display (Name = "طراح نور")]
        LightDesigner = 15,

        [Display (Name = "سایر")]
        Others = 16,
    }
}