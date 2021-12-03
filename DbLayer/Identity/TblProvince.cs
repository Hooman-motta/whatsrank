using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;

namespace DbLayer.Identity {
    public class TblProvince : BaseEntity {

        [StringLength (50)]
        public string Title { get; set; }

        // public string Code { get; set; }

        public long? ParentId { get; set; }

        [ForeignKey ("ParentId")]
        public TblProvince Parent { get; set; }

        // Collection
        public ICollection<TblProvince> Towns { set; get; }

        public ICollection<AppUser> AppUser { set; get; }
    }
}