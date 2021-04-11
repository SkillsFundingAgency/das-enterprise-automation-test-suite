using NUnit.Framework;
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

        [Then(@"the apprentice is able to confirm the Employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer()
        {
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InComplete);
            apprenticeHomePage.ConfirmYourEmployer().SelectYes();
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.Complete);
        }

        [Then(@"the apprentice confirms the Employer details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheEmployerDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InComplete);
            apprenticeHomePage.ConfirmYourEmployer().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InCorrect);
        }

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain() => 
            apprenticeHomePage = apprenticeHomePage.ConfirmAlreadyConfirmedEmployer().ContinueToHomePage();

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider()
        {
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InComplete);
            apprenticeHomePage.ConfirmYourTrainingProvider().SelectYes();
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.Complete);
        }

        [Then(@"the apprentice confirms the Provider details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheProviderDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InComplete);
            apprenticeHomePage.ConfirmYourTrainingProvider().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InCorrect);
        }

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() => 
            apprenticeHomePage = apprenticeHomePage.ConfirmAlreadyConfirmedTrainingProvider().ContinueToHomePage();

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails()
        {
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InComplete);
            NavigateAndVerifyApprenticeshipDetails();
            apprenticeHomePage = _confirmYourApprenticeshipDetailsPage.SelectYes();
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.Complete);
        }

        [Then(@"the apprentice confirms the Apprenticeship details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheApprenticeshipDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InComplete);
            NavigateAndVerifyApprenticeshipDetails();
            apprenticeHomePage = _confirmYourApprenticeshipDetailsPage.SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InCorrect);
        }

        [Then(@"confirmed apprenticeship already page is displayed for trying to confirm again")]
        public void ThenConfirmedApprenticeshipAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = apprenticeHomePage.ConfirmAlreadyConfirmedApprenticeship();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            apprenticeHomePage = _alreadyConfirmedApprenticeshipDetailsPage.ContinueToHomePage();
        }

        private void NavigateAndVerifyApprenticeshipDetails()
        {
            _confirmYourApprenticeshipDetailsPage = apprenticeHomePage.ConfirmYourApprenticeship();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayed(_confirmYourApprenticeshipDetailsPage);
        }

        private void AssertSectionStatus(string sectionName, string expectedStatus) =>
            Assert.AreEqual(expectedStatus, apprenticeHomePage.GetTheSectionStatus(sectionName));
    }
}
