using System.Text.RegularExpressions;

namespace SFA.DAS.FrameworkHelpers
{
    public partial class RegexHelper
    {
        public static string ReplaceMultipleSpace(string value) => Regex.Replace(value, @"\s+", " ");
    }
}