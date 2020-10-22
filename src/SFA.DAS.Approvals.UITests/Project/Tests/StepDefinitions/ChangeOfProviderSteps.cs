using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.Framework;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ChangeOfProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderPermissionsConfig _providerPermissionsConfig;

        public ChangeOfProviderSteps(ScenarioContext context)
        {
            _context = context;
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerPermissionsConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
        }

        [When(@"employer sends COP request to new provider")]
        public void WhenEmployerSendsCOPRequestToNewProvider()
        {
            StartChangeOfProviderJourney();
            //var _newcohortReference = _commitmentsSqlDataHelper.GetNewcohortReference(Convert.ToString(_dataHelper.Ulns.First()));
            //_employerStepsHelper.UpdateCohortReference(_newcohortReference);
        }

        [When(@"new provider approves the cohort")]
        public void WhenNewProviderApprovesTheCohort()
        {
            ProviderLoginUser _providerLoginUser = new ProviderLoginUser { Username = _providerPermissionsConfig.UserId, Password = _providerPermissionsConfig.Password, Ukprn = _providerPermissionsConfig.Ukprn };
            new RestartWebDriverHelper(_context).RestartWebDriver(UrlConfig.Provider_BaseUrl, "Approvals");
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_providerLoginUser, false);
        }

        [Then(@"a new live apprenticeship record is created with new Provider")]
        public void ThenANewLiveApprenticeshipRecordIsCreatedWithNewProvider()
        {
            new EmployerStepsHelper(_context)
               .GoToManageYourApprenticesPage();
               //.VerifyNewApprenticeRecordIsCreated();
        }

        private void StartChangeOfProviderJourney()
        {
            _employerStepsHelper.ViewCurrentApprenticeDetails()
                                .ClickOnChangeOfProviderLink();
        }
    }
}
