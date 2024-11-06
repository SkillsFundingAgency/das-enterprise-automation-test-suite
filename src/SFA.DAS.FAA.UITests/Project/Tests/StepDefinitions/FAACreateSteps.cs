using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.Delete;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions;

[Binding]
public class FAACreateSteps(ScenarioContext context)
{
    private readonly FAAStepsHelper _faaStepsHelper = new(context);

    [Given(@"appretince creates an account")]
    public void GivenAppretinceCreatesAnAccount()
    {
        _faaStepsHelper.SubmitNewUserDetails();
        
        new FAA_CreateAccountPage(context)
            .CreateAnAccount()
            .SubmitApprenticeName()
            .SubmitApprenticeDateOfBirth()
            .SubmitApprenticePostCode()
            .SubmitApprenticeTelephoneNumber()
            .SelectRemindersNotification()
            .ClickCreateYourAccountConfirmation();
    }

    [Then(@"apprentice is able to delete account")]
    public void ThenApprenticeIsAbleToDeleteAccount()
    {
        new SettingPage(context).DeleteMyAccount().ContinueDeleteMyAccount().ConfirmDeleteMyAccount().VerifyNotification();
    }
}
