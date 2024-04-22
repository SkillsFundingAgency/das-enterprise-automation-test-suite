using SFA.DAS.MailosaurAPI.Service.Project.Helpers;

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
        formCompletionHelper.EnterPpi(EmailField, liveEasUser.Username);

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
        formCompletionHelper.EnterPpi(PasswordField, liveEasUser.Password);

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

    public LiveHomePage EnterCode()
    {
        var deviceConfig = context.Get<MailasourDeviceConfig>();

        var helper = new MailosaurDeviceHelper(deviceConfig.AccountApiToken);

        var code = helper.GetCode(deviceConfig.LiveEasUserDeviceId);

        formCompletionHelper.EnterPpi(CodeField, code);

        Continue();

        return new(context);
    }
}


public class LiveHomePage(ScenarioContext context) : HomePage(context)
{
    private static By HeaderSelector => By.CssSelector(".govuk-header__container a[href*='www.gov.uk']");

    private static By LauncherIframe => By.CssSelector("iframe[id='launcher']");

    private static By LauncherButton => By.CssSelector("button[data-testid='launcher']");

    private static By WebWidgetIframe => By.CssSelector("iframe[id='webWidget']");

    private static By WebWidgetTitle => By.CssSelector("h1[id='widgetHeaderTitle']");

    public void VerifyHeaders() => VerifyElement(HeaderSelector);

    public void VerifyHelpLauncher()
    {
        frameHelper.SwitchFrameAndAction(() =>
        {
            formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(LauncherButton), false);
        }, 
        LauncherIframe);
    }

    public void AccessHelpLauncher()
    {
        frameHelper.SwitchFrameAndAction(() =>
        {
            VerifyPage(WebWidgetTitle, "Apprenticeship Service Support");
        },
        WebWidgetIframe);
    }
}