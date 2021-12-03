using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using CldLayer.Persian;
using DbLayer.Interfaces;

namespace DbLayer.Entities.Base {
    public abstract class BaseEntity : IEntityBase {
        [Display (Name = "Id", Order = 0)]
        [Key, DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
    }

    // public abstract class DeleteEntity : EntityBase, IDeleteEntity {
    //     public bool IsDeleted { get; set; }
    // }
}