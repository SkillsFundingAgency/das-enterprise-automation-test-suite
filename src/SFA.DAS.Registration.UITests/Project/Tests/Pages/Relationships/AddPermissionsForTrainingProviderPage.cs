using SFA.DAS.ProviderLogin.Service.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships
{
    public class AddPermissionsForTrainingProviderPage(ScenarioContext context, ProviderConfig providerConfig) : PermissionBasePageForTrainingProviderPage(context)
    {
        protected override string PageTitle => $"Add {providerConfig.Name.ToUpperInvariant()} and set permissions";

        public void VerifyDoNotAllowPermissions()
        {
            SetAddApprentice(AddApprenticePermissions.DoNotAllow);

            SetRecruitApprentice(RecruitApprenticePermissions.DoNotAllow);

            VerifyPage(ErrorMsg, "You must select yes for at least one permission for add apprentice records or recruit apprentices");
        }
    }
}
