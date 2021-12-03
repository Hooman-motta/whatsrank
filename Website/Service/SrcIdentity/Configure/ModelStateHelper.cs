using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// 
using HpLayer.Helper;

namespace Website.Service.SrcIdentity.Configure {
    public static class ModelStateHelper {

        /// <summary>
        /// IdentityResult errors list to string
        /// </summary>
        public static string DumpErrors (this IdentityResult result, bool useHtmlNewLine = false) {
            var results = new StringBuilder ();
            if (!result.Succeeded) {
                foreach (var error in result.Errors) {
                    var errorDescription = error.Description;
                    if (string.IsNullOrWhiteSpace (errorDescription)) {
                        continue;
                    }
                    if (!useHtmlNewLine) {
                        results.AppendLine (errorDescription);
                    } else {
                        results.AppendLine ($"{errorDescription}<br/>");
                    }
                }
            }
            return results.ToString ();
        }

        public static void AddErrorsFromResult (this ModelStateDictionary modelState, IdentityResult result) {
            foreach (var error in result.Errors) {
                modelState.AddModelError ("", error.Description);
            }
        }

        public static ApiMessage[] ModelStateErrorAsApiResult (this ModelStateDictionary modelState) =>
            modelState.Values.SelectMany (v => v.Errors)
            .Select (x => new ApiMessage { Key = "", Value = x.ErrorMessage }).ToArray ();
    }
}