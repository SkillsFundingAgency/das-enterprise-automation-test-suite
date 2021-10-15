using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountAndConfirmDetails : BaseSteps
    {
        private readonly ScenarioContext _context;

        public CreateAccountAndConfirmDetails(ScenarioContext context) : base(context) => _context = context;

        [Then(@"the apprentice can create account")]
        public void ThenTheApprenticeCanCreateAccount() => createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().VerifyInCompleteTag();

        [Given(@"an apprentice has created and validated the account")]
        public void GivenAnApprenticeHasCreatedAndValidatedTheAccount() =>
        createAccountStepsHelper.CreateAccount().NavigateToOverviewPageFromTopNavigationLink().VerifyDaysToConfirmWarning();

        [When(@"the apprentice confirms all the Apprenticeship sections")]
        public void WhenTheApprenticeConfirmsAllTheApprenticeshipSections() => confirmMyApprenticeshipStepsHelper.ConfirmAllSections();

        [Then(@"the apprentice can create account and confirm their details")]
        public void ThenTheApprenticeCanCreateAccountAndConfirmTheirDetails()
        {
            var apprenticeOverviewPage = createAccountStepsHelper.ConfirmIdentityAndGoToApprenticeHomePage().NavigateToOverviewPageFromLinkOnTheHomePage();

            confirmMyApprenticeshipStepsHelper.ConfirmAllSectionsAndApprenticeship(apprenticeOverviewPage);
        }

        [Then(@"the apprentice can confirm apprenticeship")]
        public void ThenTheApprenticeCanConfirmApprenticeship()
        {
            var page = new ApprenticeHomePage(_context).NavigateToOverviewPageFromLinkOnTheHomePage();

            confirmMyApprenticeshipStepsHelper
                .ConfirmAllSections(page)
                .ConfirmYourApprenticeshipFromTheTopBanner()
                .NavigateToHomePageFromTopNavigationLink()
                .VerifyCompleteTag();
        }
    }
}
