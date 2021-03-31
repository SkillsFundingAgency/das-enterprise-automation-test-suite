using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ConfirmIdentitySteps : BaseSteps
    {
        private ApprenticeHomePage _apprenticeHomePage;

        public ConfirmIdentitySteps(ScenarioContext context) : base(context) { }

        [Given(@"an apprentice login in to the service")]
        public void GivenAnApprenticeLoginInToTheService() => appreticeCommitmentsStepsHelper.CreateAccount();

        [Then(@"the apprentice identity can be validated")]
        public void ThenTheApprenticeIdentityCanBeValidated() => _apprenticeHomePage = SignInToApprenticePortal().ConfirmIdentity();

        [Then(@"the apprentice is able to confirm the employer")]
        public void ThenTheApprenticeIsAbleToConfirmTheEmployer() => _apprenticeHomePage = _apprenticeHomePage.ConfirmYourEmployer().SelectYes();

        [Then(@"the apprentice can not confirm the employer")]
        public void ThenTheApprenticeCanNotConfirmTheEmployer() => _apprenticeHomePage = _apprenticeHomePage.ConfirmYourEmployer().SelectNo().ReturnToApprenticeHomePage();

        [Then(@"the apprentice is able to confirm the training provider")]
        public void ThenTheApprenticeIsAbleToConfirmTheTrainingProvider() => _apprenticeHomePage = _apprenticeHomePage.ConfirmYourTrainingProvider().SelectYes();

        [Then(@"the apprentice can not confirm the training provider")]
        public void ThenTheApprenticeCanNotConfirmTheTrainingProvider() => _apprenticeHomePage = _apprenticeHomePage.ConfirmYourTrainingProvider().SelectNo().ReturnToApprenticeHomePage();

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

        private ConfirmYourIdentityPage SignInToApprenticePortal() => appreticeCommitmentsStepsHelper.SignInToApprenticePortal();
    }
}