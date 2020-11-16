using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class GwAdminSteps
    {
        private readonly ScenarioContext _context;
        private readonly GatewayEndtoEndStepsHelpers _gatewayEndToEndStepsHelpers;
        private GWApplicationOverviewPage _gwApplicationOverviewPage;
        

        public GwAdminSteps(ScenarioContext context)
        {
            _context = context;
            _gatewayEndToEndStepsHelpers = new GatewayEndtoEndStepsHelpers();
        }

        [When(@"the admin access the application from GatewayApplications")]
        public void WhenTheAdminAccessTheMainRouteApplicationFromGatewayApplications() => new StaffDashboardPage(_context).AccessGatewayApplications().SelectApplication();

        [When(@"the gateway admin assess all sections as PASS for MainRoute Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForMainRouteApplication() =>
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_MainRouteCompany((new GWApplicationOverviewPage(_context)));

        [When(@"the gateway admin assess all sections as PASS for Employer Route Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForEmployerRouteApplication() =>
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_EmployerRouteCharity((new GWApplicationOverviewPage(_context)));

        [When(@"the gateway admin assess all sections as PASS for Supporting Route Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForSupportingRouteApplication()=>    
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_SupportingRouteSoleTrader((new GWApplicationOverviewPage(_context)));

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as PASS")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsPASS() => _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsPass(_gwApplicationOverviewPage);
    }
}