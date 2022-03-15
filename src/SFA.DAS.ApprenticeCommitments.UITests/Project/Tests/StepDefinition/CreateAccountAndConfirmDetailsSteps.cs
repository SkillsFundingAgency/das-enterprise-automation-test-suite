using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountAndConfirmDetailsSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private ApprenticeOverviewPage _apprenticeOverviewPage;
        private ApprenticeHomePage _apprenticeHomePage;

        public CreateAccountAndConfirmDetailsSteps(ScenarioContext context) : base(context) => _context = context;

        [Given(@"the apprentice creates the CMAD account")]
        public void ThenTheApprenticeCreatesTheCMADAccount() => createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().VerifyCMADSectionStatusToBeInCompleteOnHomePage();

        [Given(@"an apprentice has created and validated the account")]
        public void GivenAnApprenticeHasCreatedAndValidatedTheAccount()
            => createAccountStepsHelper.CreateAccountViaApi().NavigateToOverviewPageFromTopNavigationLink().VerifyDaysToConfirmWarning();

        [Then(@"the apprentice is able to navigate to the Help and Support from the Overview page")]
        public void ThenTheApprenticeIsAbleToNavigateToTheHelpAndSupportFromTheOverviewPage()
        {
            _apprenticeHomePage = new ApprenticeHomePage(_context, false).NavigateToHelpPageFromTopNavigationLink().NavigateToHomePageWithGoBackToTheDashboardButton();
            _apprenticeOverviewPage = _apprenticeHomePage.NavigateToOverviewPageFromTopNavigationLink();
            _apprenticeOverviewPage = _apprenticeOverviewPage.NavigateToHelpPageFromTopNavigationLink().NavigateToOverviewPageWithBackLink();
        }

        [Then(@"the apprentice is able to navigate to Home page back and forth from Overview and Help pages")]
        public void ThenTheApprenticeIsAbleToNavigateToHomePageBackAndForthFromOverviewAndHelpPages()
        {
            _apprenticeHomePage = _apprenticeOverviewPage.NavigateToHomePageFromTopNavigationLink().NavigateToOverviewPageFromLinkOnTheHomePage().NavigateToHomePageFromTopNavigationLink();
            _apprenticeHomePage = _apprenticeHomePage.NavigateToOverviewPageFromTopNavigationLink().NavigateToHomePageFromTopNavigationLink();
            _apprenticeHomePage = _apprenticeHomePage.NavigateToHelpAndSupportPageWithTheLinkOnHomePage().NavigateToHomePageWithBackLink();
            _apprenticeHomePage.NavigateToHelpPageFromTopNavigationLink().NavigateToHomePageWithBackLink();
        }

        [Then(@"the apprentice is able to logout from the service")]
        public void ThenTheApprenticeIsAbleToLogoutFromTheService() => _apprenticeHomePage.SignOutFromTheService().ClickSignBackInLinkFromSignOutPage();

        [Then(@"the apprentice can create account and confirm their details")]
        public void ThenTheApprenticeCanCreateAccountAndConfirmTheirDetails()
        {
            createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().NavigateToOverviewPageFromLinkOnTheHomePage();
            confirmMyApprenticeshipStepsHelper.ConfirmAllSectionsAndApprenticeship();
        }    
    }
}
