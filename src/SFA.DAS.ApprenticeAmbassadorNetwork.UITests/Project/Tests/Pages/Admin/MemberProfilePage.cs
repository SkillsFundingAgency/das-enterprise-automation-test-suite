namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public class MemberProfilePage(ScenarioContext context) : SearchEventsBasePage(context)
{

    protected override string PageTitle => "Alan Burns";
    public RemoveAmbassadorPage RemoveAmbassador()
    {
        Continue();
        return new RemoveAmbassadorPage(context);

    }
}
