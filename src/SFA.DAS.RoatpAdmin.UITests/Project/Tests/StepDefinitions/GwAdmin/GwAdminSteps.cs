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
        private readonly GatewayEndtoEndStepsHelpers _gatewayEndToEndStepsHelpers;
        private GWApplicationOverviewPage _gwApplicationOverviewPage;

        public GwAdminSteps(ScenarioContext context)
        {
            _context = context;
            _loginStepsHelper = new RoatpAdminLoginStepsHelper(_context);
            _gatewayEndToEndStepsHelpers = new GatewayEndtoEndStepsHelpers();
        }

        [Given(@"the admin lands on the Dashboard")]
        public void GivenTheAdminLandsOnTheDashboard() => GoToRoatpStaffDashBoardPage();

        private StaffDashboardPage GoToRoatpStaffDashBoardPage()
        {
            _loginStepsHelper.SubmitValidLoginDetails();
            return new StaffDashboardPage(_context);
        }

        [When(@"the admin access the GatewayApplications")]
        public void WhenTheAdminAccessTheGatewayApplications()
        {
            StaffDashboardPage staffDashboardPage = new StaffDashboardPage(_context);
            staffDashboardPage.AccessGatewayApplications()
                .SelectingNewApplication();
        }

        [When(@"the gateway admin assess all sections as PASS")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASS() => _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass((new GWApplicationOverviewPage(_context)));

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as PASS")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsPASS() => _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsPass(_gwApplicationOverviewPage);

    }
}