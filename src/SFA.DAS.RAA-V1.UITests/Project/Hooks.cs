using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetRAAV1Config<RAAV1Config>();
        }

        [BeforeScenario(Order = 31)]
        public void Navigate()
        {
            var url = _config.RecruitBaseUrl;
            _webDriver.Navigate().GoToUrl(url);
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var regexHelper = _context.Get<RegexHelper>();

            _context.Set(new RAAV1DataHelper(random, regexHelper));
        }
    }
}
