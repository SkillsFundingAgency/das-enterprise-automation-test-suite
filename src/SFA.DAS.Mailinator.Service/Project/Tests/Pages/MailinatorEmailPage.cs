using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    internal class MailinatorEmailPage : MailinatorBasePage
    {
        protected override string PageTitle => "Received";
        protected override By PageHeader => By.CssSelector(".sender-info");

        #region Locators
        private By EmailBodyFrame => By.Id("html_msg_body");
        
        private By EmailLink => By.XPath("//a[contains(text(),'https://')]");

        private By AccessCodeText(string code) => By.XPath($"//h2[contains(text(), '{code}')]");
        #endregion

        internal MailinatorEmailPage(ScenarioContext context) : base(context) { }

        internal void VerifyEmailLink()
        {
            frameHelper.SwitchToFrame(EmailBodyFrame);

            formCompletionHelper.ClickElement(EmailLink);
        }

        public bool VerifyAccessCode(string code) => pageInteractionHelper.VerifyText(GetAccessCode(code), code);

        private string GetAccessCode(string code)
        {
            frameHelper.SwitchToFrame(EmailBodyFrame);
            var text = javaScriptHelper.GetTextUsingJavaScript(AccessCodeText(code));
            frameHelper.SwitchToDefaultContent();
            return text;
        }
    }
}
