using OpenQA.Selenium;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private readonly ApprenticeRedundancyConfig _config;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetARConfig<ApprenticeRedundancyConfig>();
        }

        [BeforeScenario(Order = 21)]
        public void NavigateToCovidSupportHomepage() => _webDriver.Navigate().GoToUrl(_config.AR_BaseUrl);

        [BeforeScenario(Order = 22)]
        public void SetUpHelpers()
        {
            _context.Set(new ApprenticeRedundancyDataHelper(_context.Get<RandomDataGenerator>()));

        }
    }
}
