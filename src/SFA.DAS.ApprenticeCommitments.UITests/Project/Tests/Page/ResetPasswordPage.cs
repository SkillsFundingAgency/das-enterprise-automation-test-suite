using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ResetPasswordPage : CreatePasswordBasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Reset password";

        public ResetPasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _validPassword = $"{_validPassword}!%&";
            objectContext.UpdateApprenticePassword(_validPassword);
        }

        public PasswordResetSuccessfulPage UpdatePassword()
        {
            SubmitPassword(_validPassword, _validPassword, true);
            return new PasswordResetSuccessfulPage(_context);
        }
    }
}
