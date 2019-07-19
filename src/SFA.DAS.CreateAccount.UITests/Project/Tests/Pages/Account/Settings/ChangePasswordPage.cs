using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class ChangePasswordPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "CurrentPassword")] private IWebElement _currentPasswordInput;
        [FindsBy(How = How.Id, Using = "NewPassword")] private IWebElement _newPasswordInput;
        [FindsBy(How = How.Id, Using = "ConfirmPassword")] private IWebElement _confirmPasswordInput;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement _continueButton;
        private const string PageTitle = "Change your password";

        public ChangePasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public bool IsPagePresented()
        {
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal ChangePasswordPage SetCurrentPassword(string password)
        {
            _formCompletionHelper.EnterText(_currentPasswordInput, password);
            return this;
        }

        internal ChangePasswordPage SetNewPassword(string password)
        {
            _formCompletionHelper.EnterText(_newPasswordInput, password);
            return this;
        }

        internal ChangePasswordPage ConfirmPassword(string password)
        {
            _formCompletionHelper.EnterText(_confirmPasswordInput, password);
            return this;
        }

        internal AccountSettingsPage Continue()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new AccountSettingsPage(_context);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary\"]//ul//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}