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

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ChangeOfProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private ProviderLoginUser _providerLoginUser;
        private ApprovalsProviderHomePage _providerHomePage;
        private readonly ProviderPermissionsConfig _providerPermissionsConfig;


        private readonly string _oldProvider;
        private readonly string _newProvider;

        public ChangeOfProviderSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.GetApprovalsConfig<ApprovalsConfig>());
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context);
            _oldProvider = context.GetProviderConfig<ProviderConfig>().UserId;
            _providerPermissionsConfig = context.GetProviderPermissionConfig<ProviderPermissionsConfig>();
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
            _providerHomePage = _providerStepsHelper.GoToProviderHomePage(_providerLoginUser, true);
        }

    }
}
