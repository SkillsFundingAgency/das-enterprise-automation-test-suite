namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderRelationSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
{

    [Given(@"a provider requests all permission from an employer")]
    public void AProviderRequestsAllPermissionFromAnEmployer()
    {
        EPRBaseUser employerUser = tags.Contains("acceptrequest") ? context.GetUser<EPRAcceptRequestUser>() : context.GetUser<EPRDeclineRequestUser>();

        EPRLogin(employerUser);

        permissions = (AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.Allow);

        GoToProviderRelationsHomePage();

        eprDataHelper.EmployerEmail = employerUser.Username;

        eprDataHelper.EmployerOrganisationName = employerUser.OrganisationName;

        var request = GoToEmailAccountFoundPage().ContinueToInvite().ProviderRequestPermissions(permissions);

        request.GoToViewEmployersPage().VerifyPendingRequest();
    }

    [When(@"the provider update the permission")]
    public void TheProviderUpdateThePermission()
    {
        GoToProviderRelationsHomePage();

        new ViewEmpAndManagePermissionsPage(context).ViewEmployer();
    }

    [Then(@"the provider should be shown a shutter page where relationship already exists")]
    public void TheProviderShouldBeShownAShutterPageWhereRelationshipAlreadyExists()
    {
        GoToProviderRelationsHomePage();

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

        GoToProviderRelationsHomePage();

        GoToSearchEmployerEmailPage().EnterEmployerEmailAndGoToShutterPage();
    }


}