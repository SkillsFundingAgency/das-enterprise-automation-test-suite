using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
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
        private readonly ObjectContext _objectContext;
        private readonly EPAOConfig _config;
        private readonly EPAOAdminConfig _adminconfig;
        private readonly IWebDriver _webDriver;
        private EPAOAdminDataHelper _ePAOAdminDataHelper;
        private EPAOAdminSqlDataHelper _ePAOAdminSqlDataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetEPAOConfig<EPAOConfig>();
            _adminconfig = context.GetEPAOAdminConfig<EPAOAdminConfig>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _context.Set(new EPAOSqlDataHelper(_config));

            _ePAOAdminSqlDataHelper = new EPAOAdminSqlDataHelper(_config);

            var r = _context.Get<RandomDataGenerator>();

            _context.Set(new EPAODataHelper(r));

            _ePAOAdminDataHelper = new EPAOAdminDataHelper(r);

            _context.Set(_ePAOAdminDataHelper);
        }

        [BeforeScenario(Order = 33)]
        public void Navigate()
        {
            if (_context.ScenarioInfo.Tags.Contains("epaoadmin")) { _webDriver.Navigate().GoToUrl(_adminconfig.AdminBaseUrl); }
        }

        [AfterScenario(Order = 32)]
        [Scope(Tag = "clearcontact")]
        public void ClearContact() => _ePAOAdminSqlDataHelper.DeleteContact(_ePAOAdminDataHelper.Email);

        [AfterScenario(Order = 33)]
        [Scope(Tag = "clearstandards")]
        public void ClearStandards() => _ePAOAdminSqlDataHelper.DeleteOrganisationStandard(_ePAOAdminDataHelper.Standards, _ePAOAdminDataHelper.OrganisationEpaoId);
    }
}
