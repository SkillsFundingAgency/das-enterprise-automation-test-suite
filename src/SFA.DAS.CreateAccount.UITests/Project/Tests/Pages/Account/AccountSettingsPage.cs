using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class AccountSettingsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Switch account\')]")]
        private IWebElement ChangeLevyAccountLink;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Rename account\')]")]
        private IWebElement RenameAccountLink;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Change your email address\')]")]
        private IWebElement ChangeEmailLink;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Change your password\')]")]
        private IWebElement ChangePasswordLink;
        [FindsBy(How = How.CssSelector, Using = ".success-summary p")]
        private IWebElement NotificationBox;
        private By _yourAccountLink = By.XPath("//a[contains (text(), \'Your accounts\')]");
        private By _notificationSettingsLink = By.XPath("//a[contains (text(), \'Notification settings\')]");
        private By _signOutBtn = By.XPath("//a[contains (text(), \'Sign out\')]");
        private By _settingsLink = By.XPath("//a[contains (text(), \'Settings\')]");
        private By _acivityTab = By.XPath("//a[contains(text(),\'Activity\')]");

        public AccountSettingsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal void ClickSignOut()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _signOutBtn);
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.IsElementDisplayed(WebBrowserDriver, _settingsLink);
        }

        internal AccountSettingsPage ClickChangeLevyAccountLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, ChangeLevyAccountLink);
            return this;
        }

        internal ChangeEmailPage ChangeEmail()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, ChangeEmailLink);
            return new ChangeEmailPage(WebBrowserDriver);
        }

        internal ChangePasswordPage ChangePassword()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, ChangePasswordLink);
            return new ChangePasswordPage(WebBrowserDriver);
        }

        internal string AccountName()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _settingsLink);
        }

        internal AccountSettingsPage ClickSettingsLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _settingsLink);
            return this;
        }

        internal string GetNotification()
        {
            return NotificationBox.Text;
        }

        internal RenameAccountPage RenameAccount()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, RenameAccountLink);
            return new RenameAccountPage(WebBrowserDriver);
        }

        internal void ClickYourAccountsLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _settingsLink);
            formCompletionHelper.ClickElement(WebBrowserDriver, _yourAccountLink);
        }

        internal void ClickRenameAccountLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _settingsLink);
            formCompletionHelper.ClickElement(WebBrowserDriver, RenameAccountLink);
        }

        internal void ClickChangeYourPasswordLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _settingsLink);
            formCompletionHelper.ClickElement(WebBrowserDriver, ChangePasswordLink);
        }

        internal void ClickChangeYourEmailAddressLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _settingsLink);
            formCompletionHelper.ClickElement(WebBrowserDriver, ChangeEmailLink);
        }

        internal void ClickNotificationSettingsLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _settingsLink);
            formCompletionHelper.ClickElement(WebBrowserDriver, _notificationSettingsLink);
        }
    }
}