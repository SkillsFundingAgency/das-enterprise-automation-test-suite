namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public class AdminAdministratorHubPage : AanBasePage
{
    protected override string PageTitle => "Administrator hub";

    public AdminAdministratorHubPage(ScenarioContext context) : base(context) => VerifyPage();

    public ManageEventsPage AccessManageEvents()
    {
        formCompletionHelper.ClickLinkByText("Manage events");
        return new ManageEventsPage(context);
    }
}
