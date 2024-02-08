namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class RejoinNetworkPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Would you like to rejoin the network?";

    public void RestoreMember()
    {
        Continue();
    }
}
