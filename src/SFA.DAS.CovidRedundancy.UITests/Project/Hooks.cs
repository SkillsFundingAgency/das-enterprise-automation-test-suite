using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.CovidRedundancy.UITests.Project
{
    [Binding ]
    public class Hooks
    {
        private readonly IWebDriver _webDriver;
        private readonly CRConfig _config;

        public Hooks(ScenarioContext context)
        {
            _webDriver = context.GetWebDriver();
            _config = context.GetCRConfig<CRConfig>();
        }

        [BeforeScenario(Order = 21)]
        public void NavigateToCovidSupportHomepage() => _webDriver.Navigate().GoToUrl(_config.CRUrl);
    }
}
