using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ASK.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _webDriver;
        private readonly AskConfig _config;

        public Hooks(ScenarioContext context)
        {
            _webDriver = context.GetWebDriver();
            _config = context.GetAskConfig<AskConfig>();
        }

        [BeforeScenario(Order = 36)]
        public void NavigateToBaseUrl() => _webDriver.Navigate().GoToUrl(_config.Ask_BaseUrl);
    }
}
