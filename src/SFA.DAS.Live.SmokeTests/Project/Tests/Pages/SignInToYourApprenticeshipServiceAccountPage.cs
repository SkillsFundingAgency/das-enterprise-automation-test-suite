namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

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
