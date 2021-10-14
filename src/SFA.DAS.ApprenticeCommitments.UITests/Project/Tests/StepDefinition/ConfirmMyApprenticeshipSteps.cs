using NUnit.Framework;
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
        private ApprenticeHomePage _apprenticeHomePage;
        private ConfirmYourApprenticeshipDetailsPage _confirmYourApprenticeshipDetailsPage;
        private AlreadyConfirmedApprenticeshipDetailsPage _alreadyConfirmedApprenticeshipDetailsPage;
        private ConfirmRolesAndResponsibilitiesPage _confirmRolesAndResponsibilitiesPage;
        private AlreadyConfirmedRolesAndResponsibilitiesPage _alreadyConfirmedRolesAndResponsibilitiesPage;
        
        public ConfirmMyApprenticeshipSteps(ScenarioContext context) : base(context) => _context = context;

        [Then(@"the apprentice can confirm apprenticeship")]
        public void ThenTheApprenticeCanConfirmApprenticeship()
        {
            _apprenticeOverviewPage = new ApprenticeHomePage(_context).NavigateToOverviewPageFromLinkOnTheHomePage();

            _apprenticeOverviewPage = ConfirmAllSections(false);

            _apprenticeHomePage = _apprenticeOverviewPage.ConfirmYourApprenticeshipFromTheTopBanner().NavigateToHomePageFromTopNavigationLink();

            _apprenticeHomePage.VerifyCompleteTag();
        }

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
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer() => ConfirmYourEmployer(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Employer details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployerDetailsAgainAsCorrect() => ConfirmYourEmployer(StatusHelper.InCorrect);

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider() => ConfirmYourTrainingProvider(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm the Provider details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheProviderDetailsAgainAsCorrect() => ConfirmYourTrainingProvider(StatusHelper.InCorrect);

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails() => ConfirmApprenticeshipDetails(StatusHelper.InComplete, true);

        [Then(@"the apprentice is able to confirm the Apprenticeship details again as correct")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetailsAgainAsCorrect() => ConfirmApprenticeshipDetails(StatusHelper.InCorrect, true);

        [Then(@"the apprentice is able to confirm 'How the apprenticeship will be delivered' section")]
        public void ThenTheApprenticeIsAbleToConfirmHowTheApprenticeshipWillBeDeliveredSection() => ConfirmHowYourApprenticeshipWillBeDelivered(StatusHelper.InComplete);

        [Then(@"the apprentice is able to confirm Roles and responsibilities")]
        public void ThenTheApprenticeIsAbleToConfirmRolesAndResponsibilities() => ConfirmRolesAndResponsibilities(StatusHelper.InComplete);

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain() => _apprenticeOverviewPage.ConfirmAlreadyConfirmedEmployer().ContinueToHomePage();


        [Then(@"the apprentice confirms the Employer details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheEmployerDetailsDisplayedAsIncorrect()
        {
            AssertSection1Status(StatusHelper.InComplete);
            new ApprenticeOverviewPage(_context).ConfirmYourEmployer().SelectNoToConfirmEmployer().ReturnToApprenticeOverviewPage();
            AssertSection1Status(StatusHelper.InCorrect);
        }

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeOverviewPage.ConfirmAlreadyConfirmedTrainingProvider().ContinueToHomePage();

        [Then(@"the apprentice confirms the Provider details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheProviderDetailsDisplayedAsIncorrect()
        {
            AssertSection2Status(StatusHelper.InComplete);
            new ApprenticeOverviewPage(_context).ConfirmYourTrainingProvider().SelectNoToConfirmTrainingProvider().ReturnToApprenticeOverviewPage();
            AssertSection2Status(StatusHelper.InCorrect);
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
            AssertSection3Status(StatusHelper.InComplete);
            NavigateAndVerifyApprenticeshipDetails(true).SelectNoConfirmYourDetails().ReturnToApprenticeOverviewPage();
            AssertSection3Status(StatusHelper.InCorrect);
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

        [When(@"the apprentice confirms all the Apprenticeship sections")]
        public void WhenTheApprenticeConfirmsAllTheApprenticeshipSections() => ConfirmAllSections(true);

        [Then(@"the apprentice is able to confirm the Overall Apprenticeship status")]
        public void ThenTheApprenticeIsAbleToConfirmTheOverallApprenticeshipStatus()
        {
            _apprenticeOverviewPage.ConfirmYourApprenticeshipFromTheTopBanner().VerifyTrainingNameOnPageHeader().NavigateBackToOverviewPage();
            _apprenticeOverviewPage.VerifyPageAfterApprenticeshipConfirm();
        }

        [Then(@"the apprentice is able to navigate to the Help and Support from the link on Overview page and Navigation menu link")]
        public void ThenTheApprenticeIsAbleToNavigateToTheHelpAndSupport()
        {
            _apprenticeHomePage = _apprenticeOverviewPage.NavigateToHelpAndSupportPageWithTheLinkOnTheContentOfOverviewPage().NavigateToHomePageWithReturnToHomePageButton();
            _apprenticeOverviewPage = _apprenticeHomePage.NavigateToOverviewPageFromTopNavigationLink();
            _apprenticeOverviewPage = _apprenticeOverviewPage.NavigateToHelpAndSupportPageWithTheLinkOnTheContentOfOverviewPage().NavigateToOverviewPageWithBackLink();
        }

        [Then(@"the apprentice is able to navigate to Home page back and forth from Overview and Help pages")]
        public void ThenTheApprenticeIsAbleToNavigateToHomePageBackAndForthFromOverviewAndHelpPages()
        {
            _apprenticeHomePage = _apprenticeOverviewPage.NavigateToHomePageFromTopNavigationLink().NavigateToOverviewPageFromLinkOnTheHomePage().NavigateToHomePageFromTopNavigationLink();
            _apprenticeHomePage = _apprenticeHomePage.NavigateToOverviewPageFromTopNavigationLink().NavigateToHomePageFromTopNavigationLink();
            _apprenticeHomePage = _apprenticeHomePage.NavigateToHelpAndSupportPageWithTheLinkOnHomePage().NavigateToHomePageWithBackLink();
            _apprenticeHomePage = _apprenticeHomePage.NavigateToHelpPageFromTopNavigationLink().NavigateToHomePageWithBackLink();
        }

        private ConfirmYourApprenticeshipDetailsPage NavigateAndVerifyApprenticeshipDetails(bool verify)
        {
            _confirmYourApprenticeshipDetailsPage = new ApprenticeOverviewPage(_context).ConfirmYourApprenticeshipDetails();
            if (verify) confirmMyApprenticeshipStepsHelper.VerifyApprenticeshipDataDisplayed(_confirmYourApprenticeshipDetailsPage);
            return _confirmYourApprenticeshipDetailsPage;
        }

        private ConfirmHowYourApprenticeshipWillBeDeliveredPage NavigateToConfirmHowYourApprenticeshipWillBeDelivered() =>
            new ApprenticeOverviewPage(_context).ConfirmHowYourApprenticeshipWillBeDelivered();

        private ConfirmRolesAndResponsibilitiesPage NavigateAndVerifyRolesAndResponsibilities()
        {
            _confirmRolesAndResponsibilitiesPage = new ApprenticeOverviewPage(_context).ConfirmRolesAndResponsibilities();

            return confirmMyApprenticeshipStepsHelper.VerifyRolesAndResponsibilitiesPage(_confirmRolesAndResponsibilitiesPage);
        }

        private ApprenticeOverviewPage ConfirmAllSections(bool verifyApprenticeshipDetails)
        {
            _apprenticeOverviewPage = ConfirmYourEmployer(StatusHelper.InComplete);
            _apprenticeOverviewPage = ConfirmYourTrainingProvider(StatusHelper.InComplete);
            _apprenticeOverviewPage = ConfirmApprenticeshipDetails(StatusHelper.InComplete, verifyApprenticeshipDetails);
            _apprenticeOverviewPage = ConfirmHowYourApprenticeshipWillBeDelivered(StatusHelper.InComplete);
            _apprenticeOverviewPage = ConfirmRolesAndResponsibilities(StatusHelper.InComplete);
            return _apprenticeOverviewPage;
        }

        private ApprenticeOverviewPage ConfirmYourEmployer(string initialStatus)
        {
            AssertSection1Status(initialStatus);

            _apprenticeOverviewPage = new ApprenticeOverviewPage(_context).ConfirmYourEmployer().SelectYes();

            AssertSection1Status(StatusHelper.Complete);

            return _apprenticeOverviewPage;
        }

        private ApprenticeOverviewPage ConfirmYourTrainingProvider(string initialStatus)
        {

            AssertSection2Status(initialStatus);

            _apprenticeOverviewPage = new ApprenticeOverviewPage(_context).ConfirmYourTrainingProvider().SelectYes();

            AssertSection2Status(StatusHelper.Complete);

            return _apprenticeOverviewPage;
        }

        private ApprenticeOverviewPage ConfirmApprenticeshipDetails(string initialStatus, bool verify)
        {
            AssertSection3Status(initialStatus);

            _apprenticeOverviewPage = NavigateAndVerifyApprenticeshipDetails(verify).SelectYes();

            AssertSection3Status(StatusHelper.Complete);

            return _apprenticeOverviewPage;
        }

        private ApprenticeOverviewPage ConfirmHowYourApprenticeshipWillBeDelivered(string initialStatus)
        {
            AssertSection4Status(initialStatus);

            _apprenticeOverviewPage = NavigateToConfirmHowYourApprenticeshipWillBeDelivered().ContinueToHomePage();

            AssertSection4Status(StatusHelper.Complete);

            return _apprenticeOverviewPage;
        }

        private ApprenticeOverviewPage ConfirmRolesAndResponsibilities(string initialStatus)
        {
            AssertSection5Status(initialStatus);

            _apprenticeOverviewPage = NavigateAndVerifyRolesAndResponsibilities().ContinueToHomePage();

            AssertSection5Status(StatusHelper.Complete);

            return _apprenticeOverviewPage;
        }

        private void AssertSection1Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section1, expectedStatus);

        private void AssertSection2Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section2, expectedStatus);

        private void AssertSection3Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section3, expectedStatus);

        private void AssertSection4Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section4, expectedStatus);

        private void AssertSection5Status(string expectedStatus) => AssertSectionStatus(SectionHelper.Section5, expectedStatus);

        private void AssertSectionStatus(string sectionName, string expectedStatus) =>
            Assert.AreEqual(expectedStatus, new ApprenticeOverviewPage(_context).GetTheSectionStatus(sectionName));
    }
}
