using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    internal class MailinatorLandingPage : MailinatorBasePage
    {
        protected override string PageTitle => "MAILINATOR";
        protected override By PageHeader => By.CssSelector(".nav-title");
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailTextBox => By.Id("addOverlay");
        private By GoButton => By.Id("go-to-public");
        #endregion

        internal MailinatorLandingPage(ScenarioContext context) : base(context) => _context = context;

        internal MailinatorInboxPage EnterEmailAndClickOnGoButton(string organisationEmailAddress)
        {
            formCompletionHelper.EnterText(EmailTextBox, organisationEmailAddress);

            formCompletionHelper.Click(GoButton);

            return new MailinatorInboxPage(_context);
        }
    }
}
