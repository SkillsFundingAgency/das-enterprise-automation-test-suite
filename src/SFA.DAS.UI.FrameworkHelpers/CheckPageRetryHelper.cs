using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.FrameworkHelpers;

public class CheckPageRetryHelper : RetryHelper
{
    public CheckPageRetryHelper(IWebDriver webDriver, ScenarioInfo scenarioInfo, ObjectContext objectContext) : base(webDriver, scenarioInfo, objectContext, RetryTimeOut.ShorterTimeout())
    {

    }
}