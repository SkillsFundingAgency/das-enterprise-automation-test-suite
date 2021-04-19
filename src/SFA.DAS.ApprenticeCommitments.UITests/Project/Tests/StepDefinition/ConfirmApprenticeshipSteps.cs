using NUnit.Framework;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    class ConfirmApprenticeshipSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private ApprenticeHomePage _apprenticeHomePage;
        private ConfirmYourApprenticeshipDetailsPage _confirmYourApprenticeshipDetailsPage;
        private AlreadyConfirmedApprenticeshipDetailsPage _alreadyConfirmedApprenticeshipDetailsPage;
        private ConfirmRolesAndResponsibilitiesPage _confirmRolesAndResponsibilitiesPage;
        private AlreadyConfirmedRolesAndResponsibilitiesPage _alreadyConfirmedRolesAndResponsibilitiesPage;

        public ConfirmApprenticeshipSteps(ScenarioContext context) : base(context) => _context = context;

        [Then(@"the apprentice is able to confirm the Employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer()
        {
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InComplete);
            _apprenticeHomePage = new ApprenticeHomePage(_context).ConfirmYourEmployer().SelectYes();
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.Complete);
        }

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeHomePage.ConfirmAlreadyConfirmedEmployer().ContinueToHomePage();


        [Then(@"the apprentice confirms the Employer details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheEmployerDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InComplete);
            new ApprenticeHomePage(_context).ConfirmYourEmployer().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section1, StatusHelper.InCorrect);
        }

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider()
        {
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InComplete);
            _apprenticeHomePage = new ApprenticeHomePage(_context).ConfirmYourTrainingProvider().SelectYes();
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.Complete);
        }

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeHomePage.ConfirmAlreadyConfirmedTrainingProvider().ContinueToHomePage();

        [Then(@"the apprentice confirms the Provider details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheProviderDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InComplete);
            new ApprenticeHomePage(_context).ConfirmYourTrainingProvider().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section2, StatusHelper.InCorrect);
        }

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails()
        {
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InComplete);
            _apprenticeHomePage = NavigateAndVerifyApprenticeshipDetails().SelectYes();
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.Complete);
        }

        [Then(@"confirmed apprenticeship already page is displayed for trying to confirm again")]
        public void ThenConfirmedApprenticeshipAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = _apprenticeHomePage.ConfirmAlreadyConfirmedApprenticeship();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            _alreadyConfirmedApprenticeshipDetailsPage.ContinueToHomePage();
        }

        [Then(@"the apprentice confirms the Apprenticeship details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheApprenticeshipDetailsDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InComplete);
            NavigateAndVerifyApprenticeshipDetails().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section3, StatusHelper.InCorrect);
        }

        [Then(@"the apprentice is able to confirm 'How the apprenticeship will be delivered' section")]
        public void ThenTheApprenticeIsAbleToConfirmHowTheApprenticeshipWillBeDeliveredSection()
        {
            AssertSectionStatus(SectionHelper.Section4, StatusHelper.InComplete);
            _apprenticeHomePage = NavigateToConfirmHowYourApprenticeshipWillBeDelivered().SelectYes();
            AssertSectionStatus(SectionHelper.Section4, StatusHelper.Complete);
        }

        [Then(@"confirmed 'How the apprenticeship will be delivered' section page is displayed for trying to confirm again")]
        public void ThenConfirmedHowTheApprenticeshipWillBeDeliveredSectionPageIsDisplayedForTryingToConfirmAgain() => 
            _apprenticeHomePage.ConfirmAlreadyConfirmedHowYourApprenticeshipWillBeDelivered().ContinueToHomePage();

        [Then(@"the apprentice confirms 'How the apprenticeship will be delivered' section as NOT understood")]
        public void ThenTheApprenticeConfirmsHowTheApprenticeshipWillBeDeliveredSectionAsNOTUnderstood()
        {
            AssertSectionStatus(SectionHelper.Section4, StatusHelper.InComplete);
            NavigateToConfirmHowYourApprenticeshipWillBeDelivered().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section4, StatusHelper.InCorrect);
        }

        [Then(@"the apprentice is able to confirm Roles and responsibilities")]
        public void ThenTheApprenticeIsAbleToConfirmRolesAndResponsibilities()
        {
            AssertSectionStatus(SectionHelper.Section5, StatusHelper.InComplete);
            _apprenticeHomePage = NavigateAndVerifyRolesAndResponsibilities().SelectYes();
            AssertSectionStatus(SectionHelper.Section5, StatusHelper.Complete);
        }

        [Then(@"confirmed Roles already page is displayed for trying to confirm again")]
        public void ThenConfirmedRolesAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedRolesAndResponsibilitiesPage = _apprenticeHomePage.ConfirmAlreadyConfirmedRolesAndResponsibilities();
            appreticeCommitmentsStepsHelper.VerifyRolesAndResponsibilitiesForAlreadyConfirmedPage(_alreadyConfirmedRolesAndResponsibilitiesPage);
            _alreadyConfirmedRolesAndResponsibilitiesPage.ContinueToHomePage();
        }

        [Then(@"the apprentice confirms the Roles and responsibilities displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheRolesAndResponsibilitiesDisplayedAsIncorrect()
        {
            AssertSectionStatus(SectionHelper.Section5, StatusHelper.InComplete);
            NavigateAndVerifyRolesAndResponsibilities().SelectNo().ReturnToApprenticeHomePage();
            AssertSectionStatus(SectionHelper.Section5, StatusHelper.InCorrect);
        }

        [When(@"the apprentice confirms all the Apprenticeship sections")]
        public void WhenTheApprenticeConfirmsAllTheApprenticeshipSections()
        {
            ThenTheApprenticeIsAbleToConfirmRolesAndResponsibilities();
            ThenTheApprenticeIsAbleToConfirmTheEmployer();
            ThenTheApprenticeIsAbleToConfirmTheTrainingProvider();
            ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails();
            ThenTheApprenticeIsAbleToConfirmHowTheApprenticeshipWillBeDeliveredSection();
        }

        [Then(@"the apprentice is able to confirm the Overall Apprenticeship status")]
        public void ThenTheApprenticeIsAbleToConfirmTheOverallApprenticeshipStatus() =>
            _apprenticeHomePage.ConfirmYourApprenticeshipFromTheTopBanner().NavigateBackToOverviewPage();

        private ConfirmYourApprenticeshipDetailsPage NavigateAndVerifyApprenticeshipDetails()
        {
            _confirmYourApprenticeshipDetailsPage = new ApprenticeHomePage(_context).ConfirmYourApprenticeshipDetails();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayed(_confirmYourApprenticeshipDetailsPage);
            return _confirmYourApprenticeshipDetailsPage;
        }
        private ConfirmHowYourApprenticeshipWillBeDeliveredPage NavigateToConfirmHowYourApprenticeshipWillBeDelivered() =>
            new ApprenticeHomePage(_context).ConfirmHowYourApprenticeshipWillBeDelivered();

        private ConfirmRolesAndResponsibilitiesPage NavigateAndVerifyRolesAndResponsibilities()
        {
            _confirmRolesAndResponsibilitiesPage = new ApprenticeHomePage(_context).ConfirmRolesAndResponsibilities();
            return appreticeCommitmentsStepsHelper.VerifyRolesAndResponsibilitiesPage(_confirmRolesAndResponsibilitiesPage);
        }

        private void AssertSectionStatus(string sectionName, string expectedStatus) =>
            Assert.AreEqual(expectedStatus, new ApprenticeHomePage(_context).GetTheSectionStatus(sectionName));
    }
}
