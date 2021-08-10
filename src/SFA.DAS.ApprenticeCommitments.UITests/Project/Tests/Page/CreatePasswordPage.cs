using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreatePasswordPage : PasswordBasePage
    {
        protected override string PageTitle => "Create password";
        private By PrivacyLink => By.XPath("//a[text()='privacy statement']");
        private By TermsLink => By.XPath("//a[text()='terms and conditions']");

        private readonly ScenarioContext _context;

        public CreatePasswordPage(ScenarioContext context) : base(context) 
        {
            VerifyPage(PrivacyLink);
            VerifyPage(TermsLink);
            _context = context;
        }

        public SignUpCompletePage CreatePassword()
        {
            SubmitPassword(_validPassword, _validPassword);
            return new SignUpCompletePage(_context);
        }
    }
}
