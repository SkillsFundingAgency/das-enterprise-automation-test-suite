using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Mailinator
{
    class MailinatorEmailPage : BasePage
    {
        private By _accessCodeText = By.XPath("//h2[contains(text(), 'ABC123')]");
        private By _emailBodyFrame = By.XPath("//iframe[contains(@id, 'msg_body')]");

        public MailinatorEmailPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public string GetAccessCode()
        {
            pageInteractionHelper.SwitchToFrame(WebBrowserDriver, _emailBodyFrame);
            return formCompletionHelper.GetText(WebBrowserDriver, _accessCodeText);
        }

        public bool IsEmailBodyFramePresent()
        {
            return formCompletionHelper.IsElementDisplayed(WebBrowserDriver, _emailBodyFrame);
        }
    }
}