using OpenQA.Selenium;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project
{
    [Binding, Scope(Tag = "aprdsupport"), Scope(Tag = "aprdadmin")]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
        }

        [BeforeScenario(Order = 21)]
        public void NavigateToCovidSupportHomepage()
        {
            if (_context.ScenarioInfo.Tags.Contains("aprdsupport"))
                _webDriver.Navigate().GoToUrl(UrlConfig.AR_BaseUrl);
            else if (_context.ScenarioInfo.Tags.Contains("aprdadmin"))
                _webDriver.Navigate().GoToUrl(UrlConfig.AR_AdminBaseUrl);
        }

        [BeforeScenario(Order = 22)]
        public void SetUpHelpers() => _context.Set(new ApprenticeRedundancyDataHelper(_context.Get<RandomDataGenerator>()));

    }
}
