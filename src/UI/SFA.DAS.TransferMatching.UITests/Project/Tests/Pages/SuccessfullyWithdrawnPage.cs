using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class SuccessfullyWithdrawnPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "You have successfully declined a transfer of funds";

        public AccountHomePage ReturnToMyAccount()
        {
            formCompletionHelper.ClickLinkByText("Return to my account");
            return new AccountHomePage(context);
        }
    }
}
