using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;

namespace DbLayer.Identity {
    public class TblUserResume : BaseEntity {

        [StringLength (50)]
        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public string UserId { get; set; }

        [ForeignKey ("UserId")]
        public AppUser AppUser { get; set; }
    }
}