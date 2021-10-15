using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CreateAccountSteps : BaseSteps
    {
        private ApprenticeOverviewPage _apprenticeOverviewPage;

        private CreateMyApprenticeshipAccountPage _createMyApprenticeshipAccountPage;

        public CreateAccountSteps(ScenarioContext context) : base(context) { }


        [When(@"an apprenticeship is created via API request")]
        public void WhenAnApprenticeshipIsCreatedViaApiRequest() => createAccountStepsHelper.CreateApprenticeshipViaApiRequest();

        [Then(@"the apprentice is able to create an account with the invite generated")]
        public void ThenTheApprenticeIsAbleToCreateAnAccountWithTheInviteGenerated() => createAccountStepsHelper.CreateAccount();

        [Then(@"an error is shown for entering invalid identity data")]
        public void ThenAnErrorIsShownForEnteringInvalidIdentityData()
        {
            var invalidData = new List<(string, string, int, int, int)>
            {
                (string.Empty, string.Empty, 0,0,0)
            };

            foreach (var d in invalidData)
            {
                _createMyApprenticeshipAccountPage = _createMyApprenticeshipAccountPage.InvalidData(d.Item1, d.Item2, d.Item3, d.Item4, d.Item5);
                _createMyApprenticeshipAccountPage.VerifyErrorSummary();
            }
        }

        [Then(@"the apprentice is able to logout from the service")]
        public void ThenTheApprenticeIsAbleToLogoutFromTheService() => 
            _apprenticeOverviewPage.SignOutFromTheService().ClickSignBackInLinkFromSignOutPage();

        [Given(@"an apprentice has created the account and about to validate personal details")]
        public void GivenAnApprenticeHasCreatedTheAccountAndAboutToValidatePersonalDetails()
        {
            createAccountStepsHelper.CreateApprenticeshipViaApiRequest();

            _createMyApprenticeshipAccountPage = createAccountStepsHelper.CreateAccountAndGetToCreateMyApprenticeshipAccountPage();
        }
    }
}
