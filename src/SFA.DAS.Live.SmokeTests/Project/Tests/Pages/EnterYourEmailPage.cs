namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

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
