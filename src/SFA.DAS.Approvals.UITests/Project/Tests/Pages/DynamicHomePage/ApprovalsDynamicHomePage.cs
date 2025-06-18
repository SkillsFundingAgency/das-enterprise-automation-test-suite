using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class ApprovalsDynamicHomePage(ScenarioContext context) : HomePage(context)
    {
        public ReserveFundingToTrainAndAssessAnApprenticePage StartNowToReserveFunding()
        {
            formCompletionHelper.ClickElement(StartNowButton);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(context);
        }
    }
}
