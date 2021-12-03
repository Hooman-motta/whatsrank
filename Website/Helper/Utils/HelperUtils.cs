using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Website.Helper.Utils {
    public static class StaticHelper {
        public static string ToFriendlyRoute (this object value) {
            if (value != null) {
                string text = value.ToString ();
                List<char> illegalChars = new List<char> () { ' ', '.', '#', '%', '&', '*', '{', '}', '\\', ':', '<', '>', '?', '/', ';', '@', '=', '+', '$', ',' };
                illegalChars.ForEach (c => {
                    text = text.Replace (c.ToString (), "-");
                });
                return text;
            }
            return null;
        }

        public static string ToFriendlyImage (this string value, DefaultImageType defaultImageType) {
            if (value != null && value != "") {
                return $"\\{value.ToString()}";
            }

            string url = @"/website/images/def/";
            switch (defaultImageType) {
                case DefaultImageType.DEF:
                    return $"{url}def.png";
                case DefaultImageType.DEF_AVATAR:
                    return $"{url}def-avatar.png";
                case DefaultImageType.DEF_MOVIIE:
                    return $"{url}def-movie.png";
                case DefaultImageType.DEF_MUSIC:
                    return $"{url}def-music.png";
                default:
                    return null;
            }
        }

        public static bool IsBITMAP (this IFormFile formFile) {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (!string.Equals (formFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (formFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase)) {
                return false;
            }
            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension (formFile.FileName);
            if (!string.Equals (postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals (postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)) {
                return false;
            }
            return true;
        }
    }
}