using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class ForgottenCredentialsPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement _changeEmailInput;

        [FindsBy(How = How.Id, Using = "forgottenpassword-button")]
        private IWebElement _getResetCodeButton;

        public ForgottenCredentialsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal ForgottenCredentialsPage SetEmail(string email)
        {
            _formCompletionHelper.EnterText(_changeEmailInput, email);
            return this;
        }

        internal ResetCodeAndPassPage Continue()
        {
            _formCompletionHelper.ClickElement(_getResetCodeButton);
            return new ResetCodeAndPassPage(_context);
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