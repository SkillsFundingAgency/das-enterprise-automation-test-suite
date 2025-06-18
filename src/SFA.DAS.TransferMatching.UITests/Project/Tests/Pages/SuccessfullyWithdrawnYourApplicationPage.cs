using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class SuccessfullyWithdrawnYourApplicationPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "You have successfully withdrawn your application";

        public AccountHomePage ReturnToMyAccount()
        {
            formCompletionHelper.ClickLinkByText("Continue to my account");
            return new AccountHomePage(context);
        }
    }
}
