using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;
using DbLayer.Identity;

namespace DbLayer.Entities {
    public class TblVtyStarsWarOptions : BaseEntity {
        public TblVtyStarsWarOptions () { }

        [StringLength (1000)]
        public string Option { get; set; }

        // Foreign key
        public long VtyStarsWarId { get; set; }

        [ForeignKey ("VtyStarsWarId")]
        public TblVtyStarsWar TblVtyStarsWar { get; set; }

        // Collection
        public ICollection<TblVtyStarWarUserVote> TblVtyStarWarUserVote { set; get; }
    }
}