namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class SucessfullySentMessagePage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Your message has been sent successfully";

    public NetworkDirectoryPage AccessNetworkDirectory()
    {
        formCompletionHelper.ClickLinkByText("Network Directory");
        return new NetworkDirectoryPage(context);
    }
}
