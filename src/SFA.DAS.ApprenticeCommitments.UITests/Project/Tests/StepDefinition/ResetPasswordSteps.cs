using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ResetPasswordSteps : BaseSteps
    {
        public ResetPasswordSteps(ScenarioContext context) : base(context) { }

        [When(@"an apprentice submits Email to reset password for a new account pending personal details confirmation")]
        public void WhenAnApprenticeSubmitsEmailToResetPasswordForANewAccountPendingPD()
        {
            appreticeCommitmentsStepsHelper.CreateAccount();
            appreticeCommitmentsStepsHelper.SubmitEmailToResetPasswordFromSignInPage();
        }

        [Then(@"the apprentice is able to reset the password using the invitation")]
        public void ThenTheApprenticeIsAbleToResetThePasswordUsingTheInvitation() => appreticeCommitmentsStepsHelper.ResetPasswordAndReturnToSignInPage().SignInToApprenticePortalForPersonalDetailsUnVerifiedAccount();

        [Then(@"an error is shown for entering misatched reset passwords")]
        public void ThenAnErrorIsShownForEnteringMismatchedResetPasswords()
        {
            var resetPasswordPage = appreticeCommitmentsStepsHelper.BuildResetPasswordPageUsingDBHelper();
            appreticeCommitmentsStepsHelper.EnterMismatchedPasswordsAndValidateError(resetPasswordPage);
        }
    }
}
