// using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// 
using DbLayer.Entities.Base;

namespace DbLayer.Entities {
    public class TblArtist : FileEntity {
        public TblArtist () { }

        [StringLength (50)]
        public string FullName { get; set; }

        [StringLength (500)]
        public string KeyWord { get; set; }

        // [StringLength (50)]
        // public string Nationality { get; set; }

        public string Bio { get; set; }

        public DateTime? BirthDate { get; set; }

        // Collection
        public ICollection<TblArtistMovieRole> TblArtistMovieRole { set; get; }

        public ICollection<TblArtistCinemaRole> TblArtistCinemaRole { set; get; }
    }

    public class TblArtistCinemaRole {
        public long ArtistId { get; set; }
        public TblArtist TblArtist { get; set; }

        public long CinemaRoleId { get; set; }
        public TblCinemaRole TblCinemaRole { get; set; }
    }
}