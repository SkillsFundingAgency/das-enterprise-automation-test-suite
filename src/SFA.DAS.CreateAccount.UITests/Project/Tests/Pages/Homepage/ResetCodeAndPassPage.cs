using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class ResetCodeAndPassPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "PasswordResetCode")] private IWebElement _resetCodeInput;
        [FindsBy(How = How.Id, Using = "Password")] private IWebElement _newPasswordInput;
        [FindsBy(How = How.Id, Using = "ConfirmPassword")] private IWebElement _confirmPasswordInput;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement _continueButton;

        public ResetCodeAndPassPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal ResetCodeAndPassPage SetCode(string code)
        {
            _formCompletionHelper.EnterText(_resetCodeInput, code);
            return this;
        }

        internal ResetCodeAndPassPage SetNewPassword(string password)
        {
            _formCompletionHelper.EnterText(_newPasswordInput, password);
            return this;
        }

        internal ResetCodeAndPassPage ConfirmPassword(string password)
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