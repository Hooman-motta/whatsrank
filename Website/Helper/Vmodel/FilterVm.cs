using Microsoft.AspNetCore.Mvc;

namespace Website.Helper.Vmodel {
    public class BaseQs {
        /// <summary>
        /// default : 1
        /// </summary>
        [BindProperty]
        public short P { get; set; } = 1;

        /// <summary>
        /// default : Id
        /// </summary>
        [BindProperty]
        public string Order { get; set; } = "Id";

        /// <summary>
        /// asc or desc
        /// default : desc
        /// </summary>
        [BindProperty]
        public string Sort { get; set; } = "desc";
    }

    public class FilterQs : BaseQs {
        [BindProperty]
        public string Filter { get; set; } = null;
    }
}