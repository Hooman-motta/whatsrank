  using System.ComponentModel.DataAnnotations;

  namespace DbLayer.Enums {
      public enum JustLoverType : byte {
          [Display (Name = "فریم")]
          Fram = 1,

          [Display (Name = "موسیقی")]
          Music = 2,
      }
  }