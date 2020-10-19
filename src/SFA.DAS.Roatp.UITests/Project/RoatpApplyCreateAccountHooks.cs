using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding, Scope(Tag = "roatpapplycreateaccount")]
    public class RoatpApplyCreateAccountHooks
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private readonly RoatpApplyContactSqlDbHelper _applyClearDownDataHelpers;
        private readonly RoatpConfig _config;
        protected readonly RoatpApplyDataHelpers _applydataHelpers;

        public RoatpApplyCreateAccountHooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetRoatpConfig<RoatpConfig>();
            _applydataHelpers = context.Get<RoatpApplyDataHelpers>();
            _applyClearDownDataHelpers = new RoatpApplyContactSqlDbHelper(_config);
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownApplyContactData() => _applyClearDownDataHelpers.DeleteContact(_applydataHelpers.Email);

        [BeforeScenario(Order = 36)]
        public void NavigateToRoatpApply() => _webDriver.Navigate().GoToUrl(UrlConfig.Apply_BaseUrl);
    }
}
