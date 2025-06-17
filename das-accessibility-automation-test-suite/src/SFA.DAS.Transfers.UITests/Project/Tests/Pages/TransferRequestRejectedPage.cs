using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransferRequestRejectedPage(ScenarioContext context) : TransfersBasePage(context)
    {
        protected override string PageTitle => "Transfer request rejected";
    }
}