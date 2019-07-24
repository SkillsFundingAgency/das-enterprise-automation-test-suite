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
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _config;
        private readonly IWebDriver _webDriver;

        public ScenarioContext Context => _context;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.Get<FrameworkConfig>();
        }

        [BeforeScenario(Order = 20)]
        public void SetupCreateAccountConfiguration()
        {
            var config = Context.GetConfigSection<ProjectSpecificConfig>();
            Context.Set(new ProjectSpecificConfig { AccountUserName = config.AccountUserName, AccountPassword = config.AccountPassword });
        }


        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.BaseUrl;
            _webDriver.Navigate().GoToUrl(url);
        }
    }

    public class ProjectSpecificConfig
    {
        public string AccountUserName { get; set; }

        public string AccountPassword { get; set; }

        public string ConfirmCode { get; set; }

        public string GGUserId { get; set; }

        public string GGUserpassword { get; set; }
    }
}
