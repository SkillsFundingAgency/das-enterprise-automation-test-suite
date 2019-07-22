using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class SignInPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private const string passwordelementid = "Password";
        private const string createanaccountLinktext = "create an account";
        private const string forgottenPasswordLinkXPath = ".//a[contains (text(), \'Forgotten your password\')]";
        [FindsBy(How = How.XPath, Using = "//*[@id=\"EmailAddress\"]")] private IWebElement EmailAddress { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Password\"]")] private IWebElement Password { get; set; }
        [FindsBy(How = How.ClassName, Using = "button")] private IWebElement LoginBtn { get; set; }
        [FindsBy(How = How.LinkText, Using = createanaccountLinktext)] private IWebElement CreateAccLink { get; set; }
        [FindsBy(How = How.XPath, Using = forgottenPasswordLinkXPath)] private IWebElement ForgottenPasswordLink { get; set; }
        private By _notificationHeader = By.XPath("//h1[contains(text(),'Account Unlocked')]");
        private By _notificationMessage = By.XPath("//h1[contains(text(),'Account Unlocked')]/../p");
        private By _emailAddressErrorMessage = By.XPath("//span[contains (text(), \'Enter a valid email address\')]");
        private By _passwordErrorMessage = By.XPath("//span[contains (text(), \'Enter password\')]");
        private By _headerEmailErrorMessage = By.XPath("(//ul[contains(@class,\'error-summary-list\')]/li)[1]");
        private By _headerPasswordErrorMessage = By.XPath("(//ul[contains(@class,\'error-summary-list\')]/li)[2]");

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal AccountSettingsPage ValidLogin(string userName, string passWord)
        {
            EnterCredentials(userName, passWord);
            return new AccountSettingsPage(_context);
        }

        internal SignInPage InvalidLogin(string invalidUser, string invalidPassword)
        {
            EnterCredentials(invalidUser, invalidPassword);
            return this;
        }

        internal SignInPage IncompleteLogin()
        {
            ClickLoginButton();
            return this;
        }

        internal SetUpAsAUserPage ClickCreateAccount()
        {
            _formCompletionHelper.ClickElement(CreateAccLink);
            return new SetUpAsAUserPage(_context);
        }

        internal ForgottenCredentialsPage ClickForgottenYourPassword()
        {
            _formCompletionHelper.ClickElement(ForgottenPasswordLink);
            return new ForgottenCredentialsPage(_context);
        }

        internal string GetNotificationMessage()
        {
            return _pageInteractionHelper.GetText(_notificationMessage);
        }

        internal string GetNotificationHeader()
        {
            return _pageInteractionHelper.GetText(_notificationHeader);
        }

        private void EnterCredentials(string userName, string passWord)
        {
            EnterUserName(userName);
            EnterPassWord(passWord);
            ClickLoginButton();
        }

        private void EnterUserName(string userName)
        {
            _formCompletionHelper.EnterText(EmailAddress, userName);
        }

        private void EnterPassWord(string passWord)
        {
            _formCompletionHelper.EnterText(Password, passWord);
        }

        private void ClickLoginButton()
        {
            _formCompletionHelper.ClickElement(LoginBtn);
        }

        public string GetEmailAddressErrorMessage()
        {
            return _pageInteractionHelper.GetText(_emailAddressErrorMessage);
        }

        public string GetPasswordErrorMessage()
        {
            return _pageInteractionHelper.GetText(_passwordErrorMessage);
        }

        public string GetHeaderEmailAddressErrorMessage()
        {
            return _pageInteractionHelper.GetText(_headerEmailErrorMessage);
        }

        public string GetHeaderPasswordErrorMessage()
        {
            return _pageInteractionHelper.GetText(_headerPasswordErrorMessage);
        }
    }
}