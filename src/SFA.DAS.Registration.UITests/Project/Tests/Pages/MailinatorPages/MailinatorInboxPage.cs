using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.MailinatorPages
{
    public class MailinatorInboxPage : RegistrationBasePage
    {
        protected override string PageTitle => "public";
        protected override By PageHeader => By.CssSelector("b.ng-binding");
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailSubjectField => By.CssSelector("a.ng-binding");
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
