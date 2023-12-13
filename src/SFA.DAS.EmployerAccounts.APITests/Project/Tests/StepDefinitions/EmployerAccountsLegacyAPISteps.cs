using Newtonsoft.Json;
using SFA.DAS.EmployerAccounts.APITests.Project.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAccountsLegacyAPISteps(ScenarioContext context) : BaseSteps(context)
    {
        [Then(@"endpoint api/accounts/\{hashedAccountId} from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/internal/\{accountId} from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsInternalAccountIdCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/internal/{accountId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/users from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdUsersFromLegacyAccountsApiCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/users", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/internal/\{accountId}/users from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdUsersCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{accountId}/users", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/legalEntities/\{publicHashedLegalEntityId}/agreements/\{hashedAgreementId}/agreement from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLegalEntitiesLegalEntityIdAgreementsAgreementIdAgreementCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var agreementInfo = _employerAccountsSqlDbHelper.GetAgreementInfo();
            var accountLegalEntityPublicHashedId = agreementInfo[0][0];
            var hashedAgreementId = _hashingService.HashValue((long)agreementInfo[0][1]);
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/legalentities/{accountLegalEntityPublicHashedId}/agreements/{hashedAgreementId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/legalentities from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLegalentitiesCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/legalentities", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/legalentities\?includeDetails=true from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLegalentitiesIncludeDetailsTruecanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/legalentities?includeDetails=true", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/legalentities/\{legalEntityId} from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLegalentitiesLegalEntityIdCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var legalEntityId = _objectContext.GetLegalEntityId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/legalentities/{legalEntityId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/levy from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdLevyCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accountlegalentities\?pageNumber=(.*)&pageSize=(.*) from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountlegalentitiesPageNumberPageSizeCanBeAccessed(int p0, int p1)
        {
            _innerApiLegacyRestClient.ExecuteEndpoint("/api/accountlegalentities?pageNumber=1&pageSize=100", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/payeschemes from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdPayeschemesCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/payeschemes", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/statistics from legacy accounts api can be accessed")]
        public void ThenEndpointApiStatisticsFromLegacyAccountsCanBeAccessed()
        {
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/statistics", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/transactions from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdTransactionsCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/transactions/year/month from legacy accounts api can be accessed")]
        public void ThenEndpointApiAccountsAccountIdTransactionsYearMonthCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var response = _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions");
            var result = JsonConvert.DeserializeObject<ICollection<TransactionSummary>>(response.Content);
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions/{result.FirstOrDefault().Year}/{result.FirstOrDefault().Month}", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/user/\{userRef}/accounts from legacy accounts api can be accessed")]
        public void ThenEndpointApiUserUserRefAccountsCanBeAccessed()
        {
            var userRef = _employerAccountsSqlDbHelper.GetUserRef();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/user/{userRef}/accounts", HttpStatusCode.OK);
        }
    }
}
