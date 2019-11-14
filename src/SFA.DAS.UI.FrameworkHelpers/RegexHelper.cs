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

        public bool CheckVacancyTitle(string value)
        {
            var match = Regex.Match(value, @"_[0-9]{2}[A-Z][a-z]{2}20[1-9]{2}_[0-9]{6}");

            return match.Success;
        }

        public string GetVacancyReference(string value)
        {
            string pattern = @"VAC|vac";

            Match match = Regex.Match(value, pattern);

            return match.Success ? (Regex.Replace(value, pattern, string.Empty))?.TrimStart('0') : value;
        }

        public string GetVacancyCurrentWage(string value)
        {
            Match match = Regex.Match(value, @"£[1-9][0-9]{2}");

            return match.Success ? TrimAnySpace(Regex.Replace(match.Value, @"£", string.Empty)) : value;
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