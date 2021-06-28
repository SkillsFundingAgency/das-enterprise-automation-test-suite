using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.MailinatorPages
{
    public class MailinatorEmailPage : RegistrationBasePage
    {
        protected override string PageTitle => "Received";
        protected override By PageHeader => By.CssSelector(".sender-info");

        #region Locators
        private By EmailBodyFrame => By.Id("html_msg_body");
        private By AccessCodeText => By.XPath("//h2[contains(text(), 'ABC123')]");
        #endregion

        public MailinatorEmailPage(ScenarioContext context) : base(context) => VerifyPage();

        public bool VerifyAccessCode() => pageInteractionHelper.VerifyText(GetAccessCode(), config.RE_ConfirmCode);

        private string GetAccessCode()
        {
            frameHelper.SwitchToFrame(EmailBodyFrame);
            var text = javaScriptHelper.GetTextUsingJavaScript(AccessCodeText);
            frameHelper.SwitchToDefaultContent();
            return text;
        }
    }
}
