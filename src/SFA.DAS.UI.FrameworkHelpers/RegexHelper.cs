using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class RegexHelper
    {
        public static string ReplaceMultipleSpace(string value) => Regex.Replace(value, @"\s+", " ");

        public static int GetAmount(string value) => int.Parse(Replace(value, new List<string>() { "£", "," }));

        public static string Replace(string value, List<string> pattern) => TrimAnySpace(Regex.Replace(value, $@"{pattern.ToString("|")}", string.Empty));

        public static int GetMaxNoOfPages(string question)
        {
            var match = Regex.Match(question, @"of [0-9]*", RegexOptions.None);

            return int.Parse(TrimAnySpace(Regex.Replace(match.Value, @"of", string.Empty)));
        }

        public static string GetLevyBalance(string levybalance) => Regex.Replace(levybalance, @",|\.[0-9]*", string.Empty);

        public static (int,int) GetPayeChallenge(string question)
        {
            var matches = Regex.Matches(question, @"[0-9]{1}", RegexOptions.None);

            return (int.Parse(matches[0].Value), int.Parse(matches[1].Value));
        }

        public static string GetAccountId(string url)
        {
            Match match = Regex.Match(url, @"\/[A-Z0-9]{6}\/");

            return match.Success ? Regex.Replace(match.Value, @"\/", string.Empty) : url;
        }

        public static string GetPublicAccountId(string text)
        {
            Match match = Regex.Match(text, @"Account ID: [A-Z0-9]{6}");

            return match.Success ? TrimAnySpace(Regex.Replace(match.Value, @"Account ID:", string.Empty)) : text;
        }

        public static string GetApplicationReference(string value)
        {
            Match match = Regex.Match(value, @"[0-9]{6}");

            return match.Success ? TrimAnySpace(match.Value) : value;
        }

        public static string GetCohortReference(string value)
        {
            Match match = Regex.Match(value, @"[A-Z0-9]{6}");

            return match.Success ? TrimAnySpace(match.Value) : value;
        }

        public static string GetVacancyReference(string value)
        {
            string pattern = @"VAC|vac";

            Match match = Regex.Match(value, pattern);

            return match.Success ? (Regex.Replace(value, pattern, string.Empty))?.TrimStart('0') : value;
        }

        public static string GetVacancyCurrentWage(string value)
        {
            Match match = Regex.Match(value, @"£[1-9][0-9]{2}");

            return match.Success ? TrimAnySpace(Regex.Replace(match.Value, @"£", string.Empty)) : value;
        }

        public static string GetVacancyReferenceFromUrl(string url)
        {
            Match match = Regex.Match(url, @"vacancyReferenceNumber=[0-9]*");

            return match.Success ? Regex.Replace(match.Value, @"vacancyReferenceNumber|=", string.Empty) : url;
        }

        public static string GetEmployerERN(string url)
        {
            Match match = Regex.Match(url, @"edsUrn=[0-9]*&vacancyGuid=");

            return match.Success ? Regex.Replace(match.Value, @"edsUrn|&|vacancyGuid|=", string.Empty) : url;
        }

        public static string GetCohortReferenceFromUrl(string url)
        {
            string match(string action)
            {
                var x = CohortMatch(url, action);
                return x.Success ? Regex.Replace(x.Value, $"{action}|/", string.Empty) : null;
            }

            return match("apprentices") ?? match("unapproved") ?? url;
        }

        public static bool CheckForPercentageValueMatch(string str) => Regex.Match(str, "[0-9]{1,2}%").Success;

        private static Match CohortMatch(string url, string action) => Regex.Match(url, $@"{action}\/[A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9]");

        public static string TrimAnySpace(string value) => Regex.Replace(value, @"\s", string.Empty);
    }
}