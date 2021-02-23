using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SigUpCompletePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Your account has been created";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        private readonly ScenarioContext _context;

        public SigUpCompletePage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage();
        }

        public SignIntoApprenticeshipPortalPage ClickSignInToApprenticePortal()
        {
            formCompletionHelper.ClickLinkByText("sign in to Apprenticeship portal");

            return new SignIntoApprenticeshipPortalPage(_context);
        }
    }
}
