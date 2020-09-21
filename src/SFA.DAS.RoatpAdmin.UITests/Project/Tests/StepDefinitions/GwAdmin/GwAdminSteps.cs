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

        [When(@"the admin access the MainRoute application from GatewayApplications")]
        public void WhenTheAdminAccessTheMainRouteApplicationFromGatewayApplications()
        {
            StaffDashboardPage staffDashboardPage = new StaffDashboardPage(_context);
            staffDashboardPage.AccessGatewayApplications()
                .SelectingMainRouteApplication();
        }

        [When(@"the gateway admin assess all sections as PASS for MainRoute Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForMainRouteApplication() =>
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_MainRouteCompany((new GWApplicationOverviewPage(_context)));

        [When(@"the admin access the EmployerRoute application from GatewayApplications")]
        public void WhenTheAdminAccessTheEmployerRouteApplicationFromGatewayApplications()
        {
            StaffDashboardPage staffDashboardPage = new StaffDashboardPage(_context);
            staffDashboardPage.AccessGatewayApplications()
                .SelectingEmployerRouteApplication();
        }

        [When(@"the gateway admin assess all sections as PASS for Employer Route Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForEmployerRouteApplication() =>
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_EmployerRouteCharity((new GWApplicationOverviewPage(_context)));

        [When(@"the admin access the SupportingRoute application from GatewayApplications")]
        public void WhenTheAdminAccessTheSupportingRouteApplicationFromGatewayApplications()
        {
            StaffDashboardPage staffDashboardPage = new StaffDashboardPage(_context);
            staffDashboardPage.AccessGatewayApplications()
                .SelectingSupportingRouteApplication();
        }

        [When(@"the gateway admin assess all sections as PASS for Supporting Route Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForSupportingRouteApplication()=>    
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_SupportingRouteSoleTrader((new GWApplicationOverviewPage(_context)));

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as PASS")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsPASS() => _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsPass(_gwApplicationOverviewPage);
    }
}