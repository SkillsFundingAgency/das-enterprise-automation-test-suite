using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using System;
using System.Linq;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Pages;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ChangeOfProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderPermissionsConfig _providerPermissionsConfig;

        public ChangeOfProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerPermissionsConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
            //new RestartWebDriverHelper(context).RestartWebDriver(UrlConfig.Provider_BaseUrl, "Approvals");
        }

        [When(@"employer sends COP request to new provider")]
        public void WhenEmployerSendsCOPRequestToNewProvider()
        {
            ScenarioContext.Current.Pending();
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
               .GoToManageYourApprenticesPage()
               .VerifyApprenticeExists();
        }


    }
}
