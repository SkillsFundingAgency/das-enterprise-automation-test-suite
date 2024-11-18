namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderShutterScenarioSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
{
    [Then(@"the provider can not send an invite to a different email from same account")]
    public void TheProviderCanNotSendAnInviteToADifferentEmailFromSameAccount()
    {
        eprDataHelper.EmployerEmail = context.GetUser<EPRDeclineRequestUser>().AnotherEmail;

        new ViewEmpAndManagePermissionsPage(context).ClickAddAnEmployer().StartNowToAddAnEmployer().EnterEmployerEmailAndGoToInviteSent();
    }

    [Then(@"the provider can not re send the invite to the same email")]
    public void TheProviderCanNotReSendTheInviteToTheSameEmail()
    {
        new ViewEmpAndManagePermissionsPage(context).ClickAddAnEmployer().StartNowToAddAnEmployer().EnterEmployerEmailAndGoToInviteSent().GoToEmpAccountDetails().ViewEmployersAndManagePermissionsPage();
    }

    [Then(@"the provider can not send an invite to a different email using same aorn and paye")]
    public void TheProviderCanNotSendAnInviteToADifferentEmailUsingSameAornAndPaye()
    {
        eprDataHelper.EmployerEmail = $"A_{eprDataHelper.EmployerEmail}";

        new ViewEmpAndManagePermissionsPage(context).ClickAddAnEmployer().StartNowToAddAnEmployer().EnterNewEmployerEmail().SubmitPayeAndContinueToInviteSent().GoToEmpAccountDetails().ViewEmployersAndManagePermissionsPage();
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
