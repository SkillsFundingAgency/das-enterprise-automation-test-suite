using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin
{
    [Binding, Scope(Tag = "@aanadmin")]
    public class Admin_Notifications_Steps(ScenarioContext context) : AdminAdministratorHubPage(context)
    {

        [Given(@"user select notification settings on dashboard")]
        public void GivenUserSelectNotificationSettingsOnDashboard()
        {
            new AdminAdministratorHubPage(context)
                .ManageNotifications();
        }

        [Then(@"the user select Yes for emails and confirm notification saved")]
        public void WhenTheUserSelectYesForEmails()
        {
            new NotificationsSettingsPage(context)
                .SelectYesAndSave();
        }
      
    }
}
