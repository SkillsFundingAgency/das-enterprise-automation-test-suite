using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.FrameworkHelpers;

public class CheckPageInteractionHelper(IWebDriver webDriver, ObjectContext objectContext, WebDriverWaitHelper webDriverWaitHelper, CheckPageRetryHelper retryHelper) : PageInteractionHelper(webDriver, objectContext, webDriverWaitHelper, retryHelper)
{
}