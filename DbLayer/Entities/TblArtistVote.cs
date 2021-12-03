using System.ComponentModel.DataAnnotations.Schema;

// 
using DbLayer.Entities.Base;

namespace DbLayer.Entities {
    public class TblArtistVote : VoteEntity {
        public long ArtistId { get; set; }
        public long ArtistMovieRoleId { get; set; }

        [ForeignKey ("ArtistMovieRoleId")]
        public TblArtistMovieRole TblArtistMovieRole { get; set; }

    }
}