using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ResetPasswordPage : PasswordBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Reset password";

        public ResetPasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _validPassword = $"{_validPassword}!%&";
            apprenticeCommitmentsConfig.AC_AccountPassword = _validPassword;
        }

        public PasswordResetSuccessfulPage CreatePassword()
        {
            SubmitPassword(_validPassword, _validPassword);
            return new PasswordResetSuccessfulPage(_context);
        }
    }
}
