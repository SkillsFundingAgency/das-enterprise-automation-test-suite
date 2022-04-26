using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class CheckPageRetryHelper : RetryHelper
    {
        public CheckPageRetryHelper(IWebDriver webDriver, ScenarioInfo scenarioInfo) : base(webDriver, scenarioInfo, Logging.CheckPageTimeout())
        {

        }
    }
}