using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderShutterScenarioSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
{
    private ViewEmpAndManagePermissionsPage page;

    [Then(@"the provider can not re send the invite to the same email")]
    public void TheProviderCanNotReSendTheInviteToTheSameEmail()
    {
        page = new ViewEmpAndManagePermissionsPage(context).ClickAddAnEmployer().StartNowToAddAnEmployer().EnterEmployerEmailAndGoToInviteSent().GoToEmpAccountDetails().ViewEmployersAndManagePermissionsPage();
    }

    [Then(@"the provider can not send an invite to a different email using same aorn and paye")]
    public void TheProviderCanNotSendAnInviteToADifferentEmailUsingSameAornAndPaye()
    {
        eprDataHelper.EmployerEmail = $"A_{eprDataHelper.EmployerEmail}";

        page = page.ClickAddAnEmployer().StartNowToAddAnEmployer().EnterNewEmployerEmail().SubmitPayeAndContinueToInviteSent().GoToEmpAccountDetails().ViewEmployersAndManagePermissionsPage();
    }

    [Then(@"the provider should be shown a shutter page where relationship already exists")]
    public void TheProviderShouldBeShownAShutterPageWhereRelationshipAlreadyExists()
    {
        GoToProviderViewEmployersAndManagePermissions();

        GoToEmailAccountFoundPage().VerifyAlreadyLinkedToThisEmployer();
    }

    [Then(@"the provider should be shown a shutter page where an employer has multiple accounts")]
    public void TheProviderShouldBeShownAShutterPageWhereAnEmployerHasMultipleAccounts()
    {
        var user = context.GetUser<EPRMultiAccountUser>();

        EnterEmployerEmailAndGoToShutterPage(user.Username);
    }

    [Then(@"the provider should be shown a shutter page where an employer has multiple organisations")]
    public void ThenTheProviderShouldBeShownAShutterPageWhereAnEmployerHasMultipleOrganisations()
    {
        var user = context.GetUser<EPRMultiOrgUser>();

        EnterEmployerEmailAndGoToShutterPage(user.Username);
    }

    private void EnterEmployerEmailAndGoToShutterPage(string username)
    {
        eprDataHelper.EmployerEmail = username;

        GoToProviderViewEmployersAndManagePermissions();

        GoToSearchEmployerEmailPage().EnterEmployerEmailAndGoToContactEmployer();
    }
}
