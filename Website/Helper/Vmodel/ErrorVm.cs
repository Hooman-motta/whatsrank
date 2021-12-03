using System;

namespace Website.Helper.Vmodel {
    public class ErrorVm {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty (RequestId);
    }
}