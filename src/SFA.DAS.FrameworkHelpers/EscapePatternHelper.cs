using System.Text.RegularExpressions;

namespace SFA.DAS.FrameworkHelpers
{
    public static partial class EscapePatternHelper
    {
        private static readonly string[] chars = [".", "^", "$", "?", "(", ")", "[", "]", "{", "}", "\\", "|"];

        public static string DirectoryEscapePattern(string value) => MyRegex1().Replace(value, string.Empty);

        public static string FileEscapePattern(string value) => MyRegex().Replace(value, string.Empty);

        public static string StringEscapePattern(string value, string pattern) => Regex.Replace(value, StringEscapePattern(pattern), string.Empty);

        private static string StringEscapePattern(string pattern)
        {
            string escapedPattern = pattern;

            foreach (char x in pattern)
            {
                var y = x.ToString();

                if (chars.Any(c => c == y)) escapedPattern = escapedPattern.Replace(y, $"\\{x}");
            }

            return escapedPattern;
        }

        [GeneratedRegex(@"\\|/|:|\*|\?|<|>|\||""")]
        private static partial Regex MyRegex();
        
        [GeneratedRegex(@"<|>|:")]
        private static partial Regex MyRegex1();
    }
}