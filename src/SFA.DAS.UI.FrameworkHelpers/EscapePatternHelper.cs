using System.Linq;
using System.Text.RegularExpressions;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class EscapePatternHelper
    {
        private static readonly string[] chars = new string[] { ".", "^", "$", "?", "(", ")", "[", "]", "{", "}", "\\", "|" };

        public static string DirectoryEscapePattern(string value) => Regex.Replace(value, @"<|>|:", string.Empty);

        public static string StringEscapePattern(string value, string pattern) => Regex.Replace(value, StringEscapePattern(pattern), string.Empty);

        private static string StringEscapePattern(string pattern)
        {
            string escapedPattern = pattern;
            foreach (char x in pattern)
            {
                var y = x.ToString();
                if (chars.Any(c => c == y))
                {
                    escapedPattern = escapedPattern.Replace(y, $"\\{x}");
                }
            }
            return escapedPattern;
        }
    }
}