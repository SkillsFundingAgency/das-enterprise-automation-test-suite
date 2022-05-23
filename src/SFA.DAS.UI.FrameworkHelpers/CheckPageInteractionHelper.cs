using OpenQA.Selenium;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class CheckPageInteractionHelper : PageInteractionHelper
    {
        public CheckPageInteractionHelper(IWebDriver webDriver, WebDriverWaitHelper webDriverWaitHelper, CheckPageRetryHelper retryHelper) 
            : base(webDriver, webDriverWaitHelper, retryHelper)
        {

        }
    }
}