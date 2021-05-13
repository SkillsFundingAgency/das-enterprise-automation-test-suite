using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class PasswordResetSuccessfulPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Password reset successful";

        private readonly ScenarioContext _context;

        public PasswordResetSuccessfulPage(ScenarioContext context) : base(context) => _context = context;

        public SignIntoApprenticeshipPortalPage ReturnToApprenticeshipPortal()
        {
            formCompletionHelper.ClickLinkByText("Apprenticeship portal");
            return new SignIntoApprenticeshipPortalPage(_context);
        }
    }
}
