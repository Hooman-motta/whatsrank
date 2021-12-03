using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;

namespace DbLayer.Identity {
    public class TblUserVote : AuditEntity {
        [Range (0, 10)]
        public byte Mark { get; set; }
        public string VoterId { get; set; }

        public string UserId { get; set; }

        [ForeignKey ("UserId")]
        public AppUser AppUser { get; set; }
    }
}