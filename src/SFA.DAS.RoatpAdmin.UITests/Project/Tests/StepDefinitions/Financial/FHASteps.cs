using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Financial;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class FHASteps
    {
        private readonly ScenarioContext _context;        
        public FHASteps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"the admin access the FinancialApplications")]
        public void WhenTheAdminAccessTheFinancialApplications()
        {
            StaffDashboardPage staffDashboardPage = new StaffDashboardPage(_context);
            staffDashboardPage.AccessFinancialApplications()
                .SelectNewApplication();
        }

        [Then(@"the Financial assessor completes assessment by confirming the Gateway outcome as Outstanding")]
        public void ThenTheFinancialAssessorCompletesAssessmentByConfirmingTheGatewayOutcomeAsOutstanding()
        {
            FinancialHealthAssessmentOverviewPage financialHealthAssessmentOverviewPage = new FinancialHealthAssessmentOverviewPage(_context);
            financialHealthAssessmentOverviewPage.ConfirmFHAReviewAsOutstanding();
        }

    }
}
