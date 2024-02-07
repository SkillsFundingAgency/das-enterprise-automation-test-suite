namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class ConfirmedLeftNetworkPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "You have successfully left the network";

    public RejoinNetworkPage AccessRestoreMember()
    {
        formCompletionHelper.ClickLinkByText("restore your membership");
        return new RejoinNetworkPage(context);
    }
}
