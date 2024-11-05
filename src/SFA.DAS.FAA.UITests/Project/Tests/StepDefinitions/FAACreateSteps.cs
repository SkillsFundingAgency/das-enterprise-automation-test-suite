namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions;

[Binding]
public class FAACreateSteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

    [Given(@"appretince creates an account")]
    public void GivenAppretinceCreatesAnAccount()
    {
        _faaStepsHelper.CreateNewUserLogin().CompleteApprenticeSignUpDetails();
    }


    [Then(@"apprentice is able to delete account")]
    public void ThenApprenticeIsAbleToDeleteAccount()
    {
        _faaStepsHelper.DeleteAccountFromSettings();
    }
    
}
