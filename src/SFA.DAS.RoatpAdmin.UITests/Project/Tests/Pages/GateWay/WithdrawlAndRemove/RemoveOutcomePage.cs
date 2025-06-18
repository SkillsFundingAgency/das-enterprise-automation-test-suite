using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.WithdrawlAndRemove
{
    public class RemoveOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Application removed";

        private static By GoToRoATPGatewayApplicationsLink => By.LinkText("Go to RoATP applications");

        public RemoveOutcomePage(ScenarioContext context) : base(context) => VerifyPage();

        public GatewayLandingPage GoToRoATPGatewayApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPGatewayApplicationsLink);
            return new GatewayLandingPage(context);
        }
    }
}
