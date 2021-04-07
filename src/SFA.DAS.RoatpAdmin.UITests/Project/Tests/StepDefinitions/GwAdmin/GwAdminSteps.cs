using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using NUnit.Framework;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
using System;

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

        [Then(@"the Gateway Applications Outcome tab is updated with (PASS|FAIL|REJECT|WITHDRAWN|REJECT|REMOVED) outcome for this Application")]
        public void ThenTheGatewayApplicationsOutcomeTabIsUpdatedWithPassOutcomeForThisApplication(string expectedStatus) => new GatewayLandingPage(_context).VerifyOutcomeStatus(expectedStatus);

        [Then(@"Verifiy the application is not transitioned to PMO and Assessor")]
        public void ThenVerifiyTheApplicationIsNotTransitionedToPMOAndAssessor()
        {
            var staffDashboardPage = new GatewayLandingPage(_context).ClickReturnToStaffDashBoard();
            staffDashboardPage.AccessFinancialApplications();
            FinancialLandingPage financialLandingPage = new FinancialLandingPage(_context);
            Assert.IsFalse(financialLandingPage.VerifyApplication(), "Gateway Fail outcome Application Transitioned to PMO");
            staffDashboardPage = financialLandingPage.ClickReturnToStaffDashBoard();
            staffDashboardPage.AccessAssessorAndModerationApplications();
            RoatpAssessorApplicationsHomePage roatpAssessorApplicationsHomePage = new RoatpAssessorApplicationsHomePage(_context);
            Assert.Throws<Exception>(() => roatpAssessorApplicationsHomePage.GetApplication(), "Gateway Fail outcome Application Transitioned to Assessor");
            staffDashboardPage = roatpAssessorApplicationsHomePage.ClickReturnToStaffDashBoard();
            staffDashboardPage.AccessOversightApplications();
        }
       
        [Then(@"the admin Withdraws the Application")]
        public void ThenTheAdminWithdrawsTheApplication() => _gatewayEndToEndStepsHelpers.ConfirmWithdrawGatewayApplication((new GWApplicationOverviewPage(_context)));

        [Then(@"the admin Removes the Application")]
        public void ThenTheAdminRemovesTheApplication() => _gatewayEndToEndStepsHelpers.ConfirmRemoveGatewayApplication((new GWApplicationOverviewPage(_context)));

        [Then(@"the admin Withdraws the Application where outcome has been made")]
        public void ThenTheAdminWithdrawsTheApplicationWhereOutcomeHasBeenMade() => _gatewayEndToEndStepsHelpers.ConfirmWithdrawOutcomeMadeGatewayApplication((new ReadOnlyGatewayOutcomePage(_context)));

        [Then(@"the admin Removes the Application where outcome has been made")]
        public void ThenTheAdminRemovesTheApplicationWhereOutcomeHasBeenMade() => _gatewayEndToEndStepsHelpers.ConfirmRemoveOutcomeMadeGatewayApplication((new ReadOnlyGatewayOutcomePage(_context)));

        [When(@"the gateway admin assess first subsection as PASS")]
        public void WhenTheGatewayAdminAssessFirstSubsectionAsPASS() => _gatewayEndToEndStepsHelpers.CompleteOrganisationChecks_Section1((new GWApplicationOverviewPage(_context)));

        [When(@"the gateway admin assess People in control checks as Clarification")]
        public void WhenTheGatewayAdminAssessPeopleInControlChecksAsClarification() => _gatewayEndToEndStepsHelpers.CompletePeopleInControlChecks_Section2_Clarification((new GWApplicationOverviewPage(_context)));

        [Then(@"the gateway admin completes assessment by confirming Clarification is needed")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingClarificationIsNeeded() => _gatewayEndToEndStepsHelpers.ConfirmClarification_GatewayApplication((new GWApplicationOverviewPage(_context)));

        [Then(@"the admin access the application from Outcome tab")]
        public void ThenTheAdminAccessTheApplicationFromOutcomeTab()
        {
            GatewayLandingPage gatewayLandingPage = new GatewayLandingPage(_context);
            gatewayLandingPage.SelectApplicationFromOutcomeTab();
        }
    }
}