using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;
using DbLayer.Enums;
using HpLayer.Extensions;

namespace DbLayer.Entities {
    public class TblJustLover : JLVSFBase {
        public JustLoverType Type { get; set; }

        [NotMapped]
        public string TypeTitle =>
            EnumExtensions.GetDisplayName ((JustLoverType) Type);

        [StringLength (500)]
        public string Option1 { get; set; }

        [StringLength (500)]
        public string Option2 { get; set; }

        [StringLength (500)]
        public string Option3 { get; set; }

        [StringLength (500)]
        public string Option4 { get; set; }

        public byte AnswerNO { get; set; }

        public bool IsExpired { get; set; }

        // Collection
        public ICollection<TblJustLoverWinner> TblJustLoverWinner { set; get; }
        public ICollection<TblJustLoverAnswers> TblJustLoverAnswers { set; get; }
    }
}