using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountAndConfirmDetailsSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private ApprenticeHomePage _apprenticeHomePage;
        private FullyConfirmedOverviewPage _fullyConfirmedOverviewPage;

        public CreateAccountAndConfirmDetailsSteps(ScenarioContext context) : base(context) => _context = context;

        [Given(@"the apprentice creates the CMAD account")]
        public void ThenTheApprenticeCreatesTheCMADAccount() => createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().VerifyDashboardCMADSectionWhenInCompleteOnHomePage();

        [Given(@"an apprentice has created and validated the account")]
        public void GivenAnApprenticeHasCreatedAndValidatedTheAccount()
            => createAccountStepsHelper.CreateAccountViaApi().NavigateToOverviewPageFromTopNavigationLink().VerifyDaysToConfirmWarning();

        [Then(@"the apprentice is able to navigate to the Help and Support from Home and Fully confirmed page")]
        public void ThenTheApprenticeIsAbleToNavigateToTheHelpAndSupportFromHomeAndFullyConfirmedPage()
        {
            _apprenticeHomePage = new ApprenticeHomePage(_context, false).NavigateToHelpPageFromTopNavigationLink().NavigateToHomePageWithGoBackToTheDashboardButton();

            _fullyConfirmedOverviewPage = _apprenticeHomePage.NavigateToFullyConfirmedOverviewPageFromTopNavigationLink()
                .NavigateToHelpPageFromTopNavigationLink().NavigateToFullyConfirmedOverviewPageWithBackLink();
        }

        [Then(@"the apprentice is able to navigate to Home page back and forth from Fully confirmed Overview and Help pages")]
        public void ThenTheApprenticeIsAbleToNavigateToHomePageBackAndForthFromFullyConfirmedOverviewAndHelpPages()
        {
            _apprenticeHomePage = _fullyConfirmedOverviewPage.NavigateToHomePageFromTopNavigationLink()
                .NavigateToFullyConfirmedOverviewPageWithMyApprenticeshipDetailsLinkOnTheHomePage().NavigateToHomePageFromTopNavigationLink()
                .NavigateToFullyConfirmedOverviewPageFromTopNavigationLink().NavigateToHomePageFromTopNavigationLink()
                .NavigateToHelpAndSupportPageWithTheLinkOnHomePage().NavigateToHomePageWithBackLink()
                .NavigateToHelpPageFromTopNavigationLink().NavigateToHomePageWithBackLink();
        }

        [Then(@"the apprentice is able to navigate to Roles and HYAWD pages from Fully confirmed Overview page")]
        public void ThenTheApprenticeIsAbleToNavigateToRolesAndHYAWDPagesFromFullyConfirmedOverviewPage()
        {
            _fullyConfirmedOverviewPage = _apprenticeHomePage.NavigateToFullyConfirmedOverviewPageWithMyApprenticeshipDetailsLinkOnTheHomePage().GoToConfirmedRolesPage().NavigateBackToFullyConfirmedOverviewPage();
            _apprenticeHomePage = _fullyConfirmedOverviewPage.GoToConfirmedHowYourApprenticeshipWillBeDeliveredPage().NavigateBackToFullyConfirmedOverviewPage().NavigateToHomePageFromTopNavigationLink();
        }

        [Then(@"the apprentice is able to logout from the service")]
        public void ThenTheApprenticeIsAbleToLogoutFromTheService() => _apprenticeHomePage.SignOutFromTheService().ClickSignBackInLinkFromSignOutPage();

        [Then(@"the apprentice can create account and confirm their details")]
        public void ThenTheApprenticeCanCreateAccountAndConfirmTheirDetails()
        {
            createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().NavigateToOverviewPageWithCmadLinkOnTheHomePage();
            confirmMyApprenticeshipStepsHelper.ConfirmAllSectionsAndOverallApprenticeship();
        }
    }
}
