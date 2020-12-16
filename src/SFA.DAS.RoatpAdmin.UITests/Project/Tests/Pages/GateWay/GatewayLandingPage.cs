using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class GatewayLandingPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "RoATP gateway applications";

        protected override By OutcomeTab => By.CssSelector("a[href='/Roatp/Gateway/Closed']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GatewayLandingPage(ScenarioContext context) : base(context) => _context = context;

        public GWApplicationOverviewPage SelectApplication()
        {
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new GWApplicationOverviewPage(_context);
        }

        public new GatewayLandingPage VerifyOutcomeStatus(string expectedStatus)
        {
            base.VerifyOutcomeStatus(expectedStatus);
            return new GatewayLandingPage(_context);
        }
    }
}
