using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;
using DbLayer.Enums;
using HpLayer.Extensions;

namespace DbLayer.Entities {
    public class TblVtyStarsWar : JLVSFBase {
        public TblVtyStarsWar () { }

        public string VideoUrl { get; set; }

        public VtyStarsWarType Type { get; set; }

        public VtyStarsWarSubject Subject { get; set; } = VtyStarsWarSubject.CinemaAndSerialNews;

        [NotMapped]
        public string TypeTitle =>
            EnumExtensions.GetDisplayName ((VtyStarsWarType) Type);

        [NotMapped]
        public string SubjectTitle =>
            EnumExtensions.GetDisplayName ((VtyStarsWarSubject) Subject);

        [StringLength (500)]
        public string KeyWord { get; set; }

        // Collection
        public ICollection<TblComment> TblComment { set; get; }

        public ICollection<TblVtyStarsWarTags> TblVtyStarsWarTags { set; get; }

        public ICollection<TblVtyStarsWarOptions> TblVtyStarsWarOptions { set; get; }
    }

    public class TblVtyStarsWarTags {
        public long TagsId { get; set; }
        public TblTags TblTags { get; set; }

        public long VtyStarsWarId { get; set; }
        public TblVtyStarsWar TblVtyStarsWar { get; set; }
    }
}