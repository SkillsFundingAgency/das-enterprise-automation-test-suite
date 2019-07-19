using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse
{
    public class SignInGovernmentPage : BasePage
    {
        private const string userid = "userId";
        [FindsBy(How = How.Id, Using = userid)] private IWebElement _userIdInput;
        [FindsBy(How = How.Id, Using = "password")] private IWebElement _passwordInput;
        [FindsBy(How = How.XPath, Using = ".//input[@value=\"Sign in\"]")] private IWebElement _signInButton;

        public SignInGovernmentPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.IsElementDisplayed(_userIdInput);
        }

        internal SignInGovernmentPage InputUserId(string userId)
        {
            formCompletionHelper.EnterText(_userIdInput, userId);
            return this;
        }

        internal SignInGovernmentPage InputPassword(string password)
        {
            formCompletionHelper.EnterText(_passwordInput, password);
            return this;
        }

        internal GrantAuthorityPage SignIn()
        {
            formCompletionHelper.ClickElement(_signInButton);
            return new GrantAuthorityPage(WebBrowserDriver);
        }
        internal void SignInWithInvalidDetails()
        {
            formCompletionHelper.ClickElement(_signInButton);
        }

        internal string GetUserId()
        {
            return pageInteractionHelper.GetText(_userIdInput);
        }

        internal string GetPassword()
        {
            return pageInteractionHelper.GetText(_passwordInput);
        }
    }
}