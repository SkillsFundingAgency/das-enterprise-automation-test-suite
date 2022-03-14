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

        [Then(@"the coc notification should not be displayed")]
        public void ThenTheCocNotificationShouldNotBeDisplayed() => _apprenticeOverviewPage = ApprenticeOverviewPage().VerifyCoCNotificationIsNotDisplayed();

        [Then(@"only the latest apprenticeship should be visible")]
        public void ThenOnlyTheLatestApprenticeshipShouldBeVisible()
        {
            var invitation = createAccountStepsHelper.OpenLatestInvitation(2);
            _apprenticeOverviewPage = invitation.CTAOnStartPageToSignIn().GoToApprenticeHomePage().NavigateToOverviewPageFromLinkOnTheHomePage();
            _apprenticeOverviewPage.VerifyDaysToConfirmWarning();
        }

        [Given(@"the apprentice completed confirm my apprenticeship details")]
        public void GivenTheApprenticeCompletedConfirmMyApprenticeshipDetails() => createAccountStepsHelper.CreateAccountViaUIAndConfirmApprenticeshipViaDb().SignOutFromTheService();

        [Then(@"the apprentice is able to confirm the Employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourEmployer(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Employer details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployerDetailsAgainAsCorrect() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourEmployer(StatusHelper.WaitingForCorrection);

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourTrainingProvider(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Provider details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheProviderDetailsAgainAsCorrect() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourTrainingProvider(StatusHelper.WaitingForCorrection);

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmApprenticeshipDetails(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Apprenticeship details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetailsAgainAsCorrect() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmApprenticeshipDetails(StatusHelper.WaitingForCorrection);

        [Then(@"the apprentice is able to confirm 'How the apprenticeship will be delivered' section")]
        public void ThenTheApprenticeIsAbleToConfirmHowTheApprenticeshipWillBeDeliveredSection() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmHowYourApprenticeshipWillBeDelivered(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm Roles and responsibilities")]
        public void ThenTheApprenticeIsAbleToConfirmRolesAndResponsibilities() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmRolesAndResponsibilities(StatusHelper.InComplete);

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _apprenticeOverviewPage.GoToAlreadyConfirmedEmployerPage().ContinueToCMADOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection1Status(StatusHelper.Complete);
        }

        [Then(@"the apprentice confirms the Employer details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheEmployerDetailsDisplayedAsIncorrect()
        {
            confirmMyApprenticeshipStepsHelper.AssertSection1Status(StatusHelper.InComplete);
            _apprenticeOverviewPage = ApprenticeOverviewPage().GoToConfirmYourEmployerPage().SelectNoToConfirmEmployer().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection1Status(StatusHelper.WaitingForCorrection);
        }

        [Then(@"the apprentice is able to change the answer and choose to confirm the Employer details as Incorrect")]
        public void ThenTheApprenticeIsAbleToChangeTheAnswerAndChooseToConfirmTheEmployerDetailsAsIncorrect()
        {
            _apprenticeOverviewPage.GoToAlreadyConfirmedEmployerPage().ChangeMyAnswerAction().SelectNoToConfirmEmployerPostChangingAnswer().ReturnToApprenticeOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection1Status(StatusHelper.WaitingForCorrection);
        }

        [Then(@"an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm employer page")]
        public void ThenAnAppropriateErrorDisplayedWhenTheApprenticeChoosesCTAWithoutMakingASelectionOnConfirmEmployerPage()
        {
            _apprenticeOverviewPage.GoToConfirmYourEmployerPage().ClickOnConfirmButton().VerifyErrorSummaryBoxAndErrorFieldText().SelectYesAndContinueToOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection1Status(StatusHelper.Complete);
        }

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeOverviewPage.GoToAlreadyConfirmedTrainingProviderPage().ContinueToCMADOverviewPage();

        [Then(@"the apprentice confirms the Provider details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheProviderDetailsDisplayedAsIncorrect()
        {
            confirmMyApprenticeshipStepsHelper.AssertSection2Status(StatusHelper.InComplete);
            _apprenticeOverviewPage = ApprenticeOverviewPage().GoToConfirmYourTrainingProviderPage().SelectNoToConfirmTrainingProvider().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection2Status(StatusHelper.WaitingForCorrection);
        }

        [Then(@"the apprentice is able to change the answer and choose to confirm the Provider details as Incorrect")]
        public void ThenTheApprenticeIsAbleToChangeTheAnswerAndChooseToConfirmTheProviderDetailsAsIncorrect()
        {
            _apprenticeOverviewPage.GoToAlreadyConfirmedTrainingProviderPage().ChangeMyAnswerAction().SelectNoToConfirmTrainingProviderPostChangingAnswer().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection2Status(StatusHelper.WaitingForCorrection);
        }

        [Then(@"an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm provider page")]
        public void ThenAnAppropriateErrorDisplayedWhenTheApprenticeChoosesCTAWithoutMakingASelectionOnConfirmProviderPage()
        {
            _apprenticeOverviewPage.GoToConfirmYourTrainingProviderPage().ClickOnConfirmButton().VerifyErrorSummaryBoxAndErrorFieldText().SelectYesAndContinueToOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection2Status(StatusHelper.Complete);
        }

        [Then(@"confirmed apprenticeship already page is displayed for trying to confirm again")]
        public void ThenConfirmedApprenticeshipAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = _apprenticeOverviewPage.GoToAlreadyConfirmedApprenticeshipDetailsPage();
            confirmMyApprenticeshipStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            _alreadyConfirmedApprenticeshipDetailsPage.ContinueToCMADOverviewPage();
        }

        [Then(@"the apprentice verifies and confirms the Apprenticeship details displayed as Incorrect")]
        public void ThenTheApprenticeVerifiesAndConfirmsTheApprenticeshipDetailsDisplayedAsIncorrect()
        {
            confirmMyApprenticeshipStepsHelper.AssertSection3Status(StatusHelper.InComplete);
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.NavigateAndVerifyApprenticeshipDetails().SelectNoToConfirmYourDetails().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection3Status(StatusHelper.WaitingForCorrection);
        }

        [Then(@"the apprentice confirms the Apprenticeship details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheApprenticeshipDetailsDisplayedAsIncorrect()
        {
            _apprenticeOverviewPage = ApprenticeOverviewPage().GoToConfirmYourApprenticeshipDetailsPage().SelectNoToConfirmYourDetails().ReturnToApprenticeOverviewPage();
        }

        [Then(@"the apprentice is able to change the answer and choose to confirm the Apprenticeship details as Incorrect")]
        public void ThenTheApprenticeIsAbleToChangeTheAnswerAndChooseToConfirmTheApprenticeshipDetailsAsIncorrect()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = _apprenticeOverviewPage.GoToAlreadyConfirmedApprenticeshipDetailsPage().ChangeMyAnswerAction();
            confirmMyApprenticeshipStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            _alreadyConfirmedApprenticeshipDetailsPage.SelectNoToConfirmYourDetailsPostChangingAnswer().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection3Status(StatusHelper.WaitingForCorrection);
        }

        [Then(@"an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm details page")]
        public void ThenAnAppropriateErrorDisplayedWhenTheApprenticeChoosesCTAWithoutMakingASelectionOnConfirmDetailsPage()
        {
            _apprenticeOverviewPage.GoToConfirmYourApprenticeshipDetailsPage().ClickOnConfirmButton().VerifyErrorSummaryBoxAndErrorFieldText().SelectYesAndContinueToOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection3Status(StatusHelper.Complete);
        }

        [Then(@"confirmed 'How the apprenticeship will be delivered' section page is displayed for trying to confirm again")]
        public void ThenConfirmedHowTheApprenticeshipWillBeDeliveredSectionPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeOverviewPage.GoToAlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage().ContinueToCMADOverviewPage();


        [Then(@"confirmed Roles already page is displayed for trying to confirm again")]
        public void ThenConfirmedRolesAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedRolesAndResponsibilitiesPage = _apprenticeOverviewPage.GoToAlreadyConfirmedRolesAndResponsibilitiesPage();
            confirmMyApprenticeshipStepsHelper.VerifyRolesAndResponsibilitiesForAlreadyConfirmedPage(_alreadyConfirmedRolesAndResponsibilitiesPage)
                .NavigateBackToCMADOverviewPage();
        }

        private ApprenticeOverviewPage ApprenticeOverviewPage() => new ApprenticeOverviewPage(_context);
    }
}
