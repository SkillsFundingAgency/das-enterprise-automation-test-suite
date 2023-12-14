using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public partial class MyAccountTransferFundingPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "My accounts";

        public CreateATransfersApplicationPage GoToCreateATransfersApplicationPage(string orgName)
        {
            formCompletionHelper.ClickLinkByText(orgName);

            return new CreateATransfersApplicationPage(context);
        }
    }
}