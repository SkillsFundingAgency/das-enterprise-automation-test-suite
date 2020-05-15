using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class GwAdminSteps
    {
        private readonly ScenarioContext _context;
        private readonly RoatpAdminLoginStepsHelper _loginStepsHelper;
        private readonly StaffDashboardPage _staffDashboardPage;
        private readonly GatewayEndtoEndStepsHelpers _gatewayEndToEndStepsHelpers;
        private GWApplicationOverviewPage _gWApplicationOverviewPage;
      //  private FinalConfirmationPage _finalConfirmationPage;

        public GwAdminSteps(ScenarioContext context)
        {
            _context = context;
            _loginStepsHelper = new RoatpAdminLoginStepsHelper(_context);
            _gatewayEndToEndStepsHelpers = new GatewayEndtoEndStepsHelpers(_context);
        }

        [Given(@"the admin lands on the Dashboard")]
        public void GivenTheAdminLandsOnTheDashboard() => GoToRoatpStaffDashBoardPage();

        private StaffDashboardPage GoToRoatpStaffDashBoardPage()
        {
            _loginStepsHelper.SubmitValidLoginDetails();
            return new StaffDashboardPage(_context);
        }

        [When(@"the admin access the GatewayApplications")]
        public void WhenTheAdminAccessTheGatewayApplications() => _staffDashboardPage.AccessGatewayApplications().SelectingNewApplication();

        [When(@"the gateway admin assess all sections as PASS")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASS() => _gWApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass(_gWApplicationOverviewPage);

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as PASS")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsPASS() => _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsPass(_gWApplicationOverviewPage);

    }
}