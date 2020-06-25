using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
        }

        [BeforeScenario(Order = 34)]
        public void SetUpHelpers() => _context.Set(new CampaignsDataHelper(_context.Get<RandomDataGenerator>()));

        [BeforeScenario(Order = 36)]
        public void NavigateToBaseUrl() => _webDriver.Navigate().GoToUrl(UrlConfig.CA_BaseUrl);
    }
}
