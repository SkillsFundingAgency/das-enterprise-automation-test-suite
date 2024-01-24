using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.UI.FrameworkHelpers;

public class CheckPageInteractionHelper(IWebDriver webDriver, ObjectContext objectContext, WebDriverWaitHelper webDriverWaitHelper, CheckPageRetryHelper retryHelper) : PageInteractionHelper(webDriver, objectContext, webDriverWaitHelper, retryHelper)
{
    public void UpdateTimeSpans(TimeSpan[] timeSpan) => retryHelper.UpdateTimeSpans(timeSpan);
}