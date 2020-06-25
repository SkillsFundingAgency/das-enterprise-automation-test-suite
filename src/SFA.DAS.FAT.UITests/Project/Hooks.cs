using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context) => _webDriver = context.GetWebDriver();

        [BeforeScenario(Order = 21)]
        public void NavigateToFATHomepage() => _webDriver.Navigate().GoToUrl(UrlConfig.FAT_BaseUrl);
    }
}
