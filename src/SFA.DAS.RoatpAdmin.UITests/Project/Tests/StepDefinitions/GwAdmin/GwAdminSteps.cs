using NUnit.Framework;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class GwAdminSteps(ScenarioContext context)
    {
        private GWApplicationOverviewPage _gwApplicationOverviewPage;

        [When(@"the admin access the application from GatewayApplications")]
        public void WhenTheAdminAccessTheMainRouteApplicationFromGatewayApplications() => new StaffDashboardPage(context).AccessGatewayApplications().SelectApplication();

        [When(@"the gateway admin assess all sections as PASS for MainRoute Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForMainRouteApplication() =>
            _gwApplicationOverviewPage = GatewayEndtoEndStepsHelpers.CompleteAllSectionsWithPass_MainOrEmpRouteCompany((new GWApplicationOverviewPage(context)));

        [When(@"the gateway admin fails PeopleInControlChecks")]
        public void WhenTheGatewayAdminFailsPeopleInControlChecks() =>
            _gwApplicationOverviewPage = GatewayEndtoEndStepsHelpers.CompleteAllSectionsPass_FailPeopleInControlChecks_MainOrEmpRouteCompany((new GWApplicationOverviewPage(context)));

        [When(@"the gateway admin fails RegisterChecks")]
        public void WhenTheGatewayAdminFailsRegisterChecks() =>
            _gwApplicationOverviewPage = GatewayEndtoEndStepsHelpers.CompleteAllSectionsPass_FailRegisterChecks_EmployerRouteCharity((new GWApplicationOverviewPage(context)));

        [When(@"the gateway admin assess all sections as PASS for Employer Route Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForEmployerRouteApplication() =>
            _gwApplicationOverviewPage = GatewayEndtoEndStepsHelpers.CompleteAllSectionsWithPass_EmployerRouteCharity((new GWApplicationOverviewPage(context)));

        [When(@"the gateway admin assess all sections as PASS for Supporting Route Application")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASSForSupportingRouteApplication() =>
            _gwApplicationOverviewPage = GatewayEndtoEndStepsHelpers.CompleteAllSectionsWithPass_SupportingRouteSoleTrader((new GWApplicationOverviewPage(context)));

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as PASS")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsPASS() => GatewayEndtoEndStepsHelpers.ConfirmGatewayOutcomeAsPass(_gwApplicationOverviewPage);

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as FAIL")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsFAIL() => GatewayEndtoEndStepsHelpers.ConfirmGatewayOutcomeAsFail(_gwApplicationOverviewPage);

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as Reject")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsReject() => GatewayEndtoEndStepsHelpers.ConfirmGatewayOutcomeAsReject(_gwApplicationOverviewPage);

        [Then(@"the Gateway Applications Outcome tab is updated with (Pass|Fail|Withdrawn|Reject|Removed) outcome for this Application")]
        public void ThenTheGatewayApplicationsOutcomeTabIsUpdatedWithPassOutcomeForThisApplication(string expectedStatus) => new GatewayLandingPage(context).VerifyOutcomeStatus(expectedStatus);

        [Then(@"Verifiy the application is not transitioned to PMO and Assessor")]
        public void ThenVerifiyTheApplicationIsNotTransitionedToPMOAndAssessor()
        {
            var staffDashboardPage = new GatewayLandingPage(context).ClickReturnToStaffDashBoard();
            staffDashboardPage.AccessFinancialApplications();
            FinancialLandingPage financialLandingPage = new(context);
            Assert.IsFalse(financialLandingPage.VerifyApplication(), "Gateway Fail outcome Application Transitioned to PMO");
            staffDashboardPage = financialLandingPage.ClickReturnToStaffDashBoard();
            staffDashboardPage.AccessAssessorAndModerationApplications();
            RoatpAssessorApplicationsHomePage roatpAssessorApplicationsHomePage = new(context);
            Assert.Throws<Exception>(() => roatpAssessorApplicationsHomePage.GetApplication(), "Gateway Fail outcome Application Transitioned to Assessor");
            staffDashboardPage = roatpAssessorApplicationsHomePage.ClickReturnToStaffDashBoard();
            staffDashboardPage.AccessOversightApplications();
        }

        [Then(@"the admin Withdraws the Application")]
        public void ThenTheAdminWithdrawsTheApplication() => GatewayEndtoEndStepsHelpers.ConfirmWithdrawGatewayApplication((new GWApplicationOverviewPage(context)));

        [Then(@"the admin Removes the Application")]
        public void ThenTheAdminRemovesTheApplication() => GatewayEndtoEndStepsHelpers.ConfirmRemoveGatewayApplication((new GWApplicationOverviewPage(context)));

        [Then(@"the admin Withdraws the Application where outcome has been made")]
        public void ThenTheAdminWithdrawsTheApplicationWhereOutcomeHasBeenMade() => GatewayEndtoEndStepsHelpers.ConfirmWithdrawOutcomeMadeGatewayApplication((new ReadOnlyGatewayOutcomePage(context)));

        [Then(@"the admin Removes the Application where outcome has been made")]
        public void ThenTheAdminRemovesTheApplicationWhereOutcomeHasBeenMade() => GatewayEndtoEndStepsHelpers.ConfirmRemoveOutcomeMadeGatewayApplication((new ReadOnlyGatewayOutcomePage(context)));

        [When(@"the gateway admin assess first subsection as PASS")]
        public void WhenTheGatewayAdminAssessFirstSubsectionAsPASS() => GatewayEndtoEndStepsHelpers.CompleteOrganisationChecks_Section1((new GWApplicationOverviewPage(context)));

        [When(@"the gateway admin assess People in control checks as Clarification")]
        public void WhenTheGatewayAdminAssessPeopleInControlChecksAsClarification() => GatewayEndtoEndStepsHelpers.CompletePeopleInControlChecks_Section2_Clarification((new GWApplicationOverviewPage(context)));

        [Then(@"the gateway admin completes assessment by confirming Clarification is needed")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingClarificationIsNeeded() => GatewayEndtoEndStepsHelpers.ConfirmClarification_GatewayApplication((new GWApplicationOverviewPage(context)));

        [Then(@"the admin access the application from Outcome tab")]
        public void ThenTheAdminAccessTheApplicationFromOutcomeTab()
        {
            GatewayLandingPage gatewayLandingPage = new(context);
            gatewayLandingPage.SelectApplicationFromOutcomeTab();
        }
    }
}