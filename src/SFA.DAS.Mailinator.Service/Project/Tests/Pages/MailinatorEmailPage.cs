using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    public class MailinatorEmailPage(ScenarioContext context) : MailinatorBasePage(context)
    {
        protected override string PageTitle => "Received";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => By.CssSelector(".sender-info");

        #region Locators
        private static By EmailBodyFrame => By.CssSelector("#html_msg_body");

        private static By EmailLink(string linktext) => By.XPath($"//a[contains(text(), '{linktext}')]");

        #endregion

        internal void OpenLink(string linktext)
        {
            frameHelper.SwitchToFrame(EmailBodyFrame);
            formCompletionHelper.ClickElement(EmailLink(linktext));
            frameHelper.SwitchToDefaultContent();
        }
    }
}
