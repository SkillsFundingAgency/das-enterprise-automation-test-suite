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

        GoToProviderViewEmployersAndManagePermissions();

        eprDataHelper.EmployerEmail = employerUser.Username;

        eprDataHelper.EmployerOrganisationName = employerUser.OrganisationName;

        var request = GoToEmailAccountFoundPage().ContinueToInvite().ProviderRequestPermissions(permissions);

        request.GoToViewEmployersPage().VerifyPendingRequest();
    }

    [When(@"the provider update the permission")]
    public void TheProviderUpdateThePermission()
    {
        ProviderUpdatePermission((AddApprenticePermissions.DoNotAllow, RecruitApprenticePermissions.AllowConditional));
    }

    [When(@"the provider update the permission again")]
    public void TheProviderUpdateThePermissionAgain()
    {
        ProviderUpdatePermission((AddApprenticePermissions.DoNotAllow, RecruitApprenticePermissions.DoNotAllow));
    }
}