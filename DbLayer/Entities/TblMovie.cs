using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

// 
using DbLayer.Entities.Base;
using DbLayer.Enums;
using HpLayer.Extensions;

namespace DbLayer.Entities {
    public class TblMovie : FileAuditEntity {
        private string _source;
        public TblMovie () { }

        [StringLength (500)]
        public string Title { get; set; }

        public byte Type { get; set; }

        [NotMapped]
        public MovieType MovieType { get; set; }

        [NotMapped]
        public string TypeTitle =>
            EnumExtensions.GetDisplayName ((JenreType) MovieType);

        public TimeSpan Interval { get; set; }

        [Column (TypeName = "smalldatetime")]
        public DateTime? ReleaseDate { get; set; }

        [StringLength (500)]
        public string KeyWord { get; set; }

        [Column (TypeName = "ntext")]
        public string Source {
            get { return WebUtility.HtmlDecode (_source); }
            set { _source = WebUtility.HtmlEncode (value); }
        }

        // Collection
        public ICollection<TblMovieTags> TblMovieTags { set; get; }

        public ICollection<TblMovieVote> TblMovieVote { set; get; }

        public ICollection<TblSerialInfo> TblSerialInfo { set; get; }

        public ICollection<TblMovieJenre> TblMovieJenre { set; get; }

        public ICollection<TblArtistMovieRole> TblArtistMovieRole { set; get; }
    }

    public class TblMovieJenre {
        public long JenreId { get; set; }
        public TblJenre TblJenre { get; set; }

        public long MovieId { get; set; }
        public TblMovie TblMovie { get; set; }
    }

    public class TblMovieTags {
        public long TagsId { get; set; }
        public TblTags TblTags { get; set; }

        public long MovieId { get; set; }
        public TblMovie TblMovie { get; set; }
    }
}