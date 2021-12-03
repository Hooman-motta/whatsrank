using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Identity;

namespace DbLayer.Entities.Base {
    public abstract class VoteEntity : AuditEntity {
        [Range (0, 10)]
        public byte Mark { get; set; }

        public string UserId { get; set; }

        [ForeignKey ("UserId")]
        public AppUser AppUser { get; set; }
    }
}