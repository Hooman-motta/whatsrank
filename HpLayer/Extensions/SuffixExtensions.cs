using System;

namespace HpLayer.Extensions {
    public static class SuffixExtensions {
        static readonly string[] SizeSuffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string SizeSuffix (this long value, int decimalPlaces = 1) {
            if (value < 0) { return "-" + SizeSuffix (-value); }

            int i = 0;
            decimal dValue = (decimal) value;
            while (Math.Round (dValue, decimalPlaces) >= 1000) {
                dValue /= 1024;
                i++;
            }
            return string.Format ("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
        }
    }
}