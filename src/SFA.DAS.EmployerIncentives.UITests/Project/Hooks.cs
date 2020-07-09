using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    class Hooks
    {
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context)
        {
            _webDriver = context.GetWebDriver();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate() => _webDriver.Navigate().GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);
    }
}
