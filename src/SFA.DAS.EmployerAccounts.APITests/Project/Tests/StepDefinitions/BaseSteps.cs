using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerAccounts.APITests.Project.Helpers;
using SFA.DAS.EmployerAccounts.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.HashingService;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Tests.StepDefinitions
{
    public abstract class BaseSteps
    {
        protected readonly Inner_EmployerAccountsApiRestClient _innerApiRestClient;
        protected readonly Outer_EmployerAccountsApiHelper _employerAccountsOuterApiHelper;
        protected readonly Inner_EmployerAccountsLegacyApiRestClient _innerApiLegacyRestClient;
        protected readonly EmployerAccountsSqlDbHelper _employerAccountsSqlDbHelper;
        protected readonly ObjectContext _objectContext;
        protected readonly IHashingService _hashingService;
        private readonly EmployerAccountsApiConfig _config;

        public BaseSteps(ScenarioContext context)
        {
            _innerApiRestClient = context.GetRestClient<Inner_EmployerAccountsApiRestClient>();
            _employerAccountsOuterApiHelper = new Outer_EmployerAccountsApiHelper(context);
            _innerApiLegacyRestClient = context.GetRestClient<Inner_EmployerAccountsLegacyApiRestClient>();
            _employerAccountsSqlDbHelper = context.Get<EmployerAccountsSqlDbHelper>();
            _objectContext = context.Get<ObjectContext>();
            _employerAccountsSqlDbHelper.SetHashedAccountId();
            _employerAccountsSqlDbHelper.SetAccountId();
            _employerAccountsSqlDbHelper.SetLegalEntityId();
            _employerAccountsSqlDbHelper.SetPayeSchemeRef();
            _config = context.GetEmployerAccountsApiConfig<EmployerAccountsApiConfig>();
            _hashingService = new HashingService.HashingService(_config.HashCharacters, _config.HashString);

            _employerAccountsSqlDbHelper.SetHashedAccountId();
            _employerAccountsSqlDbHelper.SetAccountId();
            _employerAccountsSqlDbHelper.SetLegalEntityId();
            _employerAccountsSqlDbHelper.SetPayeSchemeRef();
        }
    }
}
