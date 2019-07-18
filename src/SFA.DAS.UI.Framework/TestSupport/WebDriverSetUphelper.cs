using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class WebDriverSetupHelper
    {
        public static bool IsCloudExecution(this string browser)
        {
            return browser.CompareToIgnoreCase("browserstack") || browser.CompareToIgnoreCase("cloud");
        }

        public static bool IsZap(this string browser)
        {
            return browser.CompareToIgnoreCase("zapProxyChrome");
        }

        public static bool IsIe(this string browser)
        {
            return browser.CompareToIgnoreCase("ie") || browser.CompareToIgnoreCase("internetexplorer");
        }

        public static bool IsFirefox(this string browser)
        {
            return browser.CompareToIgnoreCase("firefox") || browser.CompareToIgnoreCase("mozillafirefox"); 
        }

        public static bool IsChrome(this string browser)
        {
            return browser.CompareToIgnoreCase("chrome") || browser.CompareToIgnoreCase("googlechrome") || browser.CompareToIgnoreCase("local");
        }

        public static bool IsChromeHeadless(this string browser)
        {
            return browser.CompareToIgnoreCase("chromeheadless") || browser.CompareToIgnoreCase("headlessbrowser") || browser.CompareToIgnoreCase("headless");
        }

        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            context.Set(webDriver, "webdriver");
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return context.Get<IWebDriver>("webdriver");
        }
    }
}

