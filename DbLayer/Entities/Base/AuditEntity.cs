using System;
using System.ComponentModel.DataAnnotations.Schema;

// 
using CldLayer.Persian;
using DbLayer.Interfaces;

namespace DbLayer.Entities.Base {
    public abstract class AuditEntity : BaseEntity, IAuditEntity {

        [Column (TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }

        [Column (TypeName = "smalldatetime")]
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        [NotMapped]
        public virtual string PersianCreatedDate => CreatedDate.ToShortPersianDateString ();

        [NotMapped]
        public virtual string PersianUpdatedDate => UpdatedDate.ToShortPersianDateString ();
    }
}