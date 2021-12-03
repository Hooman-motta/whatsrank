using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;
using DbLayer.Identity;

namespace DbLayer.Entities {
    public class TblJustLoverWinner : BaseEntity {
        // Foreign key
        public string UserId { get; set; }

        [ForeignKey ("UserId")]
        public AppUser AppUser { get; set; }

        public long JustLoverId { get; set; }

        [ForeignKey ("JustLoverId")]
        public TblJustLover TblJustLover { get; set; }
    }
}