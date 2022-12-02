using Newtonsoft.Json;
using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerAccounts.APITests.Project;
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
    public class EmployerAccountsAPISteps
    {
        private readonly Inner_EmployerAccountsApiRestClient _innerApiRestClient;
        private readonly Outer_EmployerAccountsApiHelper _employerAccountsOuterApiHelper;
        private readonly Inner_EmployerAccountsLegacyApiRestClient _innerApiLegacyRestClient;
        private readonly EmployerAccountsSqlDbHelper _employerAccountsSqlDbHelper;
        private readonly ObjectContext _objectContext;
        private readonly IHashingService _hashingService;

        public EmployerAccountsAPISteps(ScenarioContext context)
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
            _hashingService = new HashingService.HashingService("46789BCDFGHJKLMNPRSTVWXY", "SFA: digital apprenticeship service");
        }

        [Then(@"the employer accounts outer api is reachable")]
        public void ThenTheEmployerAccountsOuterApiIsReachable() => _employerAccountsOuterApiHelper.Ping();

        [Then(@"endpoint /Accounts/\{hashedAccountId}/levy/english-fraction-current can be accessed")]
        public void ThenEndpointAccountsHashedAccountIdLevyEnglish_Fraction_CurrentCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _employerAccountsOuterApiHelper.GetAccountEnglishFractionCurrent(hashedAccountId);
        }

        [Then(@"endpoint /Accounts/\{hashedAccountId}/levy/english-fraction-history can be accessed")]
        public void ThenEndpointAccountsHashedAccountIdLevyEnglish_Fraction_HistoryCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _employerAccountsOuterApiHelper.GetAccountEnglishFractionHistory(hashedAccountId);
        }

        [Then(@"endpoint /api/accountlegalentities can be accessed")]
        public void ThenEndpointApiAccountlegalentitiesCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/api/accountlegalentities?query.pageNumber=1&query.pageSize=100", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/payeschemes can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdPayeschemesCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
           _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/payeschemes", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/payeschemes/\{payeSchemeRef} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdPayeschemesPayeSchemeRefCanBeAccessed()
        {           
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var payeschemeRef = _objectContext.GetPayeSchemeRefId();
            var encodepayeschemeRef = HttpUtility.UrlEncode(payeschemeRef);
            var doubleEncodeencodepayeschemeRef = HttpUtility.UrlEncode(encodepayeschemeRef);            
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/payeschemes/{doubleEncodeencodepayeschemeRef}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts can be accessed")]
        public void ThenEndpointApiAccountsCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/", HttpStatusCode.OK);            
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdCanBeAccessed()
        {               
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /accounts/internal/\{accountId} can be accessed")]
        public void ThenEndpointAccountsInternalAccountIdCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{accountId}/users", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/users can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdUsersCanBeAccessed()
        {   
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/users", HttpStatusCode.OK);
        }


        [Then(@"endpoint /api/accounts/internal/\{accountId}/users can be accessed")]
        public void ThenEndpointApiAccountsInternalAccountIdUsersCanBeAccessed()
        {       
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{accountId}/users", HttpStatusCode.OK);
        }
        
        [Then(@"endpoint /api/accounts/\{hashedAccountId}/legalEntities/\{hashedlegalEntityId}/agreements/\{agreementId} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLegalEntitiesHashedlegalEntityIdAgreementsAgreementIdCanBeAccessed()
        {
            var result = _employerAccountsSqlDbHelper.GetAgreementId();
            var hashedAgreementId = _hashingService.HashValue((long)result[0][1]);
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{_objectContext.GetHashedAccountId()}/legalentities/{result[0][0]}/agreements/{hashedAgreementId}", HttpStatusCode.OK);
        }
        
        [Then(@"endpoint /api/user/\{userRef}/accounts can be accessed")]
        public void ThenEndpointApiUserUserRefAccountsCanBeAccessed()
        {
            var userRef = _employerAccountsSqlDbHelper.GetUserRef();
            _innerApiRestClient.ExecuteEndpoint($"/api/User/{userRef}/accounts", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/legalentities can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLegalentitiesCanBeAccessed()
        {   
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{_objectContext.GetHashedAccountId()}/legalentities", HttpStatusCode.OK);
        }
        
        [Then(@"endpoint /api/accounts/\{hashedAccountId}/legalentities/\{legalEntityId} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLegalentitiesLegalEntityIdCanBeAccessed()
        {        
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{_objectContext.GetHashedAccountId()}/legalentities/{_objectContext.GetLegalEntityId()}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/statistics can be accessed")]
        public void ThenEndpointApiStatisticsCanBeAccessed()
        {   
            _innerApiRestClient.ExecuteEndpoint("/api/statistics", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/internal/\{accountId}/transfers/connections can be accessed")]
        public void ThenEndpointApiAccountsInternalAccountIdTransfersConnectionsCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{accountId}/transfers/connections", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/user can be accessed")]
        public void ThenEndpointApiUserCanBeAccessed()
        {
            var userEmail = _employerAccountsSqlDbHelper.GetUserEmail();
            _innerApiRestClient.ExecuteEndpoint($"/api/User?email={userEmail}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /accounts/\{hashedAccountId}/levy can be accessed")]
        public void ThenEndpointAccountsHashedAccountIdLevyCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy", HttpStatusCode.OK);
        }

        [Then(@"endpoint /accounts/\{hashedAccountId}/transactions  can be accessed")]
        public void ThenEndpointAccountsHashedAccountIdTransactionsCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions", HttpStatusCode.OK);
        }

        [Then(@"endpoint /accounts/\{hashedAccountId}/transactions/\{year}/\{month} can be accessed")]
        public void ThenEndpointAccountsHashedAccountIdTransactionsYearMonthCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var response = _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions");            
            var result = JsonConvert.DeserializeObject<ICollection<TransactionSummary>>(response.Content);            
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions/{result.FirstOrDefault().Year}/{result.FirstOrDefault().Month}", HttpStatusCode.OK);
        }

        [Then(@"endpoint accounts/\{hashedAccountId}/levy/\{payrollYear}/\{payrollMonth} can be accessed")]
        public void ThenEndpointAccountsHashedAccountIdLevyPayrollYearPayrollMonthCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var response = _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy");
            var result = JsonConvert.DeserializeObject<ICollection<LevyDeclaration>>(response.Content);
            _innerApiLegacyRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy/{result.FirstOrDefault().PayrollYear}/{result.FirstOrDefault().PayrollMonth}", HttpStatusCode.OK);
        }

        [Then(@"das-employer-accounts-api /ping endpoint can be accessed")]
        public void ThenDas_Employer_Accounts_ApiPingEndpointCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/ping", HttpStatusCode.OK);
        }
    }
}
