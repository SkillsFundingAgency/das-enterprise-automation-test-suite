using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Mailinator
{
    class MailinatorInboxPage : BasePage
    {
        private By _emailSubjectField = By.XPath("//td[contains(text(),'Access code: apprenticeship service')]");

        public MailinatorInboxPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public string GetEmailSubject()
        {
            return formCompletionHelper.GetText(WebBrowserDriver, _emailSubjectField);
        }

        public void ClickOnEmailToOpenIt()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _emailSubjectField);
        }

        public bool IsEmailPresent()
        {
            return formCompletionHelper.IsElementDisplayed(WebBrowserDriver, _emailSubjectField);
        }
    }
}