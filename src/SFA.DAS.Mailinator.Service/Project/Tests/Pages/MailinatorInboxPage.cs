using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    internal class MailinatorInboxPage : MailinatorBasePage
    {
        protected override string PageTitle => "Public Messages";
        protected override By PageHeader => By.CssSelector("#inbox_pane");

        private readonly ScenarioContext _context;

        #region Locators
        private By EmailSubjectField => By.CssSelector(".jambo_table tr .ng-binding");
        #endregion

        internal MailinatorInboxPage(ScenarioContext context) : base(context) => _context = context;

        internal MailinatorEmailPage ClickOnEmail()
        {
            formCompletionHelper.Click(EmailSubjectField);
            return new MailinatorEmailPage(_context);
        }
    }
}
