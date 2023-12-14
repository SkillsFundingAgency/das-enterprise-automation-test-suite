using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class PasswordResetSuccessfulPage : EmailAndPasswordSuccessfulBasePage
    {
        protected override string PageTitle => "Password reset successful";

        public PasswordResetSuccessfulPage(ScenarioContext context) : base(context) { }

        public SignIntoMyApprenticeshipPage ReturnToSignInPage()
        {
            formCompletionHelper.ClickLinkByText("Return to home");
            return new SignIntoMyApprenticeshipPage(context);
        }
    }
}
