using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.MailinatorPages
{
    public class MailinatorEmailPage : AEDBasePage
    {
        protected override string PageTitle => "Received";
        protected override By PageHeader => By.CssSelector(".sender-info");

        #region Locators
        private By EmailBodyFrame => By.Id("html_msg_body");
        private By AedEmailLink => By.XPath("//a[contains(text(),'https://')]");
        #endregion

        public MailinatorEmailPage(ScenarioContext context) : base(context) => VerifyPage();

        public void VerifyEmailLink()
        {
            frameHelper.SwitchToFrame(EmailBodyFrame);
            formCompletionHelper.ClickElement(AedEmailLink);
        }
    }
}
