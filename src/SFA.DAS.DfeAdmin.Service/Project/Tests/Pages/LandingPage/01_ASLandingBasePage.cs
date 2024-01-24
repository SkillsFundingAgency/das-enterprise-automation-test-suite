namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public abstract class ASLandingBasePage(ScenarioContext context) : IdamsLoginBasePage(context)
{
    public static By StartNowButton => By.CssSelector(".govuk-button--start");

    protected override By PageHeader => ASLandingPageheader;

    public static By ASLandingPageheader => By.CssSelector(".govuk-heading-l");

    public void ClickStartNowButton() => formCompletionHelper.ClickElement(StartNowButton);
}
