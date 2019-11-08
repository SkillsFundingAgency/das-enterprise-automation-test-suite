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

        public string GetEmployerERN(string url)
        {
            Match match = Regex.Match(url, @"edsUrn=[0-9]*&vacancyGuid=");

            return match.Success ? Regex.Replace(match.Value, @"edsUrn|&|vacancyGuid|=", string.Empty) : url;
        }

        public string GetCohortReferenceFromUrl(string url)
        {
            string match(string action)
            {
                var x = CohortMatch(url, action);
                return x.Success ? Regex.Replace(x.Value, $"{action}|/", string.Empty) : null;
            }

            return match("apprentices") ?? match("unapproved") ?? url;
        }

        private string TrimAnySpace(string value) => Regex.Replace(value, @"\s", string.Empty);

        private Match CohortMatch(string url, string action) 
        {
            return Regex.Match(url, $@"{action}\/[A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9]");
        }
    }
}