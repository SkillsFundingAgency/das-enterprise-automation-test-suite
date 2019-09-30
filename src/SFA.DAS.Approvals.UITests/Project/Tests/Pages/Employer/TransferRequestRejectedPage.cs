using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TransferRequestRejectedPage : TransferRequest
    {
        public TransferRequestRejectedPage(ScenarioContext context) : base(context) { }

        protected override string PageTitle => "Transfer request rejected";
    }
}