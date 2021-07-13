using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.MailinatorPages
{
    public class MailinatorInboxPage : AEDBasePage
    {
        protected override string PageTitle => "Public Messages";
        protected override By PageHeader => By.CssSelector("#inbox_pane");
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailSubjectField => By.CssSelector(".jambo_table tr .ng-binding");
        #endregion

        public MailinatorInboxPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public MailinatorEmailPage ClickOnEmail()
        {
            formCompletionHelper.Click(EmailSubjectField);
            return new MailinatorEmailPage(_context);
        }
    }
}
