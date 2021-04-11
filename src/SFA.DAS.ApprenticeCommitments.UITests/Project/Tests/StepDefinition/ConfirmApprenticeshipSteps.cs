using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    class ConfirmApprenticeshipSteps : BaseSteps
    {
        private ConfirmYourApprenticeshipDetailsPage _confirmYourApprenticeshipDetailsPage;
        private AlreadyConfirmedApprenticeshipDetailsPage _alreadyConfirmedApprenticeshipDetailsPage;

        public ConfirmApprenticeshipSteps(ScenarioContext context) : base(context) =>
            apprenticeHomePage = new ApprenticeHomePage(context);

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() => 
            apprenticeHomePage = apprenticeHomePage.ConfirmAlreadyConfirmedTrainingProvider().ContinueToHomePage();

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
             apprenticeHomePage = apprenticeHomePage.ConfirmAlreadyConfirmedEmployer().ContinueToHomePage();

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails()
        {
            NavigateAndVerifyApprenticeshipDetails();
            apprenticeHomePage = _confirmYourApprenticeshipDetailsPage.SelectYes();
        }

        [Then(@"confirmed apprenticeship already page is displayed for trying to confirm again")]
        public void ThenConfirmedApprenticeshipAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = apprenticeHomePage.ConfirmAlreadyConfirmedApprenticeship();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            apprenticeHomePage = _alreadyConfirmedApprenticeshipDetailsPage.ContinueToHomePage();
        }

        [Then(@"the apprentice confirms the Apprenticeship details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheApprenticeshipDetailsDisplayedAsIncorrect()
        {
            NavigateAndVerifyApprenticeshipDetails();
            apprenticeHomePage = _confirmYourApprenticeshipDetailsPage.SelectNo().ReturnToApprenticeHomePage();
        }

        [Then(@"the apprentice is able to confirm the Employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer() =>
            apprenticeHomePage = apprenticeHomePage.VerifyTheSectionStatus(SectionHelper.Section1, StatusHelper.InComplete)
            .ConfirmYourEmployer().SelectYes()
            .VerifyTheSectionStatus(SectionHelper.Section1, StatusHelper.Complete);

        [Then(@"the apprentice confirms the Employer details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheEmployerDetailsDisplayedAsIncorrect() =>
            apprenticeHomePage = apprenticeHomePage.VerifyTheSectionStatus(SectionHelper.Section1, StatusHelper.InComplete)
            .ConfirmYourEmployer().SelectNo()
            .ReturnToApprenticeHomePage()
            .VerifyTheSectionStatus(SectionHelper.Section1, StatusHelper.InCorrect);

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider() =>
            apprenticeHomePage = apprenticeHomePage.VerifyTheSectionStatus(SectionHelper.Section2, StatusHelper.InComplete)
            .ConfirmYourTrainingProvider().SelectYes()
            .VerifyTheSectionStatus(SectionHelper.Section2, StatusHelper.Complete);

        [Then(@"the apprentice confirms the Provider details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheProviderDetailsDisplayedAsIncorrect() =>
            apprenticeHomePage = apprenticeHomePage.VerifyTheSectionStatus(SectionHelper.Section2, StatusHelper.InComplete)
            .ConfirmYourTrainingProvider().SelectNo()
            .ReturnToApprenticeHomePage()
            .VerifyTheSectionStatus(SectionHelper.Section2, StatusHelper.InCorrect);

        private void NavigateAndVerifyApprenticeshipDetails()
        {
            _confirmYourApprenticeshipDetailsPage = apprenticeHomePage.ConfirmYourApprenticeship();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayed(_confirmYourApprenticeshipDetailsPage);
        }
    }
}
