using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Mailinator
{
    public class MailinatorLandingPage : RegistrationBasePage
    {
        protected override string PageTitle => "Mailinator";
        protected override By PageHeader => By.CssSelector(".nav-title");
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailTextBox => By.Id("addOverlay");
        private By GoButton => By.Id("go-to-public");
        #endregion

        public MailinatorLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public MailinatorLandingPage EnterEmailAndClickOnGoButton(string email)
        {
            formCompletionHelper.EnterText(EmailTextBox, email);
            formCompletionHelper.Click(GoButton);
            return this;
        }
    }
}
