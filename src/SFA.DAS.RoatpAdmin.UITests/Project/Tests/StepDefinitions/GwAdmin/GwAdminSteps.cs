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
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_MainOrEmpRouteCompany((new GWApplicationOverviewPage(_context)));

        [When(@"the gateway admin fails PeopleInControlChecks")]
        public void WhenTheGatewayAdminFailsPeopleInControlChecks() =>
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsPass_FailPeopleInControlChecks_MainOrEmpRouteCompany((new GWApplicationOverviewPage(_context)));

        [When(@"the gateway admin fails RegisterChecks")]
        public void WhenTheGatewayAdminFailsRegisterChecks() =>
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsPass_FailRegisterChecks_EmployerRouteCharity((new GWApplicationOverviewPage(_context)));

        [When(@"the gateway admin assess all sections as PASS for Employer Route Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForEmployerRouteApplication() =>
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_EmployerRouteCharity((new GWApplicationOverviewPage(_context)));

        [When(@"the gateway admin assess all sections as PASS for Supporting Route Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForSupportingRouteApplication()=>    
            _gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_SupportingRouteSoleTrader((new GWApplicationOverviewPage(_context)));

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as PASS")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsPASS() => _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsPass(_gwApplicationOverviewPage);

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as FAIL")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsFAIL() => _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsFail(_gwApplicationOverviewPage);

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as Reject")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsReject() => _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsReject(_gwApplicationOverviewPage);

        [Then(@"the Gateway Applications Outcome tab is updated with (PASS|FAIL|REJECT) outcome for this Application")]
        public void ThenTheGatewayApplicationsOutcomeTabIsUpdatedWithPassOutcomeForThisApplication(string expectedStatus) => new GatewayLandingPage(_context).VerifyOutcomeStatus(expectedStatus);
    }
}