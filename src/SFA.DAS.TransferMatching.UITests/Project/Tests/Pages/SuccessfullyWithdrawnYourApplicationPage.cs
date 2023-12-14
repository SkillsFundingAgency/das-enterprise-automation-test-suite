using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class SuccessfullyWithdrawnYourApplicationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "You have successfully withdrawn your application";

        public SuccessfullyWithdrawnYourApplicationPage(ScenarioContext context) : base(context) { }

        public AccountHomePage ReturnToMyAccount()
        {
            formCompletionHelper.ClickLinkByText("Continue to my account");
            return new AccountHomePage(context);
        }
    }
}
