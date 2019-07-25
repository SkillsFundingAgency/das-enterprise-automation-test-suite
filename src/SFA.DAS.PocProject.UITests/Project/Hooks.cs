using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly FrameworkConfig _config;
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context)
        {
            _webDriver = context.GetWebDriver();
            _config = context.Get<FrameworkConfig>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.BaseUrl;
            _webDriver.Navigate().GoToUrl(url);
        }
    }
}
