using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ConfirmMyApprenticeshipSteps(ScenarioContext context) : BaseSteps(context)
    {
        private ApprenticeOverviewPage _apprenticeOverviewPage;
        private AlreadyConfirmedApprenticeshipDetailsPage _alreadyConfirmedApprenticeshipDetailsPage;
        private AlreadyConfirmedRolesAndResponsibilitiesPage _alreadyConfirmedRolesAndResponsibilitiesPage;

        [Then(@"the coc notification should not be displayed")]
        public void ThenTheCocNotificationShouldNotBeDisplayed() => _apprenticeOverviewPage = ApprenticeOverviewPage().VerifyCoCNotificationIsNotDisplayed();

        [Then(@"only the latest apprenticeship should be visible")]
        public void ThenOnlyTheLatestApprenticeshipShouldBeVisible()
        {
            var invitation = createAccountStepsHelper.OpenLatestInvitation(2);
            _apprenticeOverviewPage = invitation.CTAOnStartPageToSignIn().GoToApprenticeHomePage()
                .NavigateToOverviewPageWithCmadLinkOnTheHomePage().VerifyDaysToConfirmWarning();
        }

        [Given(@"the apprentice creates the account and confirms the apprenticeship details")]
        public void GivenTheApprenticeCreatesTheAccountAndConfirmsTheApprenticeshipDetails() => createAccountStepsHelper.CreateAccountViaUIAndConfirmApprenticeshipViaDb().SignOutFromTheService();

        [Then(@"the apprentice is able to confirm the Employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourEmployer(OverviewPageHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourTrainingProvider(OverviewPageHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmYourApprenticeshipDetails(OverviewPageHelper.InComplete, isRegularApp: true);

        [Then(@"the apprentice is able to confirm 'How the apprenticeship will be delivered' section")]
        public void ThenTheApprenticeIsAbleToConfirmHowTheApprenticeshipWillBeDeliveredSection() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmHowYourApprenticeshipWillBeDelivered(OverviewPageHelper.InComplete);

        [Then(@"the apprentice is able to confirm Roles and responsibilities by checking Negative flows")]
        public void ThenTheApprenticeIsAbleToConfirmRolesAndResponsibilitiesByCheckingNegativeFlows() => _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.ConfirmRolesAndResponsibilitiesWithNegativeFlows(OverviewPageHelper.InComplete);

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _apprenticeOverviewPage.GoToAlreadyConfirmedEmployerPage().ContinueToCMADOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection1Status(OverviewPageHelper.Complete);
        }

        [Then(@"the apprentice is able to change the answer and choose to confirm the Employer details as Incorrect")]
        public void ThenTheApprenticeIsAbleToChangeTheAnswerAndChooseToConfirmTheEmployerDetailsAsIncorrect()
        {
            _apprenticeOverviewPage.GoToAlreadyConfirmedEmployerPage().ChangeMyAnswerAction().SelectNoToConfirmEmployerPostChangingAnswer().ReturnToApprenticeOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection1Status(OverviewPageHelper.WaitingForCorrection);
        }

        [Then(@"an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm employer page")]
        public void ThenAnAppropriateErrorDisplayedWhenTheApprenticeChoosesCTAWithoutMakingASelectionOnConfirmEmployerPage()
        {
            _apprenticeOverviewPage.GoToConfirmYourEmployerPage().ClickOnConfirmButton().VerifyErrorSummaryBoxAndErrorFieldText().SelectYesAndContinueToOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection1Status(OverviewPageHelper.Complete);
        }

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeOverviewPage.GoToAlreadyConfirmedTrainingProviderPage().ContinueToCMADOverviewPage();

        [Then(@"the apprentice is able to change the answer and choose to confirm the Provider details as Incorrect")]
        public void ThenTheApprenticeIsAbleToChangeTheAnswerAndChooseToConfirmTheProviderDetailsAsIncorrect()
        {
            _apprenticeOverviewPage.GoToAlreadyConfirmedTrainingProviderPage().ChangeMyAnswerAction().SelectNoToConfirmTrainingProviderPostChangingAnswer().ReturnToApprenticeOverviewPage();
            confirmMyApprenticeshipStepsHelper.AssertSection2Status(OverviewPageHelper.WaitingForCorrection);
        }

        [Then(@"an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm provider page")]
        public void ThenAnAppropriateErrorDisplayedWhenTheApprenticeChoosesCTAWithoutMakingASelectionOnConfirmProviderPage()
        {
            _apprenticeOverviewPage.GoToConfirmYourTrainingProviderPage().ClickOnConfirmButton().VerifyErrorSummaryBoxAndErrorFieldText().SelectYesAndContinueToOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection2Status(OverviewPageHelper.Complete);
        }

        [Then(@"confirmed apprenticeship already page is displayed for trying to confirm again")]
        public void ThenConfirmedApprenticeshipAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = _apprenticeOverviewPage.GoToAlreadyConfirmedApprenticeshipDetailsPage();
            confirmMyApprenticeshipStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            _alreadyConfirmedApprenticeshipDetailsPage.ContinueToCMADOverviewPage();
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
            confirmMyApprenticeshipStepsHelper.AssertSection3Status(OverviewPageHelper.WaitingForCorrection);
        }

        [Then(@"an appropriate error displayed when the apprentice chooses CTA without making a selection on Confirm details page")]
        public void ThenAnAppropriateErrorDisplayedWhenTheApprenticeChoosesCTAWithoutMakingASelectionOnConfirmDetailsPage()
        {
            _apprenticeOverviewPage.GoToConfirmYourApprenticeshipDetailsPage().ClickOnConfirmButton().VerifyErrorSummaryBoxAndErrorFieldText().SelectYesAndContinueToOverviewPage();
            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection3Status(OverviewPageHelper.Complete);
        }

        [Then(@"confirmed 'How the apprenticeship will be delivered' section page is displayed for trying to confirm again")]
        public void ThenConfirmedHowTheApprenticeshipWillBeDeliveredSectionPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeOverviewPage.GoToAlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage().ContinueToCMADOverviewPage();


        [Then(@"confirmed Roles page is displayed for trying to confirm again")]
        public void ThenConfirmedRolesPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedRolesAndResponsibilitiesPage = _apprenticeOverviewPage.GoToAlreadyConfirmedRolesAndResponsibilitiesPage();
            _apprenticeOverviewPage = ConfirmMyApprenticeshipStepsHelper.VerifyRolesAndResponsibilitiesForAlreadyConfirmedPage(_alreadyConfirmedRolesAndResponsibilitiesPage)
                .NavigateBackToCMADOverviewPage();
        }

        [Then(@"the apprentice confirms all the sections and the overall (Regular|Portable) apprenticeship")]
        public void ThenTheApprenticeConfirmsAllTheSectionsAndTheOverallApprenticeship(string appType)
        {
            new ApprenticeHomePage(context).NavigateToOverviewPageFromTopNavigationLink();

            confirmMyApprenticeshipStepsHelper.ConfirmAllSectionsAndOverallApprenticeship(IsRegularApp(appType)).VerifyTrainingNameOnGreenHeaderBoxOnTheOverallApprenticeshipConfirmedPage().NavigateBackToOverviewPage();

            _apprenticeOverviewPage = confirmMyApprenticeshipStepsHelper.AssertSection6Status(OverviewPageHelper.Complete);

            VerifyOverviewPageAndHomePageAfterOVerallConfirmation();
        }

        [Then(@"the apprentice confirms the overall apprenticeship")]
        public void ThenTheApprenticeConfirmsTheOverallApprenticeship()
        {
            _apprenticeOverviewPage.VerifyTopBannerOnOverviewPageBeforeOverallConfirmation().ConfirmOverallApprenticeship().NavigateBackToOverviewPage();
            VerifyOverviewPageAndHomePageAfterOVerallConfirmation();
        }

        [Then(@"the apprentice can navigate to CMAD Details confirmation page and confirm their apprenticeship is flexijob")]
        public void ThenTheApprenticeCanNavigateToCMADDetailsConfirmationPageAndConfirmTheirApprenticeshipIsFlexijob()
        {
            confirmMyApprenticeshipStepsHelper.NavigateAndVerifyFlexijobApprenticeshipDetails();
        }

        [Then(@"the apprentice verifies the (Regular|Portable) apprenticeship information displayed on the fully confirmed overview page")]
        public void ThenTheApprenticeVerifiesTheApprenticeshipInformationDisplayedOnTheFullyConfirmedOverviewPage(string appType)
        {
            confirmMyApprenticeshipStepsHelper.VerifyFullyConfirmedAppOverviewPageDetails(IsRegularApp(appType)).NavigateToHomePageFromTopNavigationLink();
        }

        private static bool IsRegularApp(string appType) => appType.CompareToIgnoreCase("Regular");

        private ApprenticeOverviewPage ApprenticeOverviewPage() => new(context);

        private ApprenticeHomePage VerifyOverviewPageAndHomePageAfterOVerallConfirmation() => _apprenticeOverviewPage.VerifyHeaderSummaryOnApprenticeOverviewPageAfterApprenticeshipConfirm().NavigateToHomePageFromTopNavigationLink()
            .VerifyCMADCardOnHomePageOnceFullyConfirmed();
    }
}
