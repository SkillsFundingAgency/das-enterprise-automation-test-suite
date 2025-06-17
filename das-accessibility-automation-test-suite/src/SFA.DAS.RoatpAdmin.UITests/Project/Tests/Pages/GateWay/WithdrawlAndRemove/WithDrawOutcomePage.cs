using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.WithdrawlAndRemove
{
    public class WithDrawOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Gateway Outcome";

        private static By GoToRoATPGatewayApplicationsLink => By.LinkText("Go to RoATP applications");

        public WithDrawOutcomePage(ScenarioContext context) : base(context) => VerifyPage();

        public GatewayLandingPage GoToRoATPGatewayApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPGatewayApplicationsLink);
            return new GatewayLandingPage(context);
        }
    }
}
