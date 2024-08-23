using NUnit.Framework;
using Polly;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderPermissionsSteps
    {
        private readonly EmployerPortalLoginHelper _employerLoginHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;
        private readonly ProviderPermissionsConfig _providerPermissionConfig;
        private ProviderLoginUser _providerLoginUser;

        public ProviderPermissionsSteps(ScenarioContext context)
        {
            _context = context;
            _providerPermissionConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
            _employerLoginHelper = new EmployerPortalLoginHelper(context);
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
            _providerLoginUser = new ProviderLoginUser { Username = _providerPermissionConfig.Username, Password = _providerPermissionConfig.Password, Ukprn = _providerPermissionConfig.Ukprn };
        }

        [Given(@"Employer grant create cohort permission to a provider")]
        public void GivenEmployerGrantCreateCohortPermissionToAProvider()
        {
            var homePage = _employerLoginHelper.Login(_context.GetUser<ProviderPermissionLevyUser>(), true);

            new DeleteProviderRelationHelper(_context).DeleteProviderRelation(_providerPermissionConfig);

            _employerPermissionsStepsHelper.SetProviderPermissions(_providerPermissionConfig);

            _providerLoginUser = new ProviderLoginUser { Username = _providerPermissionConfig.Username, Password = _providerPermissionConfig.Password, Ukprn = _providerPermissionConfig.Ukprn };
        }

        [When(@"Employer revoke create cohort permission to a provider")]
        public void WhenEmployerRevokeCreateCohortPermissionToAProvider()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            _employerPermissionsStepsHelper.DoNotSetProviderPermission(_providerPermissionConfig);
        }

        [Then(@"Provider can Create Cohort")]
        public void ThenProviderCanCreateCohort()
        {
            ProviderAddApprenticeDetailsViaSelectJourneyPage providerAddApprenticeDetailsViaSelectJourneyPage =
               _providerCommonStepsHelper
               .GoToProviderHomePage(_providerLoginUser)
               .GotoSelectJourneyPage()
               .SelectAddManually();

            Assert.IsTrue(providerAddApprenticeDetailsViaSelectJourneyPage.IsAddToAnExistingCohortOptionDisplayed(), "Validate Provider can add apprentice to existing cohorts");
            Assert.IsTrue(providerAddApprenticeDetailsViaSelectJourneyPage.IsCreateANewCohortOptionDisplayed(), "Validate Provider can create a new cohort");

            _providerCommonStepsHelper.GoToProviderHomePage(_providerLoginUser, false).SignsOut();
        }

        [Then(@"Provider cannot Create Cohort")]
        public void ThenProviderCannotCreateCohort()
        {
            ProviderAddApprenticeDetailsViaSelectJourneyPage providerAddApprenticeDetailsViaSelectJourneyPage =
                  _providerCommonStepsHelper
                  .GoToProviderHomePage(_providerLoginUser)
                  .GotoSelectJourneyPage()
                  .SelectAddManually();

            Assert.IsTrue(providerAddApprenticeDetailsViaSelectJourneyPage.IsAddToAnExistingCohortOptionDisplayed(), "Validate Provider can add apprentice to existing cohorts");
            Assert.IsFalse(providerAddApprenticeDetailsViaSelectJourneyPage.IsCreateANewCohortOptionDisplayed(), "Validate Provider can not create a new cohort");
        }

    }
}