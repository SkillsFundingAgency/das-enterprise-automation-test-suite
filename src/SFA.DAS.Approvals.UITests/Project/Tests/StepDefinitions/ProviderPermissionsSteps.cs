using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
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
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderPermissionsConfig _providerPermissionConfig;
        private ProviderLoginUser _providerLoginUser;
        private ApprovalsProviderHomePage _providerHomePage;

        public ProviderPermissionsSteps(ScenarioContext context)
        {
            _context = context;
            _providerPermissionConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
            _employerLoginHelper = new EmployerPortalLoginHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
        }
   
        [Given(@"Employer grant create cohort permission to a provider")]
        public void GivenEmployerGrantCreateCohortPermissionToAProvider()
        {
            _employerPermissionsStepsHelper.RemovePermissisons(_providerPermissionConfig);

            var homePage = _employerLoginHelper.Login(_context.GetUser<ProviderPermissionLevyUser>(), true);

            _employerPermissionsStepsHelper.SetAgreementId(homePage, string.Empty);

            _employerPermissionsStepsHelper.SetCreateCohortPermission(_providerPermissionConfig.Ukprn);

            _providerLoginUser = new ProviderLoginUser { Username = _providerPermissionConfig.UserId, Password = _providerPermissionConfig.Password, Ukprn = _providerPermissionConfig.Ukprn };
        }

        [When(@"Employer revoke create cohort permission to a provider")]
        public void WhenEmployerRevokeCreateCohortPermissionToAProvider()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            _employerPermissionsStepsHelper.UnSetCreateCohortPermission();
        }

        [Then(@"Provider can Create Cohort")]
        public void ThenProviderCanCreateCohort()
        {
            var linkDisplayed = CreateCohortPermissionLinkIsDisplayed();

            if (linkDisplayed)
            {
                Assert.IsTrue(CanChooseAnEmployer(), "Create Cohort link is not visible");
            }
            else
            {
                Assert.IsTrue(linkDisplayed, "Create Cohort link is not visible");
            }

            _providerHomePage.SignsOut();
        }

        [Then(@"Provider cannot Create Cohort")]
        public void ThenProviderCannotCreateCohort()
        {
            var linkDisplayed = CreateCohortPermissionLinkIsDisplayed();

            if (linkDisplayed)
            {
                Assert.IsFalse(linkDisplayed, "Create Cohort link is visible");
            }
            else
            {
                Assert.IsFalse(linkDisplayed, "Create Cohort link is visible");
            }
        }

        private bool CanChooseAnEmployer() => _providerHomePage.GotoSelectJourneyPage().SelectOptionCreateNewCohort().CanChooseAnEmployer();

        private bool CreateCohortPermissionLinkIsDisplayed()
        {
            _providerHomePage = _providerStepsHelper.GoToProviderHomePage(_providerLoginUser);

            return _providerHomePage.CreateCohortPermissionLinkIsDisplayed();
        }
    }
}