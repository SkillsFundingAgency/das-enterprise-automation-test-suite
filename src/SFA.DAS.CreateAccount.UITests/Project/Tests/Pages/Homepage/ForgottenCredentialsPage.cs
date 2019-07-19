using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class ForgottenCredentialsPage : BasePage
    {
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
            return new ResetCodeAndPassPage(context);
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