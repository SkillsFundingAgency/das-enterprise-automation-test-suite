namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class ProfileSettingsPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Profile Settings";

    public YourAmbassadorProfilePage AccessYourAmbassadorProfile()
    {
        formCompletionHelper.ClickLinkByText("Your ambassador profile");
        return new YourAmbassadorProfilePage(context);
    }
}
