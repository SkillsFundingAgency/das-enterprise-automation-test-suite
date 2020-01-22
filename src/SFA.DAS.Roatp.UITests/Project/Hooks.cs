using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers;
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
        private readonly SqlDatabaseConnectionHelper _sqlDatabaseConnectionHelper;
        private ClearDownDataHelpers _clearDownDataHelpers;
        private ApplyDataHelpers _applyDataHelpers;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetRoatpConfig<RoatpConfig>();
            _sqlDatabaseConnectionHelper = context.Get<SqlDatabaseConnectionHelper>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _clearDownDataHelpers = new ClearDownDataHelpers(_config, _sqlDatabaseConnectionHelper);

            _context.Set(_clearDownDataHelpers);

            var random = _context.Get<RandomDataGenerator>();

            _applyDataHelpers = new ApplyDataHelpers(random);
        }

        [BeforeScenario(Order = 33), Scope(Tag = "rpe2e01")]
        public void ClearDownDataHelpers()
        {
            var tag = _context.ScenarioInfo.Tags.ToList().First(x => x.StartsWith("rp"));
            var (email, ukprn) = _applyDataHelpers.GetApplyData(tag);

            _objectContext.SetEmail(email);
            _objectContext.SetUkprn(ukprn);

            var applicationId = _clearDownDataHelpers.ClearDownDataFromApply(email);

            _clearDownDataHelpers.ClearDownDataFromQna(applicationId);
        }
        
        [BeforeScenario(Order = 34)]
        public void Navigate() => _webDriver.Navigate().GoToUrl(_config.ApplyBaseUrl);
    }
}
