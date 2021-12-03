using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// 
using HpLayer.Extensions;

namespace Website.Helper.Utils {
    public static class ModelStateUtils {
        public static string ModelStateAsText (this ModelStateType type) {
            var display = type.GetDisplayName ();
            var description = type.GetDescription ();
            return _AsHtml (new string[] { description }, display);
        }

        public static string ModelStateAsError (this ModelStateDictionary modelState) {
            var display = ModelStateType.A400.GetDisplayName ();
            var items = modelState.Values.SelectMany (v => v.Errors)
                .Select (x => x.ErrorMessage).ToArray ();
            return _AsHtml (items, display);
        }

        private static string _AsHtml (string[] items, string cls) {
            var builder = new StringBuilder ();
            var html = $"<div class='alert alert-{cls} alert-dismissible fade show' role='alert'><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button><ul class='list-group list-group-flush'>";
            builder.AppendLine (html);
            foreach (var item in items) {
                builder.AppendLine ($"<li class='list-group-item'>{item}</li>");
            }
            return builder.AppendLine ("</ul></div>").ToString ();
        }
    }

    public enum ModelStateType {
        [Display (Name = "success")]
        [Description ("درخواست شما با موفقیت انجام گردید.")]
        A200,
        // 
        [Display (Name = "danger")]
        [Description ("درخواست شما با خطا مواجعه شد.")]
        A400,
        // 
        [Display (Name = "primary")]
        [Description ("")]
        AInfo,
        // 
        [Display (Name = "warning")]
        [Description ("")]
        AWarn
    }
}