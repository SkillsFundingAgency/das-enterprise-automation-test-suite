using static SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.AdminConfirmNotificationPage;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin
{
    public class NotificationsSettingsPage(ScenarioContext context) : SearchEventsBasePage(context)
    {
        protected override string PageTitle => "Notification settings";
        private static By SaveButton => By.Id("notification-settings-save");

        public ConfirmNotificationSuccess SelectYesAndSave()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            formCompletionHelper.ClickElement(SaveButton);
            return new ConfirmNotificationSuccess(context);
        }

        public ConfirmNotificationSuccess SelectNoAndSave()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            formCompletionHelper.ClickElement(SaveButton);
            return new ConfirmNotificationSuccess(context);
        }
    }
}
