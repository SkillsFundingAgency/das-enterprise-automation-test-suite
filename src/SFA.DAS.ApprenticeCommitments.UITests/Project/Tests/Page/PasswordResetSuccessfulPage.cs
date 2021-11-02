using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class PasswordResetSuccessfulPage : EmailAndPasswordSuccessfulBasePage
    {
        protected override string PageTitle => "Password reset successful";
        protected override By ServiceHeader => NonClickableServiceHeader;

        private readonly ScenarioContext _context;

        public PasswordResetSuccessfulPage(ScenarioContext context) : base(context) => _context = context;

        public SignIntoMyApprenticeshipPage ReturnToSignInPage()
        {
            formCompletionHelper.ClickLinkByText($"{ServiceName}");
            return new SignIntoMyApprenticeshipPage(_context);
        }
    }
}
