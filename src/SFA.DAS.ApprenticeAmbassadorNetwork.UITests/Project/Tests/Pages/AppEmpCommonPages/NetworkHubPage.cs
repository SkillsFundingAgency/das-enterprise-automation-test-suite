namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public abstract class NetworkHubPage : AanBasePage
{
    protected override string PageTitle => "Your network hub";

    public NetworkHubPage(ScenarioContext context) : base(context) => VerifyPage();

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
}