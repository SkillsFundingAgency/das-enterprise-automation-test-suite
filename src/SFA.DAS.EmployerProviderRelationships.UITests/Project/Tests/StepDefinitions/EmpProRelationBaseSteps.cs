using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    public abstract class EmpProRelationBaseSteps(ScenarioContext context)
    {
        protected readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

        protected readonly EmployerHomePageStepsHelper _employerHomePageHelper = new(context);

        protected readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper = new(context);

        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper = new(context);

        protected readonly ProviderConfig providerConfig = context.GetProviderConfig<ProviderConfig>();

        protected readonly ObjectContext objectContext = context.Get<ObjectContext>();

        protected readonly EprDataHelper eprDataHelper = context.Get<EprDataHelper>();

        protected readonly string[] tags = context.ScenarioInfo.Tags;

        protected (AddApprenticePermissions AddApprentice, RecruitApprenticePermissions RecruitApprentice) permissions;

        protected SearchEmployerEmailPage GoToSearchEmployerEmailPage() => new ViewEmpAndManagePermissionsPage(context).ClickAddAnEmployer().StartNowToAddAnEmployer();

        protected EmailAccountFoundPage GoToEmailAccountFoundPage() => GoToSearchEmployerEmailPage().EnterEmployerEmail();

        protected EmailAccountNotFoundPage GoToEmailAccountNotFoundPage() => GoToSearchEmployerEmailPage().EnterNewEmployerEmail();

        protected void GoToProviderRelationsHomePage()
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(providerConfig, true);

            context.Get<TabHelper>().GoToUrl(UrlConfig.ProviderRelations_BaseUrl(providerConfig.Ukprn));
        }


        protected void UpdatePermission((AddApprenticePermissions AddApprentice, RecruitApprenticePermissions RecruitApprentice) permissions)
        {
            this.permissions = permissions;

            _employerPermissionsStepsHelper.UpdateProviderPermission(providerConfig, permissions);
        }

        protected void EPRLevyUserLogin() => EPRLogin(context.GetUser<EPRLevyUser>());

        protected void EPRReLogin()
        {
            _employerHomePageHelper.GotoEmployerHomePage();

            var requestId = context.Get<RelationshipsSqlDataHelper>().GetRequestId(providerConfig.Ukprn, eprDataHelper.EmployerEmail);

            eprDataHelper.RequestId = requestId;

            eprDataHelper.AgreementId = objectContext.GetAleAgreementId();
        }

        protected void EPRLogin(EPRBaseUser user)
        {
            _employerLoginHelper.Login(user, true);

            new DeleteProviderRelationinDbHelper(context).DeleteProviderRelation();
        }
    }
}