using System;

namespace HpLayer.Helper {
    public static class NumberHelper {
        public static string Init (byte number) {
            switch (number) {
                case byte n when n < 10:
                    return Get_1_9 (n);
                case byte n when n >= 10 && n < 20:
                    return Get_10_19 (n);
                case byte n when n >= 20 && n < 100:
                    byte[] arr = { 20, 30, 40, 50, 60, 70, 80, 90 };

                    if (Array.Exists (arr, x => x == n)) {
                        return Get_20_99 (n);
                    }
                    int decade = (n / 10) * 10;
                    int oneToNine = (n / 10) + (n % 10);
                    return $"{Get_20_99 ((byte) decade)}-{Get_1_9 ((byte) oneToNine)}";
                default:
                    break;
            }

            return "";
        }

        private static string Get_1_9 (byte number) {
            string title = "";
            switch (number) {
                case 1:
                    title = "یک";
                    break;
                case 2:
                    title = "دو";
                    break;
                case 3:
                    title = "سه";
                    break;
                case 4:
                    title = "چهار";
                    break;
                case 5:
                    title = "پنج";
                    break;
                case 6:
                    title = "شش";
                    break;
                case 7:
                    title = "هفت";
                    break;
                case 8:
                    title = "هشت";
                    break;
                case 9:
                    title = "نه";
                    break;
                default:
                    break;
            }
            return title;
        }

        private static string Get_10_19 (byte number) {
            string title = "";
            switch (number) {
                case 10:
                    title = "ده";
                    break;
                case 11:
                    title = "یازده";
                    break;
                case 12:
                    title = "دوازده";
                    break;
                case 13:
                    title = "سیزده";
                    break;
                case 14:
                    title = "چهارده";
                    break;
                case 15:
                    title = "پانزده";
                    break;
                case 16:
                    title = "شانزده";
                    break;
                case 17:
                    title = "هفده";
                    break;
                case 18:
                    title = "هیجده";
                    break;
                case 19:
                    title = "نوزده";
                    break;
                default:
                    break;
            }
            return title;
        }

        private static string Get_20_99 (byte number) {
            string title = "";
            switch (number) {
                case 20:
                    title = "بیست";
                    break;
                case 30:
                    title = "سی";
                    break;
                case 40:
                    title = "چهل";
                    break;
                case 50:
                    title = "پنجاه";
                    break;
                case 60:
                    title = "شصت";
                    break;
                case 70:
                    title = "هفتاد";
                    break;
                case 80:
                    title = "هشتاد";
                    break;
                case 90:
                    title = "نود";
                    break;
                default:
                    break;
            }
            return title;
        }
    }
}