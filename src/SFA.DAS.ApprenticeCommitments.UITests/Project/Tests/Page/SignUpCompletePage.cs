using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SignUpCompletePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Your account has been created";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");
        protected override By ServiceHeader => By.CssSelector(".das-header__span");

        private readonly ScenarioContext _context;

        public SignUpCompletePage(ScenarioContext context) : base(context) => _context = context;

        public SignIntoApprenticeshipPortalPage ClickSignInToApprenticePortal()
        {
            formCompletionHelper.ClickLinkByText($"sign in to {ServiceName}");
            return new SignIntoApprenticeshipPortalPage(_context);
        }
    }
}
