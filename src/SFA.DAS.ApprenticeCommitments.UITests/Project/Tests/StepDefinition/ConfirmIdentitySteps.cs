using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ConfirmIdentitySteps : BaseSteps
    {
        private ApprenticeHomePage _apprenticeHomePage;
        private ConfirmYourApprenticeshipDetailsPage _confirmYourApprenticeshipDetailsPage;
        private AlreadyConfirmedApprenticeshipDetailsPage _alreadyConfirmedApprenticeshipDetailsPage;

        public ConfirmIdentitySteps(ScenarioContext context) : base(context) { }

        [Given(@"an apprentice login in to the service")]
        public void GivenAnApprenticeLoginInToTheService() => appreticeCommitmentsStepsHelper.CreateAccount();

        [Then(@"the apprentice identity can be validated")]
        public void ThenTheApprenticeIdentityCanBeValidated() => _apprenticeHomePage = SignInToApprenticePortal().ConfirmIdentity();

        [Then(@"the apprentice is able to confirm the Employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer() => _apprenticeHomePage = _apprenticeHomePage.ConfirmYourEmployer().SelectYes();

        [Then(@"the apprentice confirms the Employer details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheEmployerDetailsDisplayedAsIncorrect() => _apprenticeHomePage = _apprenticeHomePage.ConfirmYourEmployer().SelectNo().ReturnToApprenticeHomePage();

        [Then(@"the apprentice is able to confirm the Training Provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider() => _apprenticeHomePage = _apprenticeHomePage.ConfirmYourTrainingProvider().SelectYes();

        [Then(@"the apprentice confirms the Provider details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheProviderDetailsDisplayedAsIncorrect() => _apprenticeHomePage = _apprenticeHomePage.ConfirmYourTrainingProvider().SelectNo().ReturnToApprenticeHomePage();

        [Then(@"an error is shown for invalid data")]
        public void ThenAnErrorIsShownForInvalidData()
        {
            var confirmYourIdentityPage = SignInToApprenticePortal();

            var invalidDatas = new List<(string, string, int, int, int, string)>
            {
                (string.Empty, string.Empty, 0,0,0, string.Empty)
            };

            foreach (var d in invalidDatas)
            {
                confirmYourIdentityPage = confirmYourIdentityPage.InvalidData(d.Item1, d.Item2, d.Item3, d.Item4, d.Item5, d.Item6);
                confirmYourIdentityPage.VerifyErrorSummary();
            }
        }

        [Given(@"an apprentice has created and validated the account")]
        public void GivenAnApprenticeHasCreatedAndValidatedTheAccount()
        {
            GivenAnApprenticeLoginInToTheService();
            ThenTheApprenticeIdentityCanBeValidated();
        }

        [Then(@"confirmed training provider already page is displayed for trying to confirm again")]
        public void ThenConfirmedTrainingProviderAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
            _apprenticeHomePage = _apprenticeHomePage.ConfirmAlreadyConfirmedTrainingProvider().ContinueToHomePage();

        [Then(@"confirmed employer already page is displayed for trying to confirm again")]
        public void ThenConfirmedEmployerAlreadyPageIsDisplayedForTryingToConfirmAgain() =>
             _apprenticeHomePage = _apprenticeHomePage.ConfirmAlreadyConfirmedEmployer().ContinueToHomePage();

        [Then(@"the apprentice is able to confirm the Apprenticeship details")]
        public void ThenTheApprenticeIsAbleToConfirmTheApprenticeshipDetails()
        {
            NavigateAndVerifyApprenticeshipDetails();
            _apprenticeHomePage = _confirmYourApprenticeshipDetailsPage.SelectYes();
        }

        [Then(@"confirmed apprenticeship already page is displayed for trying to confirm again")]
        public void ThenConfirmedApprenticeshipAlreadyPageIsDisplayedForTryingToConfirmAgain()
        {
            _alreadyConfirmedApprenticeshipDetailsPage = _apprenticeHomePage.ConfirmAlreadyConfirmedApprenticeship();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayedInAlreadyConfirmedPage(_alreadyConfirmedApprenticeshipDetailsPage);
            _apprenticeHomePage = _alreadyConfirmedApprenticeshipDetailsPage.ContinueToHomePage();
        }

        [Then(@"the apprentice confirms the Apprenticeship details displayed as Incorrect")]
        public void ThenTheApprenticeConfirmsTheApprenticeshipDetailsDisplayedAsIncorrect()
        {
            NavigateAndVerifyApprenticeshipDetails();
            _apprenticeHomePage = _confirmYourApprenticeshipDetailsPage.SelectNo().ReturnToApprenticeHomePage();
        }

        private ConfirmYourIdentityPage SignInToApprenticePortal() => appreticeCommitmentsStepsHelper.SignInToApprenticePortal();

        private void NavigateAndVerifyApprenticeshipDetails()
        {
            _confirmYourApprenticeshipDetailsPage = _apprenticeHomePage.ConfirmYourApprenticeship();
            appreticeCommitmentsStepsHelper.VerifyApprenticeshipDataDisplayed(_confirmYourApprenticeshipDetailsPage);
        }
    }
}