using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransferRequestRejectedPage : TransfersBasePage
    {
        public TransferRequestRejectedPage(ScenarioContext context) : base(context) { }

        protected override string PageTitle => "Transfer request rejected";
    }
}