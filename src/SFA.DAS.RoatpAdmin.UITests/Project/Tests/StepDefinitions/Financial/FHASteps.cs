using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class FHASteps(ScenarioContext context)
    {
        private FinancialLandingPage _financialLandingPage;

        [When(@"the admin access the Financial Applications")]
        public void WhenTheAdminAccessTheFinancialApplications() => _financialLandingPage = new StaffDashboardPage(context).AccessFinancialApplications();

        [Then(@"the Financial assessor completes assessment by confirming the Financial outcome as (outstanding)")]
        public void ThenTheFinancialAssessorCompletesAssessmentByConfirmingTheFinancialOutcomeAsOutstanding(string expectedoutcome)
        {
            _financialLandingPage = _financialLandingPage
                .SelectNewApplication()
                .ConfirmFHAReview(expectedoutcome)
                .GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the Financial assessor completes assessment by confirming the Financial outcome as Clarification")]
        public void ThenTheFinancialAssessorCompletesAssessmentByConfirmingTheFinancialOutcomeAsClarification()
        {
            _financialLandingPage = _financialLandingPage
                .SelectNewApplication()
                .ConfirmNeedsClarification()
                .GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the Financial assessor completes the Clarification process by confirming the Financial outcome as Inadequate")]
        public void ThenTheFinancialAssessorCompletesTheClarificationProcessByConfirmingTheFinancialOutcomeAsInadequate()
        {
            _financialLandingPage = _financialLandingPage.SelectClarificationApplication()
                .EnterClarificationResponse()
                .GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the Financial Applications Outcome tab is updated with (Outstanding|Inadequate) outcome for this Application")]
        public void ThenTheFinancialApplicationsOutcomeTabIsUpdated(string expectedStatus) => _financialLandingPage = _financialLandingPage.VerifyOutcomeStatus(expectedStatus);

    }
}
