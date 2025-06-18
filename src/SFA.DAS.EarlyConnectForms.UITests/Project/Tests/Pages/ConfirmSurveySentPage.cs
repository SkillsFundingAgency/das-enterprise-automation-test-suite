using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public abstract class ConfirmSurveySentPage : EarlyConnectBasePage
    {
        protected static By NotificationBanner => By.CssSelector("#main-content > div > div > div");
        protected override By PageHeader => NotificationBanner;

        private readonly string _status;

        public ConfirmSurveySentPage(ScenarioContext context, string status): base(context, false)
        {
            _status = status;

            VerifyPage();
        }
        protected override string PageTitle => $"Details sent to our team\r\n{_status}";
        protected override string AccessibilityPageTitle => "Details sent to our team";

        public class ApplicantSurveySummitedPage(ScenarioContext context) : ConfirmSurveySentPage(context, "You’ll hear from an adviser soon")
        {
        }
    }
}
