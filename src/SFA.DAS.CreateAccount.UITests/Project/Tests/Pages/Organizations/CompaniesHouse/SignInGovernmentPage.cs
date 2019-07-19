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

        public SignInGovernmentPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(_userIdInput);
        }

        internal SignInGovernmentPage InputUserId(string userId)
        {
            _formCompletionHelper.EnterText(_userIdInput, userId);
            return this;
        }

        internal SignInGovernmentPage InputPassword(string password)
        {
            _formCompletionHelper.EnterText(_passwordInput, password);
            return this;
        }

        internal GrantAuthorityPage SignIn()
        {
            _formCompletionHelper.ClickElement(_signInButton);
            return new GrantAuthorityPage(context);
        }
        internal void SignInWithInvalidDetails()
        {
            _formCompletionHelper.ClickElement(_signInButton);
        }

        internal string GetUserId()
        {
            return _pageInteractionHelper.GetText(_userIdInput);
        }

        internal string GetPassword()
        {
            return _pageInteractionHelper.GetText(_passwordInput);
        }
    }
}