using System.Text.RegularExpressions;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RegexHelper
    {
        public string GetAccountId(string url)
        {
            Match match = Regex.Match(url, @"\/[A-Z0-9]{6}\/");

            return match.Success ? Regex.Replace(match.Value, @"\/", string.Empty) : url;
        }

        public string GetPublicAccountId(string url)
        {
            Match match = Regex.Match(url, @"Account ID: [A-Z0-9]{6}");

            return match.Success ? Regex.Replace(match.Value, @"Account ID:", string.Empty) : url;
        }

        public string GetCohortReference(string value)
        {
            Match match = Regex.Match(value, @"[A-Z0-9]{6}");

            return match.Success ? Regex.Replace(match.Value, @"\s", string.Empty) : value;
        }
    }
}