using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.FrameworkHelpers;

public static class FindBrowserHelper
{
    public static bool IsCloudExecution(this string browser) => browser.CompareToIgnoreCase("browserstack") || browser.CompareToIgnoreCase("cloud");

    public static bool IsZap(this string browser) => browser.CompareToIgnoreCase("zapProxyChrome");

    public static bool IsEdge(this string browser) => browser.CompareToIgnoreCase("edge") || browser.CompareToIgnoreCase("microsoftedge");

    public static bool IsFirefox(this string browser) => browser.CompareToIgnoreCase("firefox") || browser.CompareToIgnoreCase("mozillafirefox");

    public static bool IsChrome(this string browser) => browser.CompareToIgnoreCase("chrome") || browser.CompareToIgnoreCase("googlechrome") || browser.CompareToIgnoreCase("local");

    public static bool IsChromeHeadless(this string browser) => browser.CompareToIgnoreCase("chromeheadless") || browser.CompareToIgnoreCase("headlessbrowser") || browser.CompareToIgnoreCase("headless");
}