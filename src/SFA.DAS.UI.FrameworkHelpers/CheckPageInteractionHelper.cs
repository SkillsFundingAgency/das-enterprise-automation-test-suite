using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.FrameworkHelpers;

public class CheckPageInteractionHelper : PageInteractionHelper
{
    public CheckPageInteractionHelper(IWebDriver webDriver, ObjectContext objectContext, WebDriverWaitHelper webDriverWaitHelper, CheckPageRetryHelper retryHelper) 
        : base(webDriver, objectContext, webDriverWaitHelper, retryHelper)
    {

    }
}