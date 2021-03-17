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

        [Then(@"the apprentice can confirm the employer")]
        public void ThenTheApprenticeCanConfirmTheEmployer() => _apprenticeHomePage.ConfirmYourEmployer().SelectYes();

        [Then(@"the apprentice can not confirm the employer")]
        public void ThenTheApprenticeCanNotConfirmTheEmployer() => _apprenticeHomePage.ConfirmYourEmployer().SelectNo();

        [Then(@"the apprentice can confirm the training provider")]
        public void ThenTheApprenticeCanConfirmTheTrainingProvider() => _apprenticeHomePage.ConfirmYourTrainingProvider().SelectYes();

        [Then(@"the apprentice can not confirm the training provider")]
        public void ThenTheApprenticeCanNotConfirmTheTrainingProvider() => _apprenticeHomePage.ConfirmYourTrainingProvider().SelectNo();

        [Then(@"an error is shown for invalid data")]
        public void ThenAnErrorIsShownForInvalidData()
        {
            var confirmidentitypage = SignInToApprenticePortal();

            var invalidDatas = new List<(string, string, int, int, int, string)>
            {
                (string.Empty, string.Empty, 0,0,0, string.Empty)
            };

            foreach (var d in invalidDatas)
            {
                confirmidentitypage = confirmidentitypage.InvalidData(d.Item1, d.Item2, d.Item3, d.Item4, d.Item5, d.Item6);

                confirmidentitypage.VerifyErrorSummary();
            }
        }

        private ConfirmYourIdentityPage SignInToApprenticePortal() => appreticeCommitmentsStepsHelper.SignInToApprenticePortal();
    }
}