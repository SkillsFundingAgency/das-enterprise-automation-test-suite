using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class FHASteps
    {
        private readonly ScenarioContext _context;
        private FinancialLandingPage _financialLandingPage;

        public FHASteps(ScenarioContext context) => _context = context;

        [When(@"the admin access the Financial Applications")]
        public void WhenTheAdminAccessTheFinancialApplications() => _financialLandingPage = new StaffDashboardPage(_context).AccessFinancialApplications();

        [Then(@"the Financial assessor completes assessment by confirming the Financial outcome as (outstanding)")]
        public void ThenTheFinancialAssessorCompletesAssessmentByConfirmingTheFinancialOutcomeAsOutstanding(string expectedoutcome)
        {
            _financialLandingPage = _financialLandingPage
                .SelectNewApplication()
                .ConfirmFHAReviewAsOutstanding(expectedoutcome)
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
