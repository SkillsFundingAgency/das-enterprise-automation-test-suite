using System.Globalization;
using System.Text.RegularExpressions;

namespace SFA.DAS.FrameworkHelpers
{
    public static partial class StringExtension
    {
        public static bool ContainsCompareCaseInsensitive(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            var index = text?.IndexOf(value, stringComparison) ?? -1;
            return index >= 0;
        }

        public static bool CompareToIgnoreCase(this string strA, string strB) => string.Compare(strA.RemoveSpace(), strB, true) == 0;

        public static string RemoveSpace(this string s) => MyRegex().Replace(s, string.Empty);

        public static List<string> ToList(this string s, string seperator) => s?.Split(seperator).ToList().Select(x => x.Trim()).ToList();

        public static int ToInt(this string s) => int.Parse(s);

        public static string ToFirstLetterCaps(this string s) => string.IsNullOrEmpty(s) ? s : $"{s[0..1].ToUpperInvariant()}{s[1..].ToLowerInvariant()}";

        public static int? CurrencyStringToInt(this string s)
        {
            if (s == null)
            {
                return null;
            }

            // Remove currency symbol and comma
            string cleanedString = s.Replace("£", "").Replace(",", "");

            // Parse the cleaned string to an integer
            if (int.TryParse(cleanedString, NumberStyles.Currency, CultureInfo.InvariantCulture, out int amount))
            {
                return amount;
            }
            else
            {
                return null; // Parsing failed
            }
        }

        [GeneratedRegex(@"\s+")]
        private static partial Regex MyRegex();
    }
}