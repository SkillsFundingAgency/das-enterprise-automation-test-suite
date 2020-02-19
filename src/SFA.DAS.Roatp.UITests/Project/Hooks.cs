using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly RoatpConfig _config;
        private readonly ClearDownDataHelpers _clearDownDataHelpers;
        private RoatpUkprnDataHelpers _applyUkprnDataHelpers;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetRoatpConfig<RoatpConfig>();
            var sqlDatabaseConnectionHelper = context.Get<SqlDatabaseConnectionHelper>();
            _clearDownDataHelpers = new ClearDownDataHelpers(_objectContext, _config, sqlDatabaseConnectionHelper);
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() 
        {
            _applyUkprnDataHelpers = new RoatpUkprnDataHelpers();
            _context.Set(_applyUkprnDataHelpers);

            var applydatahelpers = new ApplyDataHelpers(_context.Get<RandomDataGenerator>());
            _context.Set(applydatahelpers);
        }

        [BeforeScenario(Order = 33)]
        public void GetData()
        {
            // every scenario (apply and admin) should only have one tag which starts with rp, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rp"));
            var (email, ukprn) = _applyUkprnDataHelpers.GetRoatpData(tag);

            _objectContext.SetEmail(email);
            _objectContext.SetUkprn(ukprn);
        }

        [BeforeScenario(Order = 34), Scope(Tag = "roatpapply")]
        public void ClearDownApplyData() => _clearDownDataHelpers.ClearDownDataFromQna(_clearDownDataHelpers.ClearDownDataFromApply());

        [BeforeScenario(Order = 34), Scope(Tag = "roatpadmin")]
        public void ClearDownAdminData() => _clearDownDataHelpers.DeleteTrainingProvider();

        [BeforeScenario(Order = 35), Scope(Tag = "roatpapply")]
        public void NavigateToRoatpApply() => GoToUrl(_config.ApplyBaseUrl);

        [BeforeScenario(Order = 35), Scope(Tag = "roatpadmin")]
        public void NavigateToRoatpAdmin() => GoToUrl(_config.AdminBaseUrl);

        private void GoToUrl(string url) => _webDriver.Navigate().GoToUrl(url);
    }
}
