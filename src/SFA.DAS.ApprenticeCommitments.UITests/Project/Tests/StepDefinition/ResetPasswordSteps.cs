using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ResetPasswordSteps(ScenarioContext context) : BaseSteps(context)
    {
        [Then(@"the apprentice is able to reset the password using the invitation")]
        public void ThenTheApprenticeIsAbleToResetThePasswordUsingTheInvitation() => passwordResetStepsHelper.ResetPasswordAndReturnToSignInPage().SignInToApprenticePortalForPersonalDetailsUnVerifiedAccount();

    }
}
