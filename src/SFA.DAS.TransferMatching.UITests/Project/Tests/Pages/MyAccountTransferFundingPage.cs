using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public partial class MyAccountTransferFundingPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "My accounts";

        private readonly ScenarioContext _context;

        public MyAccountTransferFundingPage(ScenarioContext context) : base(context) => _context = context;

        public CreateATransfersApplicationPage GoToCreateATransfersApplicationPage(string orgName)
        {
            formCompletionHelper.ClickLinkByText(orgName);
            return new CreateATransfersApplicationPage(_context);
        }
    }
}