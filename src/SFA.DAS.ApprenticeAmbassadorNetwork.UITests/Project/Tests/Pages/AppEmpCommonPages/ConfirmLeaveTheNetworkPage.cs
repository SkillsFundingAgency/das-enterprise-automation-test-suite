namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class ConfirmLeaveTheNetworkPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Are you sure you want to leave?";

    public ConfirmedLeftNetworkPage ConfirmAndLeave()
    {
        Continue();
        return new ConfirmedLeftNetworkPage(context);
    }
}
