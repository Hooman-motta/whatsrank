using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;
using DbLayer.Enums;
using HpLayer.Extensions;

namespace DbLayer.Entities {
    public class TblJenre : BaseEntity {
        public TblJenre () { }

        [StringLength (50)]
        public string Title { get; set; }

        public JenreType Type { get; set; }

        // [NotMapped]
        // public string TypeTitle =>
        //     EnumExtensions.GetDisplayName ((JenreType) Type);

        // Collection
        public ICollection<TblMovieJenre> TblMovieJenre { set; get; }
    }
}