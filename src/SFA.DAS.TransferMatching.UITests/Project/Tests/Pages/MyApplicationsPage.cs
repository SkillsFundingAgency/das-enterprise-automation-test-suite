using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class MyApplicationsPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "My applications";

        public ApplicationsDetailsPage OpenPledgeApplication(string expectedStatus)
        {
            formCompletionHelper.ClickLinkByText(GetPledgeId());
            return new ApplicationsDetailsPage(context, expectedStatus);
        }

        public ManageTransferMatchingPage GoBackToManageTransfersPage()
        {
            formCompletionHelper.ClickLinkByText("Manage Transfers");
            return new ManageTransferMatchingPage(context);
        }

        
    }
}