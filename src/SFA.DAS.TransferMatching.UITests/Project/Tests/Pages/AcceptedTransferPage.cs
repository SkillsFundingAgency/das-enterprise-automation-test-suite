using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AcceptedTransferPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "You have successfully accepted a transfer";

        public AcceptedTransferPage(ScenarioContext context) : base(context) { }

        public MyApplicationsPage ViewMyApplications()
        {
            formCompletionHelper.ClickLinkByText("View my applications");
            return new MyApplicationsPage(context);
        }
    }
}