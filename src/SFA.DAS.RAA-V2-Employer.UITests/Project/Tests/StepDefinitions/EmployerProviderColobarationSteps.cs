using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using EmployerStepsHelper = SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers.EmployerStepsHelper;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerProviderColobarationSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly RAAV2DataHelper _rAAV2DataHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;
        private readonly ProviderPermissionsConfig _providerPermissionConfig;

        public EmployerProviderColobarationSteps(ScenarioContext context)
        {
            _context = context;
            _rAAV2DataHelper = context.Get<RAAV2DataHelper>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
            _providerPermissionConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
        }

        [Given(@"the Employer grants permission to the provider to create advert with review option")]
        public void GivenTheEmployerGrantsPermissionToTheProviderToCreateAdvertWithReviewOption()
        {
            _employerPermissionsStepsHelper.RemovePermissisons(_providerPermissionConfig);

            var loginUser = _context.GetUser<RAAV2EmployerProviderPermissionUser>();

            var homePage = _employerStepsHelper.GoToHomePage(loginUser);

            _employerPermissionsStepsHelper.SetAgreementId(homePage, loginUser.PermissionOrganisationName);

            _employerPermissionsStepsHelper.SetRecruitApprenticesPermission(_providerPermissionConfig.Ukprn, loginUser.PermissionOrganisationName);
        }
    }
}
