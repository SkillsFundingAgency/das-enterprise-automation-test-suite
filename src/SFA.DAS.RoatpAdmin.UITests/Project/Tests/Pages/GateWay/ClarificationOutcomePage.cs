using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class ClarificationOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Application action saved";

        private static By GoToRoATPGatewayApplicationsLink => By.LinkText("Go to RoATP gateway applications");

        public ClarificationOutcomePage(ScenarioContext context) : base(context) => VerifyPage();

        public GatewayLandingPage GoToRoATPGatewayApplicationsPage()
        {
            formCompletionHelper.Click(GoToRoATPGatewayApplicationsLink);
            return new GatewayLandingPage(context);
        }
    }
}
