using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ConfirmIdentitySteps : BaseSteps
    {
        private ApprenticeHomePage _ApprenticeHomePage;

        public ConfirmIdentitySteps(ScenarioContext context) : base(context) { }

        [Given(@"an apprentice login in to the service")]
        public void GivenAnApprenticeLoginInToTheService() => appreticeCommitmentsStepsHelper.CreateAccount();

        [Then(@"the apprentice is able to confirm the identitification details")]
        public void ThenTheApprenticeIsAbleToConfirmTheIdentificationDetails() =>
            _ApprenticeHomePage = SignInToApprenticePortal().ConfirmIdentity();

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
            ThenTheApprenticeIsAbleToConfirmTheIdentificationDetails();
        }

        [Then(@"the apprentice is able to logout from the service")]
        public void ThenTheApprenticeIsAbleToLogoutFromTheService() => _ApprenticeHomePage.SingOutFromTheService();

        private ConfirmYourIdentityPage SignInToApprenticePortal() => appreticeCommitmentsStepsHelper.SignInToApprenticePortal();
    }
}