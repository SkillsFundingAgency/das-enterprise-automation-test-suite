using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AccountLockedPage : RegistrationBasePage
    {
        protected override string PageTitle => "Account locked";
        protected override By PageHeader => By.CssSelector(".bold-large");
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailTextBox => By.Id("Email");
        private By UnlockCodeTextBox => By.Id("UnlockCode");
        private By UnlockAccountButton => By.CssSelector("button[name='command']");
        #endregion

        public AccountLockedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SignInPage EnterDetailsAndClickUnlockButton(string email)
        {
            formCompletionHelper.EnterText(EmailTextBox, email);
            formCompletionHelper.EnterText(UnlockCodeTextBox, config.RE_ConfirmCode);
            formCompletionHelper.ClickElement(UnlockAccountButton);
            return new SignInPage(_context);
        }
    }
}
