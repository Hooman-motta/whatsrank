using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;
using DbLayer.Identity;

namespace DbLayer.Entities {
    public class TblComment : AuditEntity {

        public TblComment () { }

        public string Extract { get; set; }

        public bool IsApproved { get; set; }

        // Foreign key
        public long VtyStarsWarId { get; set; }

        [ForeignKey ("VtyStarsWarId")]
        public TblVtyStarsWar TblVtyStarsWar { get; set; }

        public string UserId { get; set; }

        [ForeignKey ("UserId")]
        public AppUser AppUser { get; set; }
    }
}