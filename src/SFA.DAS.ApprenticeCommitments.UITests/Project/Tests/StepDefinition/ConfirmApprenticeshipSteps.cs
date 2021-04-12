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
        private ApprenticeHomePage _apprenticeHomePage;
        private readonly ScenarioContext _context;

        public ConfirmApprenticeshipSteps(ScenarioContext context) : base(context) => _context = context;

        [Then(@"the apprentice is able to confirm the Employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer()
        {
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InComplete);
            _apprenticeHomePage = new ApprenticeHomePage(_context).ConfirmYourEmployer().SelectYes();
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.Complete);
        }

        [Then(@"the apprentice confirms the Employer details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheEmployerDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InComplete);
            new ApprenticeHomePage(_context).ConfirmYourEmployer().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InCorrect);
        }

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain() => 
            _apprenticeHomePage.ConfirmAlreadyConfirmedEmployer().ContinueToHomePage();

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider()
        {
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InComplete);
            _apprenticeHomePage = new ApprenticeHomePage(_context).ConfirmYourTrainingProvider().SelectYes();
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.Complete);
        }

        [Then(@"the apprentice confirms the Provider details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheProviderDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InComplete);
            new ApprenticeHomePage(_context).ConfirmYourTrainingProvider().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InCorrect);
        }

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() => 
            _apprenticeHomePage.ConfirmAlreadyConfirmedTrainingProvider().ContinueToHomePage();

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails()
        {
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InComplete);
            _apprenticeHomePage = NavigateAndVerifyApprenticeshipDetails().SelectYes();
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.Complete);
        }

        [Then(@"the apprentice confirms the Apprenticeship details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheApprenticeshipDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InComplete);
            NavigateAndVerifyApprenticeshipDetails().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InCorrect);
        }

        [Then(@"confirmed apprenticeship already page is displayed for trying to confirm again")]
        public void ThenConfirmedApprenticeshipAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = _apprenticeHomePage.ConfirmAlreadyConfirmedApprenticeship();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            _alreadyConfirmedApprenticeshipDetailsPage.ContinueToHomePage();
        }

        private ConfirmYourApprenticeshipDetailsPage NavigateAndVerifyApprenticeshipDetails()
        {
            _confirmYourApprenticeshipDetailsPage = new ApprenticeHomePage(_context).ConfirmYourApprenticeshipDetails();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayed(_confirmYourApprenticeshipDetailsPage);
            return _confirmYourApprenticeshipDetailsPage;
        }

        private void AssertSectionStatus(string sectionName, string expectedStatus) =>
            Assert.AreEqual(expectedStatus, new ApprenticeHomePage(_context).GetTheSectionStatus(sectionName));
    }
}
