using Newtonsoft.Json;
using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerAccounts.APITests.Project.Helpers;
using SFA.DAS.EmployerAccounts.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.HashingService;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAccountsLegacyAPISteps
    {
        private readonly Inner_EmployerAccountsApiRestClient _innerApiRestClient;
        private readonly Inner_EmployerAccountsLegacyApiRestClient _innerApiLegacyRestClient;
        private readonly EmployerAccountsSqlDbHelper _employerAccountsSqlDbHelper;
        private readonly ObjectContext _objectContext;
        private readonly IHashingService _hashingService;

        public EmployerAccountsLegacyAPISteps(ScenarioContext context)
        {
            _innerApiRestClient = context.GetRestClient<Inner_EmployerAccountsApiRestClient>();
            _innerApiLegacyRestClient = context.GetRestClient<Inner_EmployerAccountsLegacyApiRestClient>();
            _employerAccountsSqlDbHelper = context.Get<EmployerAccountsSqlDbHelper>();
            _objectContext = context.Get<ObjectContext>();
            _employerAccountsSqlDbHelper.SetAccountId();
            _employerAccountsSqlDbHelper.SetAccountId();
            _employerAccountsSqlDbHelper.SetLegalEntityId();
            _employerAccountsSqlDbHelper.GetUserRef();
            _hashingService = new HashingService.HashingService("46789BCDFGHJKLMNPRSTVWXY", "SFA: digital apprenticeship service");
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/internal/\{accountId} can be accessed")]
        public void ThenEndpointApiAccountsInternalAccountIdCanBeAccessed()
        {
            var accountId = _objectContext.GetInternalAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/internal/{accountId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/users from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdUsersFromLegacyAccountsApiCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/users", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{accountId}/users can be accessed")]
        public void ThenEndpointApiAccountsAccountIdUsersCanBeAccessed()
        {
            var internalAccountId = _objectContext.GetInternalAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{internalAccountId}/users", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{accountId}/legalEntities/\{legalEntityId}/agreements/\{agreementId}/agreement can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLegalEntitiesLegalEntityIdAgreementsAgreementIdAgreementCanBeAccessed()
        {
            var result = _employerAccountsSqlDbHelper.GetAgreementId();
            var hashedAgreementId = _hashingService.HashValue((long)result[0][1]);
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{_objectContext.GetAccountId()}/legalentities/{result[0][0]}/agreements/{hashedAgreementId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{accountId}/legalentities can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLegalentitiesCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/legalentities", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{accountId}/legalentities\?includeDetails=true can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLegalentitiesIncludeDetailsTruecanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/legalentities?includeDetails=true", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{accountId}/legalentities/\{legalEntityId} can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLegalentitiesLegalEntityIdCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            var legalEntityId = _objectContext.GetLegalEntityId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/legalentities/{legalEntityId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{accountId}/levy can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLevyCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/levy", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accountlegalentities\?pageNumber=(.*)&pageSize=(.*) can be accessed")]
        public void ThenEndpointApiAccountlegalentitiesPageNumberPageSizeCanBeAccessed(int p0, int p1)
        {
            _innerApiLegacyRestClient.ExecuteEndpoint("/api/accountlegalentities?pageNumber=1&pageSize=100", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{accountId}/payeschemes can be accessed")]
        public void ThenEndpointApiAccountsAccountIdPayeschemesCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/payeschemes", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/statistics from legacy accounts can be accessed")]
        public void ThenEndpointApiStatisticsFromLegacyAccountsCanBeAccessed()
        {
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/statistics", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{accountId}/transactions can be accessed")]
        public void ThenEndpointApiAccountsAccountIdTransactionsCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/transactions", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{accountId}/transactions/year/month can be accessed")]
        public void ThenEndpointApiAccountsAccountIdTransactionsYearMonthCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            var response = _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/transactions");
            var result = JsonConvert.DeserializeObject<ICollection<TransactionSummary>>(response.Content);
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/transactions/{result.FirstOrDefault().Year}/{result.FirstOrDefault().Month}", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/user/\{userId}/accounts can be accessed")]
        public void ThenEndpointApiUserUserIdAccountsCanBeAccessed()
        {
            var userId = _objectContext.GetUserRef();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/user/{userId}/accounts", HttpStatusCode.OK);
        }
    }
}
