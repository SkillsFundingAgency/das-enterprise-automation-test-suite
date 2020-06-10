using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
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
        private readonly IWebDriver _webDriver;
        private EPAOAdminDataHelper _ePAOAdminDataHelper;
        private EPAOAdminSqlDataHelper _ePAOAdminSqlDataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetEPAOConfig<EPAOConfig>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _context.Set(new EPAOSqlDataHelper(_config));

            _ePAOAdminSqlDataHelper = new EPAOAdminSqlDataHelper(_config);

            _context.Set(_ePAOAdminSqlDataHelper);

            var r = _context.Get<RandomDataGenerator>();

            _context.Set(new EPAOAssesmentServiceDataHelper(r));

            _context.Set(new EPAOApplyDataHelper(r));

            _context.Set(new EPAOApplyStandardDataHelper(r));

            _ePAOAdminDataHelper = new EPAOAdminDataHelper(r);

            _context.Set(_ePAOAdminDataHelper);
        }

        [BeforeScenario(Order = 33)]
        [Scope(Tag = "deleteorganisationstandards")]
        public void ClearStandards() => _ePAOAdminSqlDataHelper.DeleteOrganisationStandard(_ePAOAdminDataHelper.Standards, _ePAOAdminDataHelper.OrganisationEpaoId);

        [BeforeScenario(Order = 34)]
        public void Navigate()
        {
            if (_context.ScenarioInfo.Tags.Contains("epaoadmin")) { _webDriver.Navigate().GoToUrl(_config.AdminBaseUrl); }
        }

        [AfterScenario(Order = 32)]
        [Scope(Tag = "deleteorganisationcontact")]
        public void ClearContact() => _ePAOAdminSqlDataHelper.DeleteContact(_ePAOAdminDataHelper.Email);

        [AfterScenario(Order = 33)]
        [Scope(Tag = "deleteorganisation")]
        public void ClearOrganisation() => _ePAOAdminSqlDataHelper.DeleteOrganisation(_ePAOAdminDataHelper.NewOrganisationUkprn);

        [AfterScenario(Order = 34)]
        [Scope(Tag = "makeorganisationlive")]
        public void MakeOrganisationLive() => _ePAOAdminSqlDataHelper.UpdateOrgStatusToLive(_ePAOAdminDataHelper.MakeLiveOrganisationEpaoId);
    }
}
