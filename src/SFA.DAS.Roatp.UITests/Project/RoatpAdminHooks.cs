using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding, Scope(Tag = "roatpadmin")]
    public class RoatpAdminHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly RoatpConfig _config;
        private readonly RoatpAdminClearDownDataHelpers _adminClearDownDataHelpers;
        private RoatpAdminUkprnDataHelpers _adminUkprnDataHelpers;

        public RoatpAdminHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetRoatpConfig<RoatpConfig>();
            var sqlDatabaseConnectionHelper = context.Get<SqlDatabaseConnectionHelper>();
            _adminClearDownDataHelpers = new RoatpAdminClearDownDataHelpers(_objectContext, _config, sqlDatabaseConnectionHelper);
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _adminUkprnDataHelpers = new RoatpAdminUkprnDataHelpers();
            _context.Set(_adminUkprnDataHelpers);

            _context.Set(new RoatpAdminDataHelpers());
        }

        [BeforeScenario(Order = 33)]
        public void GetRoatpAdminData()
        {
            // every scenario (admin) should only have one tag which starts with rpad, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rpad"));
            var (providername, ukprn) = _adminUkprnDataHelpers.GetRoatpAdminData(tag);

            _objectContext.SetProviderName(providername);
            _objectContext.SetUkprn(ukprn);
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownAdminData() => _adminClearDownDataHelpers.DeleteTrainingProvider();

        [BeforeScenario(Order = 35)]
        public void NavigateToRoatpAdmin() => _webDriver.Navigate().GoToUrl(_config.AdminBaseUrl);

    }
}
