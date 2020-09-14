using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.MailinatorPages
{
    public class MailinatorEmailPage : RegistrationBasePage
    {
        protected override string PageTitle => "public";
        protected override By PageHeader => By.CssSelector("b.ng-binding");

        #region Locators
        private By EmailBodyFrame => By.Id("msg_body");
        private By AccessCodeText => By.XPath("//h2[contains(text(), 'ABC123')]");
        #endregion

        public MailinatorEmailPage(ScenarioContext context) : base(context) => VerifyPage();

        public bool VerifyAccessCode(string expectedCode) => pageInteractionHelper.VerifyText(GetAccessCode(), expectedCode);

        private string GetAccessCode()
        {
            tabHelper.SwitchToFrame(EmailBodyFrame);
            var text = pageInteractionHelper.GetTextUsingJavaScript(AccessCodeText);
            tabHelper.SwitchToDefaultContent();
            return text;
        }
    }
}
