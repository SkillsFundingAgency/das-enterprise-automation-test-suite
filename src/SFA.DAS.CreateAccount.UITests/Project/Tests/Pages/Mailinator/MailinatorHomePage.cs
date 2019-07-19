using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Mailinator
{
    class MailinatorHomePage : BasePage
    {
        private By _emailTextBox = By.XPath("//input[contains(@id, 'inboxfield')]");
        private By _goButton = By.XPath("//button[contains(@class, 'btn btn-default')]");

        public MailinatorHomePage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public void EnterTextIntoEmailTextBox(string email)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _emailTextBox, email);
        }

        public void ClickOnGoButton()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _goButton);
        }
    }
}