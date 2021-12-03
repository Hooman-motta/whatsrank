using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HpLayer.Extensions {
    public static class EnumExtensions {
        public static string GetDisplayName (this Enum enumType) {
            return enumType.GetType ()
                .GetMember (enumType.ToString ())
                .FirstOrDefault ()?.GetCustomAttribute<DisplayAttribute> (false)?.Name ?? enumType.ToString ();
        }

        public static string GetDescription (this Enum enumType) {
            return enumType.GetType ()
                .GetMember (enumType.ToString ())
                .FirstOrDefault ()?.GetCustomAttribute<DescriptionAttribute> (false)?.Description ?? enumType.ToString ();
        }

        public static SelectList ToSelectList<TEnum> (this TEnum obj, object selectedValue = null)
        where TEnum : struct, IComparable, IFormattable, IConvertible {
            return new SelectList (Enum.GetValues (typeof (TEnum)).OfType<Enum> ()
                .Select (x =>
                    new SelectListItem {
                        Text = x.GetDisplayName (),
                            Value = (Convert.ToInt32 (x)).ToString ()
                    }), "Value", "Text", selectedValue);
        }
    }
}