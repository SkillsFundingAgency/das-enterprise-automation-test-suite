using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ResetPasswordSteps : BaseSteps
    {
        public ResetPasswordSteps(ScenarioContext context) : base(context) { }

        [When(@"an apprentice submits to reset password")]
        public void WhenAnApprenticeSubmitsToResetPassword()
        {
            appreticeCommitmentsStepsHelper.CreateAccount();

            appreticeCommitmentsStepsHelper.SubmitResetPassword();
        }

        [Then(@"the apprentice can reset password using the invitation")]
        public void ThenTheApprenticeCanResetPasswordUsingTheInvitation() => appreticeCommitmentsStepsHelper.ResetPassword();

        [Then(@"an error is shown for invalid reset passwords")]
        public void ThenAnErrorIsShownForInvalidResetPasswords()
        {
            var passwordPage = appreticeCommitmentsStepsHelper.GetResetPasswordPage();

            appreticeCommitmentsStepsHelper.InvalidPassword(passwordPage);
        }
    }
}
