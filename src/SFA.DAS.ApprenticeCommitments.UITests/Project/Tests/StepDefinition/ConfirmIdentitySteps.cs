using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.UI.Framework;
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

        [Then(@"the apprentice is able to confirm the identitification details")]
        public void ThenTheApprenticeIsAbleToConfirmTheIdentificationDetails()
        {
            _apprenticeHomePage = SignInToApprenticePortal().ConfirmIdentity();
            appreticeCommitmentsStepsHelper.UpdateConfirmBeforeDate();
            tabHelper.OpenInNewTab(UrlConfig.Apprentice_BaseUrl());
        }

        [Then(@"an error is shown for invalid data")]
        public void ThenAnErrorIsShownForInvalidData()
        {
            var confirmYourIdentityPage = SignInToApprenticePortal();

            var invalidDatas = new List<(string, string, int, int, int)>
            {
                (string.Empty, string.Empty, 0,0,0)
            };

            foreach (var d in invalidDatas)
            {
                confirmYourIdentityPage = confirmYourIdentityPage.InvalidData(d.Item1, d.Item2, d.Item3, d.Item4, d.Item5);
                confirmYourIdentityPage.VerifyErrorSummary();
            }
        }

        [Given(@"an apprentice has created and validated the account")]
        public void GivenAnApprenticeHasCreatedAndValidatedTheAccount()
        {
            GivenAnApprenticeLoginInToTheService();
            ThenTheApprenticeIsAbleToConfirmTheIdentificationDetails();
            appreticeCommitmentsStepsHelper.VerifyDaysToConfirmWarning(_apprenticeHomePage);
        }

        [Then(@"the apprentice is able to logout from the service")]
        public void ThenTheApprenticeIsAbleToLogoutFromTheService() => _apprenticeHomePage.SignOutFromTheService();

        private ConfirmYourIdentityPage SignInToApprenticePortal() => appreticeCommitmentsStepsHelper.SignInToApprenticePortal();
    }
}