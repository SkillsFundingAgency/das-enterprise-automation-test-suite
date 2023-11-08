namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public abstract class ASLandingBasePage : IdamsLoginBasePage
{
    public static By StartNowButton => By.CssSelector(".govuk-button--start");

    public ASLandingBasePage(ScenarioContext context) : base(context) { }

    public void ClickStartNowButton() => formCompletionHelper.ClickElement(StartNowButton);

    public DfeSignInPage StartNowAndGoToDfeSignPage()
    {
        ClickStartNowButton();

        return new DfeSignInPage(context);
    }
}
