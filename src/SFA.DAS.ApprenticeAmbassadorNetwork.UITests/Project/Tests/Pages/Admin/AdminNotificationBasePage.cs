namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

public abstract class AdminNotificationBasePage : AanAdminBasePage
{
    public AdminNotificationBasePage(ScenarioContext context) : base(context)
    {

    }

    public ManageEventsPage AccessManageEvents()
    {
        formCompletionHelper.ClickLinkByText("Manage events");

        return new ManageEventsPage(context);
    }
}
