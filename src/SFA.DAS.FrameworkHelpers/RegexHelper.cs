using System.Text.RegularExpressions;

namespace SFA.DAS.FrameworkHelpers
{
    public class RegexHelper
    {
        public static string TrimAnySpace(string value) => Regex.Replace(value, @"\s", string.Empty);
    }
}