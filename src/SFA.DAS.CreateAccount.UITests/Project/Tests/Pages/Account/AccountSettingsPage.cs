using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    public class AccountSettingsPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ChangeLevyAccountLink => By.XPath(".//a[contains (text(), \'Switch account\')]");

        private By RenameAccountLink => By.XPath(".//a[contains (text(), \'Rename account\')]");

        private By ChangeEmailLink => By.XPath(".//a[contains (text(), \'Change your email address\')]");

        private By ChangePasswordLink => By.XPath(".//a[contains (text(), \'Change your password\')]");

        private By NotificationBox => By.CssSelector(".success-summary p");

        private By YourAccountLink => By.XPath("//a[contains (text(), \'Your accounts\')]");

        private By NotificationSettingsLink => By.XPath("//a[contains (text(), \'Notification settings\')]");

        private By SignOutBtn => By.XPath("//a[contains (text(), \'Sign out\')]");

        private By SettingsLink => By.XPath("//a[contains (text(), \'Settings\')]");

        private By AcivityTab => By.XPath("//a[contains(text(),\'Activity\')]");

        public AccountSettingsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal void ClickSignOut()
        {
            _formCompletionHelper.ClickElement(SignOutBtn);
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(SettingsLink);
        }

        internal AccountSettingsPage ClickChangeLevyAccountLink()
        {
            _formCompletionHelper.ClickElement(ChangeLevyAccountLink);
            return this;
        }

        internal ChangeEmailPage ChangeEmail()
        {
            _formCompletionHelper.ClickElement(ChangeEmailLink);
            return new ChangeEmailPage(_context);
        }

        internal ChangePasswordPage ChangePassword()
        {
            _formCompletionHelper.ClickElement(ChangePasswordLink);
            return new ChangePasswordPage(_context);
        }

        internal string AccountName()
        {
            return _pageInteractionHelper.GetText(SettingsLink);
        }

        internal AccountSettingsPage ClickSettingsLink()
        {
            _formCompletionHelper.ClickElement(SettingsLink);
            return this;
        }

        internal string GetNotification()
        {
            return _pageInteractionHelper.GetText(NotificationBox);
        }

        internal RenameAccountPage RenameAccount()
        {
            _formCompletionHelper.ClickElement(RenameAccountLink);
            return new RenameAccountPage(_context);
        }

        internal void ClickYourAccountsLink()
        {
            _formCompletionHelper.ClickElement(SettingsLink);
            _formCompletionHelper.ClickElement(YourAccountLink);
        }

        internal void ClickRenameAccountLink()
        {
            _formCompletionHelper.ClickElement(SettingsLink);
            _formCompletionHelper.ClickElement(RenameAccountLink);
        }

        internal void ClickChangeYourPasswordLink()
        {
            _formCompletionHelper.ClickElement(SettingsLink);
            _formCompletionHelper.ClickElement(ChangePasswordLink);
        }

        internal void ClickChangeYourEmailAddressLink()
        {
            _formCompletionHelper.ClickElement(SettingsLink);
            _formCompletionHelper.ClickElement(ChangeEmailLink);
        }

        internal void ClickNotificationSettingsLink()
        {
            _formCompletionHelper.ClickElement(SettingsLink);
            _formCompletionHelper.ClickElement(NotificationSettingsLink);
        }
    }
}