namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

public abstract class LiveSignBasePage(ScenarioContext context) : LiveRegistrationBasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-label--l");

    protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");

    protected void EnterPpiAndContinue(By locator, string text)
    {
        formCompletionHelper.EnterPpi(locator, text);

        Continue();
    }
}
