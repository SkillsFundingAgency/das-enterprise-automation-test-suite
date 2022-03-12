using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountAndConfirmDetailsSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private ApprenticeOverviewPage _apprenticeOverviewPage;

        public CreateAccountAndConfirmDetailsSteps(ScenarioContext context) : base(context) => _context = context;

        [Given(@"the apprentice creates the CMAD account")]
        public void ThenTheApprenticeCanCreateAccount() => createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().VerifyCMADSectionStatusToBeInCompleteOnHomePage();

        [Given(@"an apprentice has created and validated the account")]
        public void GivenAnApprenticeHasCreatedAndValidatedTheAccount()
            => createAccountStepsHelper.CreateAccountViaApi().NavigateToOverviewPageFromTopNavigationLink().VerifyDaysToConfirmWarning();

        [Then(@"the apprentice is able to navigate to the Help and Support from the Overview page")]
        public void ThenTheApprenticeIsAbleToNavigateToTheHelpAndSupportFromTheOverviewPage()
        {
            var apprenticeHomePage = _apprenticeOverviewPage.NavigateToHelpPageFromTopNavigationLink().NavigateToHomePageWithGoBackToTheDashboardButton();
            _apprenticeOverviewPage = apprenticeHomePage.NavigateToOverviewPageFromTopNavigationLink();
            _apprenticeOverviewPage = _apprenticeOverviewPage.NavigateToHelpPageFromTopNavigationLink().NavigateToOverviewPageWithBackLink();
        }

        [Then(@"the apprentice is able to navigate to Home page back and forth from Overview and Help pages")]
        public void ThenTheApprenticeIsAbleToNavigateToHomePageBackAndForthFromOverviewAndHelpPages()
        {
            var apprenticeHomePage = _apprenticeOverviewPage.NavigateToHomePageFromTopNavigationLink().NavigateToOverviewPageFromLinkOnTheHomePage().NavigateToHomePageFromTopNavigationLink();
            apprenticeHomePage = apprenticeHomePage.NavigateToOverviewPageFromTopNavigationLink().NavigateToHomePageFromTopNavigationLink();
            apprenticeHomePage = apprenticeHomePage.NavigateToHelpAndSupportPageWithTheLinkOnHomePage().NavigateToHomePageWithBackLink();
            apprenticeHomePage.NavigateToHelpPageFromTopNavigationLink().NavigateToHomePageWithBackLink();
        }

        [Then(@"the apprentice is able to logout from the service")]
        public void ThenTheApprenticeIsAbleToLogoutFromTheService() => _apprenticeOverviewPage.SignOutFromTheService().ClickSignBackInLinkFromSignOutPage();

        [Then(@"the apprentice can create account and confirm their details")]
        public void ThenTheApprenticeCanCreateAccountAndConfirmTheirDetails()
            => ConfirmAllSectionsAndApprenticeship(createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().NavigateToOverviewPageFromLinkOnTheHomePage());

        [Then(@"the apprentice confirms all the sections and the overall apprenticeship")]
        public void ThenTheApprenticeConfirmsTheOverallApprenticeship()
            => ConfirmAllSectionsAndApprenticeship(new ApprenticeHomePage(_context).NavigateToOverviewPageFromTopNavigationLink())
            .VerifyTrainingNameOnGreenHeaderBoxOnTheOverallApprenticeshipConfirmedPage()
            .NavigateBackToOverviewPage()
            .VerifyHeaderSummaryOnApprenticeOverviewPageAfterApprenticeshipConfirm()
            .NavigateToHomePageFromTopNavigationLink()
            .VerifyCMADSectionStatusToBeCompleteOnHomePage();

        private OverallApprenticeshipConfirmedPage ConfirmAllSectionsAndApprenticeship(ApprenticeOverviewPage apprenticeOverviewPage)
            => confirmMyApprenticeshipStepsHelper.ConfirmAllSectionsAndApprenticeship(apprenticeOverviewPage);
    }
}
