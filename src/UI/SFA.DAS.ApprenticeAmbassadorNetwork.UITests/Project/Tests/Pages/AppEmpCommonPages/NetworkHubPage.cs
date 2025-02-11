namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public abstract class NetworkHubPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Your network hub";

    public EventsHubPage AccessEventsHub()
    {
        formCompletionHelper.ClickLinkByText("Events hub");
        return new EventsHubPage(context);
    }

    public NetworkDirectoryPage AccessNetworkDirectory()
    {
        formCompletionHelper.ClickLinkByText("Network directory");
        return new NetworkDirectoryPage(context);
    }

    public ProfileSettingsPage AccessProfileSettings()
    {
        formCompletionHelper.ClickLinkByText("Profile settings");
        return new ProfileSettingsPage(context);
    }
    public ContactUsPage AccessContactUs()
    {
        formCompletionHelper.ClickLinkByText("Contact us");
        return new ContactUsPage(context);
    }
}