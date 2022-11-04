using Newtonsoft.Json;
using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerFinance.APITests.Project.Helpers;
using SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerFinanceAPISteps
    {
        private readonly Inner_EmployerFinanceApiRestClient _innerApiRestClient;        
        private readonly EmployerFinanceSqlHelper _employerFinanceSqlDbHelper;
        private readonly ObjectContext _objectContext;        

        public EmployerFinanceAPISteps(ScenarioContext context)
        {
            _innerApiRestClient = context.GetRestClient<Inner_EmployerFinanceApiRestClient>();
            _employerFinanceSqlDbHelper = context.Get<EmployerFinanceSqlHelper>();
            _objectContext = context.Get<ObjectContext>();
            _employerFinanceSqlDbHelper.GetHashedAccountId();
        }

        [Then(@"endpoint das-employer-finance-api /ping can be accessed")]
        public void ThenEndpointDas_Employer_Finance_ApiPingCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/api/healthcheck", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/levy can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLevyEndpointCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/levy/GetLevyForPeriod can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLevyGetLevyForPeriodEndpointCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var response = _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy");
            var result = JsonConvert.DeserializeObject<ICollection<LevyDeclaration>>(response.Content);
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy/{result.FirstOrDefault().PayrollYear}/{result.FirstOrDefault().PayrollMonth}", HttpStatusCode.OK);

        }

        [Then(@"endpoint api/accounts/\{accountId}/transactions can be accessed")]
        public void ThenEndpointApiAccountsAccountIdTransactionsEndpointCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/transactions/GetTransactions can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdTransactionsGetTransactionsEndpointCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var response = _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions");
            var result = JsonConvert.DeserializeObject<ICollection<TransactionSummary>>(response.Content);
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transactions/{result.FirstOrDefault().Year}/{result.FirstOrDefault().Month}", HttpStatusCode.OK);
        }       

        [Then(@"endpoint GetFinanceStatistics can be accessed")]
        public void ThenEndpointGetFinanceStatisticsCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/api/financestatistics", HttpStatusCode.OK);
        }   

        [Then(@"endpoint api/accounts/\{hashedAccountId}/transferAllowance can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdTransferAllowanceCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();  //_employerFinanceSqlDbHelper.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transferAllowance", HttpStatusCode.OK);
        }

    }
}
