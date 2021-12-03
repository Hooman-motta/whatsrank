using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace DbLayer.Entities.Base {
    public abstract class JLVSFBase : FileAuditEntity {

        [StringLength (500)]
        public string Title { get; set; }

        [StringLength (2000)]
        public string Question { get; set; }

        private string _source;

        [Column (TypeName = "ntext")]
        public string Source {
            get { return WebUtility.HtmlDecode (_source); }
            set { _source = WebUtility.HtmlEncode (value); }
        }
    }
}