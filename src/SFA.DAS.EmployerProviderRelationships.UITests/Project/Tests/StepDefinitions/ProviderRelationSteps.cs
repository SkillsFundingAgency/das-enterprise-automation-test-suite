using SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRelationSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
    {
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper = new(context);

        [Given(@"a provider requests all permission from an employer")]
        public void AProviderRequestsAllPermissionFromAnEmployer()
        {
            var employerUser = context.GetUser<EPRAddRequestUser>();

            EPRLogin(employerUser);

            permissions = (AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.Allow);

            var providerConfig = context.GetProviderConfig<ProviderConfig>();

            _providerHomePageStepsHelper.GoToProviderHomePage(providerConfig, true);

            context.Get<TabHelper>().GoToUrl(UrlConfig.ProviderRelations_BaseUrl(providerConfig.Ukprn));

            var request = new ViewEmpAndManagePermissionsPage(context).ClickAddAnEmployer().StartNowToAddAnEmployer().EmailEmployerEmail(employerUser.Username).ContinueToInvite().ProviderRequestPermissions(permissions);

            request.GoToViewEmployersPage().VerifyEmployerPermission(employerUser.OrganisationName);
        }

    }
}