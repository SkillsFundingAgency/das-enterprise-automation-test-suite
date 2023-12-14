using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class PasswordResetSuccessfulPage(ScenarioContext context) : EmailAndPasswordSuccessfulBasePage(context)
    {
        protected override string PageTitle => "Password reset successful";

        public SignIntoMyApprenticeshipPage ReturnToSignInPage()
        {
            formCompletionHelper.ClickLinkByText("Return to home");
            return new SignIntoMyApprenticeshipPage(context);
        }
    }
}
