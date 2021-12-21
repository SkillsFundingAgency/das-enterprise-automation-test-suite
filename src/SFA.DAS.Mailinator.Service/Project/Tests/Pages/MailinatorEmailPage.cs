using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    public class MailinatorEmailPage : MailinatorBasePage
    {
        protected override string PageTitle => "Received";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => By.CssSelector(".sender-info");

        #region Locators
        private By EmailBodyFrame => By.CssSelector("#html_msg_body");

        private By TexthtmlMsgBody => By.CssSelector("#texthtml_msg_body");


        private By EmailLink(string linktext) => By.CssSelector($"a[href*='{linktext}']");

        private By TextTab => By.CssSelector("#pills-textbuthtml-tab");

        private By AccessCodeText(string code) => By.XPath($"//h2[contains(text(), '{code}')]");
        #endregion

        public MailinatorEmailPage(ScenarioContext context) : base(context) { }

        internal void OpenLink(string linktext)
        {
            formCompletionHelper.ClickElement(TextTab);

            frameHelper.SwitchToFrame(TexthtmlMsgBody);

            formCompletionHelper.ClickElement(EmailLink(linktext));

            frameHelper.SwitchToDefaultContent();
        }

        public MailinatorEmailPage VerifyAccessCode(string code) { pageInteractionHelper.VerifyText(GetAccessCode(code), code); return this; }

        private string GetAccessCode(string code)
        {
            frameHelper.SwitchToFrame(EmailBodyFrame);
            var text = javaScriptHelper.GetTextUsingJavaScript(AccessCodeText(code));
            frameHelper.SwitchToDefaultContent();
            return text;
        }
    }
}
