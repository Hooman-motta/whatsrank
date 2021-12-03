using DbLayer.Interfaces;

namespace DbLayer.Entities.Base {
    public class FileEntity : BaseEntity, IFileEntity {
        public string FileUrl { get; set; }

        public string ThumbnailsUrl { get; set; }
    }

    public class FileAuditEntity : AuditEntity, IFileEntity {
        public string FileUrl { get; set; }

        public string ThumbnailsUrl { get; set; }
    }
}