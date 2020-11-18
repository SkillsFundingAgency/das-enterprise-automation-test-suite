using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class FHASteps
    {
        private readonly ScenarioContext _context;
        private FinancialHealthAssessmentOverviewPage financialHealthAssessmentOverviewPage;
        public FHASteps(ScenarioContext context) => _context = context;

        [When(@"the admin access the FinancialApplications")]
        public void WhenTheAdminAccessTheFinancialApplications() => financialHealthAssessmentOverviewPage = new StaffDashboardPage(_context).AccessFinancialApplications().SelectNewApplication();


        [Then(@"the Financial assessor completes assessment by confirming the Gateway outcome as Outstanding")]
        public void ThenTheFinancialAssessorCompletesAssessmentByConfirmingTheGatewayOutcomeAsOutstanding() => financialHealthAssessmentOverviewPage.ConfirmFHAReviewAsOutstanding();

        [Then(@"the Financial Applications Outcome tab is updated as (Outstanding|Inadequate)")]
        public void ThenTheFinancialApplicationsOutcomeTabIsUpdatedAs(string expectedStatus) => financialHealthAssessmentOverviewPage.VerifyOutcomeStatus(expectedStatus);

    }
}
