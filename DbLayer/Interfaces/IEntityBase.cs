using System;

namespace DbLayer.Interfaces {
    public interface IEntityBase {
        long Id { get; set; }
    }

    public interface IAuditEntity {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }

        string PersianCreatedDate { get; }
        string PersianUpdatedDate { get; }
    }

    public interface IAuditEntity<TKey> : IAuditEntity { }

    public interface IFileEntity {
        string FileUrl { get; set; }

        string ThumbnailsUrl { get; set; }
    }
}