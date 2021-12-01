using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    internal class MailinatorLandingPage : MailinatorBasePage
    {
        protected override string PageTitle => "Mailinator";
        protected override By PageHeader => By.CssSelector(".gel-heading-title");
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailTextBox => By.CssSelector("#search");
        private By GoButton => By.CssSelector("#site-header button");
        #endregion

        internal MailinatorLandingPage(ScenarioContext context) : base(context, false)
        {
            _context = context;

            VerifyPage(() => pageInteractionHelper.FindElements(PageHeader));
        }

        internal MailinatorInboxPage EnterEmailAndClickOnGoButton(string organisationEmailAddress)
        {
            formCompletionHelper.EnterText(EmailTextBox, organisationEmailAddress);

            formCompletionHelper.ClickButtonByText(GoButton, "GO");

            return new MailinatorInboxPage(_context);
        }
    }
}
