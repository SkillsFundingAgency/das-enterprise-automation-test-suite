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

        [When(@"the admin access the FinancialApplications")]
        public void WhenTheAdminAccessTheFinancialApplications() => _financialLandingPage = new StaffDashboardPage(_context).AccessFinancialApplications();


        [Then(@"the Financial assessor completes assessment by confirming the Gateway outcome as Outstanding")]
        public void ThenTheFinancialAssessorCompletesAssessmentByConfirmingTheGatewayOutcomeAsOutstanding()
        {
            _financialLandingPage = _financialLandingPage
                .SelectNewApplication()
                .ConfirmFHAReviewAsOutstanding()
                .GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the Financial assessor completes assessment by confirming the Gateway outcome as Inadequate")]
        public void ThenTheFinancialAssessorCompletesAssessmentByConfirmingTheGatewayOutcomeAsInadequate()
        {
            _financialLandingPage = _financialLandingPage
                .SelectNewApplication()
                .ConfirmNeedsClarification()
                .GoToRoATPAssessorApplicationsPage();

            _financialLandingPage = _financialLandingPage.SelectClarificationApplication()
                .EnterClarificationResponse()
                .GoToRoATPAssessorApplicationsPage();
        }


        [Then(@"the Financial Applications Outcome tab is updated as (Outstanding|Inadequate)")]
        public void ThenTheFinancialApplicationsOutcomeTabIsUpdatedAs(string expectedStatus) => _financialLandingPage = _financialLandingPage.VerifyOutcomeStatus(expectedStatus);

    }
}
