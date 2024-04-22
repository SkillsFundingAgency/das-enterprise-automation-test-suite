namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

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
