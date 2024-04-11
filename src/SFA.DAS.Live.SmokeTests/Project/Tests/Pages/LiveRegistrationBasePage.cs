namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages
{
    public abstract class LiveRegistrationBasePage : VerifyBasePage
    {
        public LiveRegistrationBasePage(ScenarioContext context) : base(context) => VerifyPage();

    }

    public class SignInToYourApprenticeshipServiceAccountPage(ScenarioContext context) : LiveRegistrationBasePage(context)
    {
        protected override string PageTitle => "Sign in to your apprenticeship service account";

        private static By SignInButton => By.CssSelector("a[href*='/service']");

        public CreateYourLoginOrSignInPage SignInToYourApprenticeshipServiceAccount()
        {
            formCompletionHelper.ClickElement(SignInButton);

            return new(context);
        }
    }

    public class CreateYourLoginOrSignInPage(ScenarioContext context) : LiveRegistrationBasePage(context)
    {
        protected override string PageTitle => "Create your GOV.UK One Login or sign in";

        private static By SignInButton => By.CssSelector("#sign-in-button");

        public EnterYourEmailPage SignInToGovUkLogin()
        {
            formCompletionHelper.ClickElement(SignInButton);

            return new(context);
        }
    }

    public class EnterYourEmailPage(ScenarioContext context) : LiveRegistrationBasePage(context)
    {
        protected override string PageTitle => "Enter your email address to sign in to your GOV.UK One Login";

        protected override By PageHeader => By.CssSelector(".govuk-label--l");

        private static By EmailField => By.CssSelector("#email");

        public void SignInToYourApprenticeshipServiceAccount()
        {
            formCompletionHelper.EnterText(EmailField, "");

        }
    }
}
