using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private readonly FATConfig _config;
        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetFATConfig<FATConfig>();          
        }
        [BeforeScenario(Order = 21)]
        public void NavigateToFATHomepage()
        {
            var url = _config.FATUrl;
            _webDriver.Navigate().GoToUrl(url);
        }
    }
}
