using System.Text.RegularExpressions;

namespace SFA.DAS.FrameworkHelpers;

public static partial class GeneratedRegexHelper
{
    [GeneratedRegex("/")]
    public static partial Regex UrlEscapeRegex();
}


public static partial class GenerateGuidRegexHelper
{
    [GeneratedRegex("[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}")]
    public static partial Regex FindGuidRegex();
}


public partial class ProjectNameRegexHelper
{
    [GeneratedRegex(@"SFA\.DAS\..*\.(DataPreparation|ServiceBusIntegration|PaymentProcess|API|UI|E2E|Smoke)Tests")]
    public static partial Regex ProjectNameRegex();
}
