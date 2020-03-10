using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly EPAOConfig _config;
        private readonly EPAOAdminConfig _adminconfig;
        private readonly IWebDriver _webDriver;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetEPAOConfig<EPAOConfig>();
            _adminconfig = context.GetEPAOAdminConfig<EPAOAdminConfig>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _context.Set(new EPAOSqlDataHelper(_config));

            _context.Set(new EPAODataHelper(_context.Get<RandomDataGenerator>()));

            _context.Set(new EPAOAdminDataHelper());

        }

        [BeforeScenario(Order = 33)]
        public void Navigate()
        {
            if (_context.ScenarioInfo.Tags.Contains("epaoadmin")) { _webDriver.Navigate().GoToUrl(_adminconfig.AdminBaseUrl); }
        }
    }
}
