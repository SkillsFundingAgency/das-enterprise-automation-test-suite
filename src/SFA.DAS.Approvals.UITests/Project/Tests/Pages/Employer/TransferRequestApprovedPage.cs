using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TransferRequestApprovedPage : TransferRequest
    {
        public TransferRequestApprovedPage(ScenarioContext context): base(context) { }

        protected override string PageTitle => "Transfer request approved";
    }
}