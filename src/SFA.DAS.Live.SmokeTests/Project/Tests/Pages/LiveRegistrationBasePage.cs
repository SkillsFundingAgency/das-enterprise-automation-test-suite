namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

public abstract class LiveRegistrationBasePage : VerifyBasePage
{
    protected LiveEasUser liveEasUser;

    public LiveRegistrationBasePage(ScenarioContext context) : base(context)
    {
        VerifyPage();

        liveEasUser = context.Get<LiveEasUser>();
    }
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

    protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");

    private static By EmailField => By.CssSelector("#email");

    public EnterYourPasswordPage EnterUsername()
    {
        formCompletionHelper.EnterText(EmailField, liveEasUser.Username);

        Continue();

        return new(context);
    }
}

public class EnterYourPasswordPage(ScenarioContext context) : LiveRegistrationBasePage(context)
{
    protected override string PageTitle => "Enter your password";

    protected override By PageHeader => By.CssSelector(".govuk-label--l");

    protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");

    private static By PasswordField => By.CssSelector("#password");

    public EnterYourSecurityCodePage EnterPassword()
    {
        formCompletionHelper.EnterText(PasswordField, liveEasUser.Password);

        Continue();

        return new(context);
    }
}


public class EnterYourSecurityCodePage(ScenarioContext context) : LiveRegistrationBasePage(context)
{
    protected override string PageTitle => "Enter the 6 digit security code shown in your authenticator app";

    protected override By PageHeader => By.CssSelector(".govuk-label--l");

    protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");

    private static By CodeField => By.CssSelector("#code");

    public HomePage EnterCode()
    {
        var code = liveEasUser.Password;

        formCompletionHelper.EnterText(CodeField, code);

        Continue();

        return new(context);
    }
}