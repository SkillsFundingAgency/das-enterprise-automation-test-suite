using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    public abstract class EmpProRelationBaseSteps(ScenarioContext context)
    {
        protected readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

        protected readonly EmployerHomePageStepsHelper _employerHomePageHelper = new(context);

        protected readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper = new(context);

        protected readonly ProviderConfig providerConfig = context.GetProviderConfig<ProviderConfig>();

        protected readonly ObjectContext objectContext = context.Get<ObjectContext>();

        protected readonly EprDataHelper eprDataHelper = context.Get<EprDataHelper>();

        protected (AddApprenticePermissions AddApprentice, RecruitApprenticePermissions RecruitApprentice) permissions;

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