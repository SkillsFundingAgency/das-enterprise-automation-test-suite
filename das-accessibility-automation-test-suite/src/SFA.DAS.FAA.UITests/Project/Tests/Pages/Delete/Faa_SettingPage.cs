namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.Delete;

public class SettingPage : FAASignedInLandingBasePage
{
    private static By SettingsLink => By.LinkText("Settings");

    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    protected override string PageTitle => "Settings";

    public SettingPage(ScenarioContext context) : base(context, false)
    {
        formCompletionHelper.Click(SettingsLink);

        VerifyPage();
    }

    public DeleteAccountPage DeleteMyAccount()
    {
        formCompletionHelper.ClickLinkByText("Delete my account");

        return new DeleteAccountPage(context);
    }
}
