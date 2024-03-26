using System.Text.RegularExpressions;

namespace SFA.DAS.FrameworkHelpers;

public static partial class GeneratedRegexHelper
{
    [GeneratedRegex("/")]
    public static partial Regex UrlEscapeRegex();

}

public partial class ProjectNameRegexHelper
{
    [GeneratedRegex(@"SFA\.DAS\..*\.(Integration|PaymentProcess|API|UI|E2E)Tests")]
    public static partial Regex ProjectNameRegex();
}
