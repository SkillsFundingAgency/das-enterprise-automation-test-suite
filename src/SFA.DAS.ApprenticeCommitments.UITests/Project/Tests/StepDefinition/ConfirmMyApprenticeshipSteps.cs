using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ConfirmMyApprenticeshipSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private ApprenticeOverviewPage _apprenticeOverviewPage;
        private AlreadyConfirmedApprenticeshipDetailsPage _alreadyConfirmedApprenticeshipDetailsPage;
        private AlreadyConfirmedRolesAndResponsibilitiesPage _alreadyConfirmedRolesAndResponsibilitiesPage;
        
        public ConfirmMyApprenticeshipSteps(ScenarioContext context) : base(context) => _context = context;

        [Then(@"only the latest apprenticeship should be visible")]
        public void ThenOnlyTheLatestApprenticeshipShouldBeVisible()
        {
            var invitation = createAccountStepsHelper.OpenLatestInvitation(2);

            _apprenticeOverviewPage = invitation.CTAOnStartPageToSignIn().GoToApprenticeHomePage().NavigateToOverviewPageFromLinkOnTheHomePage();
            
            _apprenticeOverviewPage.VerifyDaysToConfirmWarning();
        }

        [Given(@"the apprentice completed confirm my apprenticeship details")]
        public void GivenTheApprenticeCompletedConfirmMyApprenticeshipDetails() => createAccountStepsHelper.CreateAccountAndConfirmApprenticeshipViaDb().SignOutFromTheService();

        [Then(@"the apprentice is able to confirm the Employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourEmployer(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Employer details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployerDetailsAgainAsCorrect() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourEmployer(StatusHelper.InCorrect);

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourTrainingProvider(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Provider details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheProviderDetailsAgainAsCorrect() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourTrainingProvider(StatusHelper.InCorrect);

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmApprenticeshipDetails(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Apprenticeship details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetailsAgainAsCorrect() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmApprenticeshipDetails(StatusHelper.InCorrect);

        [Then(@"the apprentice is able to confirm 'How the apprenticeship will be delivered' section")]
        public void ThenTheApprenticeIsAbleToConfirmHowTheApprenticeshipWillBeDeliveredSection() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmHowYourApprenticeshipWillBeDelivered(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm Roles and responsibilities")]
        public void ThenTheApprenticeIsAbleToConfirmRolesAndResponsibilities() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmRolesAndResponsibilities(StatusHelper.InComplete);

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain() => _apprenticeOverviewPage.ConfirmAlreadyConfirmedEmployer().ContinueToHomePage();


        [Then(@"the apprentice confirms the Employer details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheEmployerDetailsDisplayedAsIncorrect()
        {
            confirmMyApprenticeshipStepsHelper.AssertSection1Status(StatusHelper.InComplete);
            _apprenticeOverviewPage = new ApprenticeOverviewPage(_context).ConfirmYourEmployer().SelectNoToConfirmEmployer().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection1Status(StatusHelper.InCorrect);
        }

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeOverviewPage.ConfirmAlreadyConfirmedTrainingProvider().ContinueToHomePage();

        [Then(@"the apprentice confirms the Provider details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheProviderDetailsDisplayedAsIncorrect()
        {
            confirmMyApprenticeshipStepsHelper.AssertSection2Status(StatusHelper.InComplete);
            _apprenticeOverviewPage = new ApprenticeOverviewPage(_context).ConfirmYourTrainingProvider().SelectNoToConfirmTrainingProvider().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection2Status(StatusHelper.InCorrect);
        }


        [Then(@"confirmed apprenticeship already page is displayed for trying to confirm again")]
        public void ThenConfirmedApprenticeshipAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = _apprenticeOverviewPage.ConfirmAlreadyConfirmedApprenticeship();
            confirmMyApprenticeshipStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            _alreadyConfirmedApprenticeshipDetailsPage.ContinueToHomePage();
        }

        [Then(@"the apprentice confirms the Apprenticeship details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheApprenticeshipDetailsDisplayedAsIncorrect()
        {
            confirmMyApprenticeshipStepsHelper.AssertSection3Status(StatusHelper.InComplete);
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.NavigateAndVerifyApprenticeshipDetails().SelectNoConfirmYourDetails().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection3Status(StatusHelper.InCorrect);
        }

        [Then(@"confirmed 'How the apprenticeship will be delivered' section page is displayed for trying to confirm again")]
        public void ThenConfirmedHowTheApprenticeshipWillBeDeliveredSectionPageIsDisplayedForTryingToConfirmAgain() => 
            _apprenticeOverviewPage.ConfirmAlreadyConfirmedHowYourApprenticeshipWillBeDelivered().ContinueToHomePage();

        
        [Then(@"confirmed Roles already page is displayed for trying to confirm again")]
        public void ThenConfirmedRolesAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedRolesAndResponsibilitiesPage = _apprenticeOverviewPage.ConfirmAlreadyConfirmedRolesAndResponsibilities();
            confirmMyApprenticeshipStepsHelper.VerifyRolesAndResponsibilitiesForAlreadyConfirmedPage(_alreadyConfirmedRolesAndResponsibilitiesPage);
            _alreadyConfirmedRolesAndResponsibilitiesPage.ContinueToHomePage();
        }
    }
}
