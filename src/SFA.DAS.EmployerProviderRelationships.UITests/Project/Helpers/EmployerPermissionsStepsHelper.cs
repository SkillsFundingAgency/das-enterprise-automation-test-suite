using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers
{
    public class EmployerPermissionsStepsHelper(ScenarioContext context)
    {
        public HomePage SetAllProviderPermissions(ProviderConfig providerConfig) => SetProviderPermissions(providerConfig, (AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.Allow));

        public HomePage SetCreateCohortProviderPermissions(ProviderConfig providerConfig) => SetProviderPermissions(providerConfig, (AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.DoNotAllow));

        public HomePage RemoveAllProviderPermission(ProviderConfig providerConfig) => UpdateProviderPermission(providerConfig, (AddApprenticePermissions.DoNotAllow, RecruitApprenticePermissions.DoNotAllow));

        private HomePage SetProviderPermissions(ProviderConfig providerConfig, (AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permissions)
        {
            return OpenProviderPermissions()
                .SelectAddATrainingProvider()
                .SearchForATrainingProvider(providerConfig)
                .AddOrSetPermissions(permissions)
                .VerifyYouHaveAddedNotification()
                .GoToHomePage();
        }

        public HomePage AcceptOrDeclineProviderPermissionsRequest(ProviderConfig providerConfig, string requestId, bool doesAllow)
        {
            return OpenProviderPermissions().ViewProviderRequests(providerConfig, requestId).AcceptOrDeclineRequest(doesAllow).GoToHomePage();
        }

        internal HomePage UpdateProviderPermission(ProviderConfig providerConfig, (AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permissions)
        {
            return OpenProviderPermissions()
                   .SelectChangePermissions(providerConfig.Ukprn)
                   .AddOrSetPermissions(permissions)
                   .VerifyYouHaveSetPermissionNotification()
                   .GoToHomePage();
        }

        internal YourTrainingProvidersPage OpenProviderPermissions() => new YourTrainingProvidersLinkHomePage(context).OpenRelationshipPermissions();

    }
}