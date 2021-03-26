using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ResetPasswordPage : PasswordBasePage
    {
        protected override string PageTitle => "Reset password";

        private readonly ScenarioContext _context;

        public ResetPasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _validPassword = $"{_validPassword}!%&";
        }

        public PasswordResetSuccessfulPage CreatePassword()
        {
            SubmitPassword(_validPassword, _validPassword);
            return new PasswordResetSuccessfulPage(_context);
        }
    }
}
