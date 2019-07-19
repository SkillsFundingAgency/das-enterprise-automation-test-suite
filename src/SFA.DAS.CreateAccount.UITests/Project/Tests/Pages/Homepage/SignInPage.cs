using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class SignInPage : BasePage
    {
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

        public SignInPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal AccountSettingsPage ValidLogin(string userName, string passWord)
        {
            EnterCredentials(userName, passWord);
            return new AccountSettingsPage(WebBrowserDriver);
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
            formCompletionHelper.ClickElement(CreateAccLink);
            return new SetUpAsAUserPage(WebBrowserDriver);
        }

        internal ForgottenCredentialsPage ClickForgottenYourPassword()
        {
            formCompletionHelper.ClickElement(ForgottenPasswordLink);
            return new ForgottenCredentialsPage(WebBrowserDriver);
        }

        internal string GetNotificationMessage()
        {
            return pageInteractionHelper.GetText(_notificationMessage);
        }

        internal string GetNotificationHeader()
        {
            return pageInteractionHelper.GetText(_notificationHeader);
        }

        private void EnterCredentials(string userName, string passWord)
        {
            EnterUserName(userName);
            EnterPassWord(passWord);
            ClickLoginButton();
        }

        private void EnterUserName(string userName)
        {
            formCompletionHelper.EnterText(EmailAddress, userName);
        }

        private void EnterPassWord(string passWord)
        {
            formCompletionHelper.EnterText(Password, passWord);
        }

        private void ClickLoginButton()
        {
            formCompletionHelper.ClickElement(LoginBtn);
        }

        public string GetEmailAddressErrorMessage()
        {
            return formCompletionHelper.GetText(_emailAddressErrorMessage);
        }

        public string GetPasswordErrorMessage()
        {
            return formCompletionHelper.GetText(_passwordErrorMessage);
        }

        public string GetHeaderEmailAddressErrorMessage()
        {
            return formCompletionHelper.GetText(_headerEmailErrorMessage);
        }

        public string GetHeaderPasswordErrorMessage()
        {
            return formCompletionHelper.GetText(_headerPasswordErrorMessage);
        }
    }
}