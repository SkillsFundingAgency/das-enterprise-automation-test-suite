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

        public AccountSettingsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal void ClickSignOut()
        {
            _formCompletionHelper.ClickElement(_signOutBtn);
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(_settingsLink);
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
            return _pageInteractionHelper.GetText(_settingsLink);
        }

        internal AccountSettingsPage ClickSettingsLink()
        {
            _formCompletionHelper.ClickElement(_settingsLink);
            return this;
        }

        internal string GetNotification()
        {
            return NotificationBox.Text;
        }

        internal RenameAccountPage RenameAccount()
        {
            _formCompletionHelper.ClickElement(RenameAccountLink);
            return new RenameAccountPage(_context);
        }

        internal void ClickYourAccountsLink()
        {
            _formCompletionHelper.ClickElement(_settingsLink);
            _formCompletionHelper.ClickElement(_yourAccountLink);
        }

        internal void ClickRenameAccountLink()
        {
            _formCompletionHelper.ClickElement(_settingsLink);
            _formCompletionHelper.ClickElement(RenameAccountLink);
        }

        internal void ClickChangeYourPasswordLink()
        {
            _formCompletionHelper.ClickElement(_settingsLink);
            _formCompletionHelper.ClickElement(ChangePasswordLink);
        }

        internal void ClickChangeYourEmailAddressLink()
        {
            _formCompletionHelper.ClickElement(_settingsLink);
            _formCompletionHelper.ClickElement(ChangeEmailLink);
        }

        internal void ClickNotificationSettingsLink()
        {
            _formCompletionHelper.ClickElement(_settingsLink);
            _formCompletionHelper.ClickElement(_notificationSettingsLink);
        }
    }
}