using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public partial class MyAccountTransferFundingPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "My accounts";

        public MyAccountTransferFundingPage(ScenarioContext context) : base(context) { }

        public CreateATransfersApplicationPage GoToCreateATransfersApplicationPage(string orgName)
        {
            formCompletionHelper.ClickLinkByText(orgName);

            return new CreateATransfersApplicationPage(context);
        }
    }
}