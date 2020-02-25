using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding, Scope(Tag = "roatpapply")]
    public class RoatpApplyHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly RoatpConfig _config;
        private readonly RoatpApplyClearDownDataHelpers _applyClearDownDataHelpers;
        private RoatpApplyUkprnDataHelpers _applyUkprnDataHelpers;

        public RoatpApplyHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
            _config = context.GetRoatpConfig<RoatpConfig>();
            var sqlDatabaseConnectionHelper = context.Get<SqlDatabaseConnectionHelper>();
            _applyClearDownDataHelpers = new RoatpApplyClearDownDataHelpers(_objectContext, _config, sqlDatabaseConnectionHelper);
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() 
        {
            _applyUkprnDataHelpers = new RoatpApplyUkprnDataHelpers();
            _context.Set(_applyUkprnDataHelpers);

            _context.Set(new RoatpApplyDataHelpers(_context.Get<RandomDataGenerator>()));
        }

        [BeforeScenario(Order = 33)]
        public void GetRoatpAppplyData()
        {
            // every scenario (apply) should only have one tag which starts with rp, which is mapped to the test data.
            var tag = _context.ScenarioInfo.Tags.ToList().Single(x => x.StartsWith("rp"));
            var (email, ukprn) = _applyUkprnDataHelpers.GetRoatpAppplyData(tag);

            _objectContext.SetEmail(email);
            _objectContext.SetUkprn(ukprn);
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownApplyData() => _applyClearDownDataHelpers.ClearDownDataFromQna(_applyClearDownDataHelpers.ClearDownDataFromApply());

        [BeforeScenario(Order = 35)]
        public void WhiteListProviders() => _applyClearDownDataHelpers.WhiteListProviders();

        [BeforeScenario(Order = 36)]
        public void NavigateToRoatpApply() => _webDriver.Navigate().GoToUrl(_config.ApplyBaseUrl);
    }
}
