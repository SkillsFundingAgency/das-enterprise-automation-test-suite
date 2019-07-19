using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    class NotificationSettingsPage : BasePage
    {
        private const string PageTitle = "Notification Settings";

        public NotificationSettingsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }
    }
}