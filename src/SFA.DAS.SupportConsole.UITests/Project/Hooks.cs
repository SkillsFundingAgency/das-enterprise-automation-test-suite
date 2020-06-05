using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project
{
    [Binding]
    class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly SupportConsoleConfig _config;
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.SupportConsoleUrl;
            _webDriver.Navigate().GoToUrl(url);
        }
    }
}