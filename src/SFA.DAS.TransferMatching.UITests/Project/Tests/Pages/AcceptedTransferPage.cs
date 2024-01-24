using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AcceptedTransferPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "You have successfully accepted a transfer";

        public MyApplicationsPage ViewMyApplications()
        {
            formCompletionHelper.ClickLinkByText("View my applications");
            return new MyApplicationsPage(context);
        }
    }
}