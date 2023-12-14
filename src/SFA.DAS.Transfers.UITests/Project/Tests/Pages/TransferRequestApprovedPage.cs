using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransferRequestApprovedPage : TransfersBasePage
    {
        public TransferRequestApprovedPage(ScenarioContext context) : base(context) { }

        protected override string PageTitle => "Transfer request approved";
    }
}