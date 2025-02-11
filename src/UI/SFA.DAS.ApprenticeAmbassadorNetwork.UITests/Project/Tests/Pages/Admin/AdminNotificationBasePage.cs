namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public abstract class AdminNotificationBasePage(ScenarioContext context) : AanAdminBasePage(context)
{
    public ManageEventsPage AccessManageEvents()
    {
        formCompletionHelper.ClickLinkByText("Manage events");

        return new ManageEventsPage(context);
    }

    public AdminAdministratorHubPage AccessHub()
    {
        formCompletionHelper.ClickLinkByText("Manage AAN service");
        return new AdminAdministratorHubPage(context);
    }
}
