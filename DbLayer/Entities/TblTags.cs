using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// 
using DbLayer.Entities.Base;

namespace DbLayer.Entities {
    public class TblTags : BaseEntity {
        public TblTags () { }

        [StringLength (50)]
        public string Title { get; set; }

        public ICollection<TblMovieTags> TblMovieTags { set; get; }

        public ICollection<TblVtyStarsWarTags> TblVtyStarsWarTags { set; get; }
    }
}