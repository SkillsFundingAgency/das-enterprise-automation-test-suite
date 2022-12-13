using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SFA.DAS.FrameworkHelpers
{
    public static class StringExtension
    {
        public static bool ContainsCompareCaseInsensitive(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            var index = text?.IndexOf(value, stringComparison) ?? -1;
            return index >= 0;
        }

        public static bool CompareToIgnoreCase(this string strA, string strB) => string.Compare(strA.RemoveSpace(), strB, true) == 0;

        public static string RemoveSpace(this string s) => Regex.Replace(s, @"\s+", string.Empty);

        public static List<string> ToList(this string s, string seperator) => s?.Split(seperator).ToList().Select(x => x.Trim()).ToList();

        public static int ToInt(this string s) => int.Parse(s);

        public static string ToFirstLetterCaps(this string s) => string.IsNullOrEmpty(s) ? s : $"{s[..0].ToUpperInvariant()}{s[1..].ToLowerInvariant()}";
    }
}