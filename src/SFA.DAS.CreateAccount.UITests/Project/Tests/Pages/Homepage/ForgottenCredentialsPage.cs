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

        public ForgottenCredentialsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal ForgottenCredentialsPage SetEmail(string email)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _changeEmailInput, email);
            return this;
        }

        internal ResetCodeAndPassPage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _getResetCodeButton);
            return new ResetCodeAndPassPage(WebBrowserDriver);
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