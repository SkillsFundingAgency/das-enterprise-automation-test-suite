using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.Service.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class GatewayLandingPage(ScenarioContext context) : RoatpGateWayBasePage(context)
    {
        protected override string PageTitle => "RoATP gateway applications";

        protected override By OutcomeTab => By.CssSelector("a[href='/Roatp/Gateway/Closed']");
        private static By InProgressTab => By.CssSelector("a[href='/Roatp/Gateway/InProgress']");

        public GWApplicationOverviewPage SelectApplication()
        {
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new GWApplicationOverviewPage(context);
        }
        public new GatewayLandingPage VerifyOutcomeStatus(string expectedStatus)
        {
            base.VerifyOutcomeStatus(expectedStatus);
            return new GatewayLandingPage(context);
        }
        public GatewayLandingPage SelectInProgressTab()
        {
            formCompletionHelper.ClickElement(InProgressTab);
            return new GatewayLandingPage(context);
        }
        public GatewayLandingPage SelectInOutcomeTab_Gateway()
        {
            formCompletionHelper.ClickElement(OutcomeTab);
            return new GatewayLandingPage(context);
        }
        public GatewayLandingPage ClearSearchResult_OutcomeTab()
        {
            formCompletionHelper.ClickElement(OutcomeTab);
            return new GatewayLandingPage(context);
        }
        public ReadOnlyGatewayOutcomePage SelectApplicationFromOutcomeTab()
        {
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ReadOnlyGatewayOutcomePage(context);
        }
        public GatewayLandingPage ConfirmGatewaySearchByName()
        {
            SearchProviderByName();
            return this;
        }
        public GatewayLandingPage ConfirmGatewaySearchByUkprn()
        {
            SearchProviderByUKPRN();
            return this;
        }
    }
}
