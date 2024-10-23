namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin
{
    public abstract class AdminConfirmNotificationPage : AanAdminBasePage
    {
        protected override string AccessibilityPageTitle => "Administrator hub";

        protected override By PageHeader => By.CssSelector(".govuk-notification-banner");

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
