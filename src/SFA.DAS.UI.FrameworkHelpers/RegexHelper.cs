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

        public string GetPublicAccountId(string text)
        {
            Match match = Regex.Match(text, @"Account ID: [A-Z0-9]{6}");

            return match.Success ? TrimAnySpace(Regex.Replace(match.Value, @"Account ID:", string.Empty)) : text;
        }

        public string GetCohortReference(string value)
        {
            Match match = Regex.Match(value, @"[A-Z0-9]{6}");

            return match.Success ? TrimAnySpace(match.Value) : value;
        }

        public string GetVacancyReference(string value)
        {
            string pattern = @"VAC|vac";

            Match match = Regex.Match(value, pattern);

            return match.Success ? (Regex.Replace(value, pattern, string.Empty))?.TrimStart('0') : value;
        }

        public string GetVacancyReferenceFromUrl(string url)
        {
            Match match = Regex.Match(url, @"vacancyReferenceNumber=[0-9]*");

            return match.Success ? Regex.Replace(match.Value, @"vacancyReferenceNumber|=", string.Empty) : url;
        }

        public string GetEmployerERN(string url)
        {
            Match match = Regex.Match(url, @"edsUrn=[0-9]*&vacancyGuid=");

            return match.Success ? Regex.Replace(match.Value, @"edsUrn|&|vacancyGuid|=", string.Empty) : url;
        }

        public string GetCohortReferenceFromUrl(string url)
        {
            Match match = Regex.Match(url, @"apprentices\/[A-Z0-9]{6}\/");

            return match.Success ? Regex.Replace(match.Value, @"apprentices|\/", string.Empty) : url;
        }

        private string TrimAnySpace(string value)
        {
            return Regex.Replace(value, @"\s", string.Empty);
        }
    }
}