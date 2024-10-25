using SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
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
            EPRBaseUser employerUser = tags.Contains("acceptrequest") ? context.GetUser<EPRAcceptRequestUser>() : context.GetUser<EPRDeclineRequestUser>();

            EPRLogin(employerUser);

            permissions = (AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.Allow);

            GoToProviderRelationsHomePage();

            eprDataHelper.EmployerEmail = employerUser.Username;

            eprDataHelper.EmployerName = employerUser.OrganisationName;

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


        private void GoToProviderRelationsHomePage()
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(providerConfig, true);

            context.Get<TabHelper>().GoToUrl(UrlConfig.ProviderRelations_BaseUrl(providerConfig.Ukprn));
        }

        private SearchEmployerEmailPage GoToSearchEmployerEmailPage() => new ViewEmpAndManagePermissionsPage(context).ClickAddAnEmployer().StartNowToAddAnEmployer();

        private EmailAccountFoundPage GoToEmailAccountFoundPage() => GoToSearchEmployerEmailPage().EnterEmployerEmail();
    }
}