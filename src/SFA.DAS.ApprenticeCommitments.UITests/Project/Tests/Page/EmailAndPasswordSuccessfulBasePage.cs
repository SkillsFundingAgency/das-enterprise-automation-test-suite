using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class EmailAndPasswordSuccessfulBasePage : ApprenticeCommitmentsBasePage
    {
        private readonly ScenarioContext _context;

        private By PostLogoutRedirectUri => By.CssSelector(".PostLogoutRedirectUri");

        public EmailAndPasswordSuccessfulBasePage(ScenarioContext context) : base(context, verifyServiceHeader: false) => _context = context;

        public ApprenticeOverviewPage ReturnToMyApprenticeship()
        {
            ClickMyApprenticeship();
            return new ApprenticeOverviewPage(_context, false);
        }

        public CreateMyApprenticeshipAccountPage ReturnToCreateMyApprenticeshipAccountPage()
        {
            ClickMyApprenticeship();
            return new CreateMyApprenticeshipAccountPage(_context);
        }

        private void ClickMyApprenticeship() => formCompletionHelper.ClickLinkByText(PostLogoutRedirectUri, "My apprenticeship");
    }
}
