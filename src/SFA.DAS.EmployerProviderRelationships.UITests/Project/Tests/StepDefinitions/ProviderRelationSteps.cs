namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderRelationSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
{
    [Given(@"a provider requests all permission from an employer")]
    public void AProviderRequestsAllPermissionFromAnEmployer()
    {
        EPRBaseUser employerUser = tags.Contains("acceptrequest") ? context.GetUser<EPRAcceptRequestUser>() : context.GetUser<EPRDeclineRequestUser>();

        context.Set(employerUser);

        EPRLogin(employerUser);

        permissions = (AddApprenticePermissions.YesAddApprenticeRecords, RecruitApprenticePermissions.YesRecruitApprentices);

        GoToProviderViewEmployersAndManagePermissions();

        eprDataHelper.EmployerEmail = employerUser.Username;

        eprDataHelper.EmployerOrganisationName = employerUser.OrganisationName;

        var request = GoToEmailAccountFoundPage().ContinueToInvite().ProviderRequestPermissions(permissions);

        request.GoToViewEmployersPage().VerifyPendingRequest();
    }

    [When("the provider updates the permission to NoToAddApprenticeRecords YesRecruitApprenticesButEmployerWillReview")]
    public void WhenTheProviderUpdatesThePermissionToNoToAddApprenticeRecordsYesRecruitApprenticesButEmployerWillReview()
    {
        ProviderUpdatePermission((AddApprenticePermissions.NoToAddApprenticeRecords, RecruitApprenticePermissions.YesRecruitApprenticesButEmployerWillReview));
    }

    [When("the provider updates the permission to NoToAddApprenticeRecords YesRecruitApprentices")]
    public void WhenTheProviderUpdatesThePermissionToNoToAddApprenticeRecordsYesRecruitApprentices()
    {
        ProviderUpdatePermission((AddApprenticePermissions.NoToAddApprenticeRecords, RecruitApprenticePermissions.YesRecruitApprentices));
    }

    [When("the provider updates the permission to YesAddApprenticeRecords YesRecruitApprentices")]
    public void WhenTheProviderUpdatesThePermissionToYesAddApprenticeRecordsYesRecruitApprentices()
    {
        ProviderUpdatePermission((AddApprenticePermissions.YesAddApprenticeRecords, RecruitApprenticePermissions.YesRecruitApprentices));
    }

    [When("the provider updates the permission to YesAddApprenticeRecords YesRecruitApprenticesButEmployerWillReview")]
    public void WhenTheProviderUpdatesThePermissionToYesAddApprenticeRecordsYesRecruitApprenticesButEmployerWillReview()
    {
        ProviderUpdatePermission((AddApprenticePermissions.YesAddApprenticeRecords, RecruitApprenticePermissions.YesRecruitApprenticesButEmployerWillReview));
    }

    [When("the provider updates the permission to YesAddApprenticeRecords NoToRecruitApprentices")]
    public void WhenTheProviderUpdatesThePermissionToYesAddApprenticeRecordsNoToRecruitApprentices()
    {
        ProviderUpdatePermission((AddApprenticePermissions.YesAddApprenticeRecords, RecruitApprenticePermissions.NoToRecruitApprentices));
    }
}