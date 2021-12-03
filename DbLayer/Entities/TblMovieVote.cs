// 
using DbLayer.Entities.Base;

namespace DbLayer.Entities {
    public class TblMovieVote : VoteEntity {
        public long MovieId { get; set; }

        public TblMovie TblMovie { get; set; }
    }
}