using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.FrameworkHelpers;

public class CheckPageRetryHelper(IWebDriver webDriver, ScenarioInfo scenarioInfo, ObjectContext objectContext) : RetryHelper(webDriver, scenarioInfo, objectContext, RetryTimeOut.ShorterTimeout())
{
}