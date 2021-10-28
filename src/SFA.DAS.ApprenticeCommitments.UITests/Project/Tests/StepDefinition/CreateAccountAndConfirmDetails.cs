using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountAndConfirmDetails : BaseSteps
    {
        private readonly ScenarioContext _context;
        private ApprenticeOverviewPage _apprenticeOverviewPage;

        public CreateAccountAndConfirmDetails(ScenarioContext context) : base(context) => _context = context;

        [Then(@"the apprentice can create account")]
        public void ThenTheApprenticeCanCreateAccount() => createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().VerifyInCompleteTag();

        [Given(@"an apprentice has created and validated the account")]
        public void GivenAnApprenticeHasCreatedAndValidatedTheAccount() => createAccountStepsHelper.CreateAccountViaApi().NavigateToOverviewPageFromTopNavigationLink().VerifyDaysToConfirmWarning();

        [When(@"the apprentice confirms all the Apprenticeship sections")]
        public void WhenTheApprenticeConfirmsAllTheApprenticeshipSections() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmAllSections();

        [Then(@"the apprentice is able to confirm the Overall Apprenticeship status")]
        public void ThenTheApprenticeIsAbleToConfirmTheOverallApprenticeshipStatus()
        {
            _apprenticeOverviewPage.ConfirmYourApprenticeshipFromTheTopBanner().VerifyTrainingNameOnPageHeader().NavigateBackToOverviewPage();
            _apprenticeOverviewPage.VerifyPageAfterApprenticeshipConfirm();
        }

        [Then(@"the apprentice is able to navigate to the Help and Support from the link on Overview page and Navigation menu link")]
        public void ThenTheApprenticeIsAbleToNavigateToTheHelpAndSupport()
        {
            var apprenticeHomePage = _apprenticeOverviewPage.NavigateToHelpAndSupportPageWithTheLinkOnTheContentOfOverviewPage().NavigateToHomePageWithReturnToHomePageButton();
            _apprenticeOverviewPage = apprenticeHomePage.NavigateToOverviewPageFromTopNavigationLink();
            _apprenticeOverviewPage = _apprenticeOverviewPage.NavigateToHelpAndSupportPageWithTheLinkOnTheContentOfOverviewPage().NavigateToOverviewPageWithBackLink();
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

        [Then(@"the apprentice can confirm apprenticeship")]
        public void ThenTheApprenticeCanConfirmApprenticeship() 
            => ConfirmAllSectionsAndApprenticeship(new ApprenticeHomePage(_context).NavigateToOverviewPageFromLinkOnTheHomePage())
            .NavigateToHomePageFromTopNavigationLink()
            .VerifyCompleteTag();

        private TransactionCompletePage ConfirmAllSectionsAndApprenticeship(ApprenticeOverviewPage apprenticeOverviewPage) 
            => confirmMyApprenticeshipStepsHelper.ConfirmAllSectionsAndApprenticeship(apprenticeOverviewPage);
    }
}
