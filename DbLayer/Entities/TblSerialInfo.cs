using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;
using HpLayer.Helper;

namespace DbLayer.Entities {
    public class TblSerialInfo : FileEntity {
        public TblSerialInfo () { }

        public byte Number { get; set; }

        [NotMapped]
        public string NumberTitle => $"{(ParentId ==null ? "فصل" : "قسمت")}-{NumberHelper.Init (Number)}";

        public long? ParentId { get; set; }
        public TblSerialInfo Parent { get; set; }

        // Foreign key
        [ForeignKey ("MovieId")]
        public TblMovie TblMovie { get; set; }
        public long MovieId { get; set; }

        // Collection
        public ICollection<TblSerialInfo> Children { set; get; }

        public ICollection<TblSerialVote> TblSerialVote { set; get; }
    }
}