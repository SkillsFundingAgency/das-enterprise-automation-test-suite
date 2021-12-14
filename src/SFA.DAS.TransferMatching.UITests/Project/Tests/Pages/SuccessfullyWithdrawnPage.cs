using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class SuccessfullyWithdrawnPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "You have successfully declined a transfer of funds";

        public SuccessfullyWithdrawnPage(ScenarioContext context) : base(context) { }

        public MyApplicationsPage ViewMyApplications()
        {
            formCompletionHelper.ClickLinkByText("View my applications");
            return new MyApplicationsPage(context);
        }
    }
}
