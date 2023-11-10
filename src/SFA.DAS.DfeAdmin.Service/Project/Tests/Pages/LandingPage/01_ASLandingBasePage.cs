namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public abstract class ASLandingBasePage : IdamsLoginBasePage
{
    public static By StartNowButton => By.CssSelector(".govuk-button--start");

    protected override By PageHeader => ASLandingPageheader;

    public static By ASLandingPageheader => By.CssSelector(".govuk-heading-l");

    public ASLandingBasePage(ScenarioContext context) : base(context) { }

    public void ClickStartNowButton() => formCompletionHelper.ClickElement(StartNowButton);
}
