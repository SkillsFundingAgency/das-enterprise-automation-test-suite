using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ResetPasswordPage : CreatePasswordBasePage
    {
        protected override string PageTitle => "Reset password";

        public ResetPasswordPage(ScenarioContext context) : base(context)
        {
            
            validPassword = $"{validPassword}!%&";
            objectContext.UpdateApprenticePassword(validPassword);
        }

        public PasswordResetSuccessfulPage UpdatePassword()
        {
            SubmitPassword(validPassword, validPassword, true);
            return new PasswordResetSuccessfulPage(context);
        }
    }
}
