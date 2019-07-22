using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse
{
    public class SignInGovernmentPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private readonly By _userIdInput = By.Id("userId");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _signInButton = By.XPath(".//input[@value=\"Sign in\"]");

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
            return new GrantAuthorityPage(_context);
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