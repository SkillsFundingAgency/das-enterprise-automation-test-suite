using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class ConfirmUpdatedEmailPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "SecurityCode")] private IWebElement SecurityCodeInput;
        [FindsBy(How = How.Id, Using = "Password")] private IWebElement PasswordInput;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement ContinueButton;

        public ConfirmUpdatedEmailPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal ConfirmUpdatedEmailPage InputSecurityCode(string code)
        {
            _formCompletionHelper.EnterText(SecurityCodeInput, code);
            return this;
        }

        internal ConfirmUpdatedEmailPage InputPassword(string password)
        {
            _formCompletionHelper.EnterText(PasswordInput, password);
            return this;
        }

        internal AccountSettingsPage Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return new AccountSettingsPage(_context);
        }
    }
}