using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;

namespace DbLayer.Entities {
    public class TblArtistMovieRole : BaseEntity {
        public TblArtistMovieRole () { }

        // Foreign key
        public long ArtistId { get; set; }

        [ForeignKey ("ArtistId")]
        public TblArtist TblArtist { get; set; }

        public long CinemaRoleId { get; set; }

        [ForeignKey ("CinemaRoleId")]
        public TblCinemaRole TblCinemaRole { get; set; }

        public long MovieId { get; set; }

        [ForeignKey ("MovieId")]
        public TblMovie TblMovie { get; set; }

        // Collection
        public ICollection<TblArtistVote> TblArtistVote { set; get; }
    }
}