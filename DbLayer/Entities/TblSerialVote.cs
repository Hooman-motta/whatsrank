using DbLayer.Entities.Base;

namespace DbLayer.Entities {
    public class TblSerialVote : VoteEntity {
        public long SerialInfoId { get; set; }

        public TblSerialInfo TblSerialInfo { get; set; }
    }
}