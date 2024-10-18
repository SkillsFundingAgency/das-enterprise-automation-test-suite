namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin
{
    public abstract class AdminConfirmNotificationPage : AanAdminBasePage
    {
        protected override string AccessibilityPageTitle => "Administrator hub";

        private static By NotificationBanner => By.CssSelector("#main-content > div:nth-child(1) > div > div > div.govuk-notification-banner__content > h3");
        protected override By PageHeader => NotificationBanner;
        private readonly string _status;

        public AdminConfirmNotificationPage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }
        protected override string PageTitle => $"Notification settings {_status}";

        public class ConfirmNotificationSuccess(ScenarioContext context) : AdminConfirmNotificationPage(context, "saved")
        {
        }

    }
}
