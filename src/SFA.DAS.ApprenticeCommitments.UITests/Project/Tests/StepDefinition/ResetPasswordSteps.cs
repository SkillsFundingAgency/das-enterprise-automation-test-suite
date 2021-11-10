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
            var signIntoMyApprenticeshipPage = createAccountStepsHelper.CreateAccountAndSignOutBeforeConfirmingPersonalDetails();
            passwordResetStepsHelper.ResetPasswordFromSignInPageForUnverifiedAccount(signIntoMyApprenticeshipPage);
        }

        [Then(@"the apprentice is able to reset the password using the invitation")]
        public void ThenTheApprenticeIsAbleToResetThePasswordUsingTheInvitation() => passwordResetStepsHelper.ResetPasswordAndReturnToSignInPage().SignInToApprenticePortalForPersonalDetailsUnVerifiedAccount();

        [Then(@"an error is shown for entering mismatched reset passwords")]
        public void ThenAnErrorIsShownForEnteringMismatchedResetPasswords()
        {
            var resetPasswordPage = passwordResetStepsHelper.BuildResetPasswordPageUsingDBHelper();
            passwordResetStepsHelper.EnterMismatchedPasswordsAndValidateError(resetPasswordPage);
        }

        [Then(@"an error is shown for entering mismatched passwords")]
        public void ThenAnErrorIsShownForEnteringMismatchedPasswords()
        {
            var createLoginDetailsPage = createAccountStepsHelper.NavigateToCreateLoginDetailsPage().EnterEmailAndConfirmEmail();
            passwordResetStepsHelper.EnterMismatchedPasswordsAndValidateErrorOnCreateLoginDetailsPage(createLoginDetailsPage);
        }
    }
}
