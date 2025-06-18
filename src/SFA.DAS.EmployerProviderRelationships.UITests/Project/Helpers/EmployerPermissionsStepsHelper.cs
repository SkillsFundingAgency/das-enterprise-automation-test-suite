
namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;

public class EmployerPermissionsStepsHelper(ScenarioContext context)
{
    public HomePage SetAllProviderPermissions(ProviderConfig providerConfig) => SetProviderPermissions(providerConfig, (AddApprenticePermissions.YesAddApprenticeRecords, RecruitApprenticePermissions.YesRecruitApprentices));

    public HomePage SetCreateCohortProviderPermissions(ProviderConfig providerConfig) => SetProviderPermissions(providerConfig, (AddApprenticePermissions.YesAddApprenticeRecords, RecruitApprenticePermissions.NoToRecruitApprentices));

    public HomePage RemoveAllProviderPermission(ProviderConfig providerConfig) => UpdateProviderPermission(providerConfig, (AddApprenticePermissions.NoToAddApprenticeRecords, RecruitApprenticePermissions.NoToRecruitApprentices));

    private HomePage SetProviderPermissions(ProviderConfig providerConfig, (AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permissions)
    {
        return OpenProviderPermissions()
            .SelectAddATrainingProvider()
            .SearchForATrainingProvider(providerConfig)
            .AddOrSetPermissions(permissions)
            .VerifyYouHaveAddedNotification(providerConfig.Name)
            .GoToHomePage();
    }

    public HomePage AcceptOrDeclineProviderRequest(RequestType requestType, ProviderConfig providerConfig, string requestId, bool accept)
    {
        var page = OpenProviderPermissions();

        AddOrReviewRequestFromProvider page1 = requestType == RequestType.Permission ? page.ReviewProviderRequests(providerConfig, requestId) : page.ViewProviderRequests(providerConfig, requestId);

        RegistrationBasePage registrationBasePage = requestType == RequestType.Permission ? 
            accept ? page1.AcceptProviderRequest().VerifyYouHaveSetPermissionNotification(providerConfig.Name) : page1.DeclinePermissionRequest().VerifyYouHaveDeclinedNotification(providerConfig.Name) :
            accept ? page1.AcceptProviderRequest().VerifyYouHaveAddedNotification(providerConfig.Name) : page1.DeclineAddRequest().ConfirmDeclineRequest();

        return registrationBasePage.GoToHomePage();
    }

    internal HomePage UpdateProviderPermission(ProviderConfig providerConfig, (AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permissions)
    {
        return OpenProviderPermissions()
               .SelectChangePermissions(providerConfig.Ukprn)
               .AddOrSetPermissions(permissions)
               .VerifyYouHaveSetPermissionNotification()
               .GoToHomePage();
    }

    internal ManageTrainingProvidersPage OpenProviderPermissions() => new ManageTrainingProvidersLinkHomePage(context).OpenRelationshipPermissions();

}