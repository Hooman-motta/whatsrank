using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;
using DbLayer.Enums;
using DbLayer.Identity;
using HpLayer.Extensions;

namespace DbLayer.Entities {
    public class TblCinemaRole : BaseEntity {
        public TblCinemaRole () { }

        [StringLength (500)]
        public string Title { get; set; }

        public byte Type { get; set; }

        [NotMapped]
        public CinemaRoleType CinemaRoleType => (CinemaRoleType) Type;

        [NotMapped]
        public string TypeTitle =>
            EnumExtensions.GetDisplayName ((CinemaRoleType) CinemaRoleType);

        // Foreign key
        [ForeignKey ("ParentId")]
        public TblCinemaRole Parent { get; set; }

        public long? ParentId { get; set; }

        // Collection
        public ICollection<TblUserCinemaRole> TblUserCinemaRole { set; get; }

        public ICollection<TblArtistMovieRole> TblArtistMovieRole { set; get; }

        public ICollection<TblArtistCinemaRole> TblArtistCinemaRole { set; get; }

    }
}