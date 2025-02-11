namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

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
