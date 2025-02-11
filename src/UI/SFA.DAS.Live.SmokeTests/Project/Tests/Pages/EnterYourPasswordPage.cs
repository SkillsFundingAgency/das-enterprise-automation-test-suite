namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

public class EnterYourPasswordPage(ScenarioContext context) : LiveSignBasePage(context)
{
    protected override string PageTitle => "Enter your password";

    private static By PasswordField => By.CssSelector("#password");

    public EnterYourSecurityCodePage EnterPassword()
    {
        EnterPpiAndContinue(PasswordField, liveEasUser.Password);

        return new(context);
    }
}
