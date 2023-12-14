using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SFA.DAS.UI.FrameworkHelpers;

public partial class RegexHelper
{
    public static string ReplaceMultipleSpace(string value) => MyRegex1().Replace(value, " ");

    public static int GetAmount(string value) => int.Parse(Replace(value, ["£", ","]));

    public static string Replace(string value, List<string> pattern) => TrimAnySpace(Regex.Replace(value, $@"{pattern.ToString("|")}", string.Empty));

    public static int GetMaxNoOfPages(string question)
    {
        var match = MyRegex2().Match(question);

        return int.Parse(TrimAnySpace(MyRegex3().Replace(match.Value, string.Empty)));
    }

    public static string GetLevyBalance(string levybalance) => MyRegex4().Replace(levybalance, string.Empty);

    public static (int, int) GetPayeChallenge(string question)
    {
        var matches = MyRegex5().Matches(question);

        return (int.Parse(matches[0].Value), int.Parse(matches[1].Value));
    }

    public static string GetApplicationReference(string value)
    {
        Match match = MyRegex6().Match(value);

        return match.Success ? TrimAnySpace(match.Value) : value;
    }

    public static string GetCohortReference(string value)
    {
        Match match = MyRegex7().Match(value);

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
        Match match = MyRegex17().Match(value);

        return match.Success ? TrimAnySpace(MyRegex18().Replace(match.Value, string.Empty)) : value;
    }

    public static string GetVacancyReferenceFromUrl(string url)
    {
        Match match = MyRegex8().Match(url);

        return match.Success ? MyRegex9().Replace(match.Value, string.Empty) : url;
    }

    public static string GetEmployerERN(string url)
    {
        Match match = MyRegex10().Match(url);

        return match.Success ? MyRegex11().Replace(match.Value, string.Empty) : url;
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

    public static bool CheckForPercentageValueMatch(string str) => MyRegex12().Match(str).Success;

    private static Match CohortMatch(string url, string action) => Regex.Match(url, $@"{action}\/[A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9]");

    public static string TrimAnySpace(string value) => string.IsNullOrEmpty(value) ? string.Empty : MyRegex19().Replace(value, string.Empty);

    [GeneratedRegex(@"\s+")]
    private static partial Regex MyRegex1();

    [GeneratedRegex(@"of [0-9]*", RegexOptions.None)]
    private static partial Regex MyRegex2();

    [GeneratedRegex(@"of")]
    private static partial Regex MyRegex3();

    [GeneratedRegex(@",|\.[0-9]*")]
    private static partial Regex MyRegex4();

    [GeneratedRegex(@"[0-9]{1}", RegexOptions.None)]
    private static partial Regex MyRegex5();

    [GeneratedRegex(@"[0-9]{6}")]
    private static partial Regex MyRegex6();

    [GeneratedRegex(@"[A-Z0-9]{6}")]
    private static partial Regex MyRegex7();

    [GeneratedRegex(@"vacancyReferenceNumber=[0-9]*")]
    private static partial Regex MyRegex8();

    [GeneratedRegex(@"vacancyReferenceNumber|=")]
    private static partial Regex MyRegex9();

    [GeneratedRegex(@"edsUrn=[0-9]*&vacancyGuid=")]
    private static partial Regex MyRegex10();

    [GeneratedRegex(@"edsUrn|&|vacancyGuid|=")]
    private static partial Regex MyRegex11();

    [GeneratedRegex(@"£[1-9][0-9]{2}")]
    private static partial Regex MyRegex17();

    [GeneratedRegex(@"£")]
    private static partial Regex MyRegex18();

    [GeneratedRegex(@"\s")]
    private static partial Regex MyRegex19();

    [GeneratedRegex("[0-9]{1,2}%")]
    private static partial Regex MyRegex12();
}