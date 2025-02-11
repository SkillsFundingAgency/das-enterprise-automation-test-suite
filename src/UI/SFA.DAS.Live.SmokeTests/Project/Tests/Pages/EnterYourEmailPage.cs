namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

public class EnterYourEmailPage(ScenarioContext context) : LiveSignBasePage(context)
{
    protected override string PageTitle => "Enter your email address to sign in to your GOV.UK One Login";

    private static By EmailField => By.CssSelector("#email");

    public EnterYourPasswordPage EnterUsername()
    {
        EnterPpiAndContinue(EmailField, liveEasUser.Username);

        return new(context);
    }
}
