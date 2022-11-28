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
        private readonly Outer_EmployerFinanceApiHelper _employerFinanceOuterApiHelper;
        private readonly EmployerFinanceSqlHelper _employerFinanceSqlDbHelper;
        private readonly ObjectContext _objectContext;        

        public EmployerFinanceAPISteps(ScenarioContext context)
        {
            _innerApiRestClient = context.GetRestClient<Inner_EmployerFinanceApiRestClient>();
            _employerFinanceOuterApiHelper = new Outer_EmployerFinanceApiHelper(context);
            _employerFinanceSqlDbHelper = context.Get<EmployerFinanceSqlHelper>();
            _objectContext = context.Get<ObjectContext>();
            _employerFinanceSqlDbHelper.SetHashedAccountId();
            _employerFinanceSqlDbHelper.SetAccountId();
            _employerFinanceSqlDbHelper.SetEmpRef();
        }

        [Then(@"the employer finance outer api is reachable")]
        public void ThenTheApprenticeCommitmentsApiIsReachable() => _employerFinanceOuterApiHelper.Ping();

        [Then(@"endpoint /Accounts/\{accountId}/minimum-signed-agreement-version can be accessed")]
        public void ThenEndpointAccountsAccountIdMinimum_Signed_Agreement_VersionCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _employerFinanceOuterApiHelper.GetAccountMinimumSignedAgreementVersion(long.Parse(accountId));
        }

        [Then(@"endpoint /Accounts/\{accountId}/users/which-receive-notifications can be accessed")]
        public void ThenEndpointAccountsAccountIdUsersWhich_Receive_NotificationsCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _employerFinanceOuterApiHelper.GetAccountUserWhichCanReceiveNotifications(long.Parse(accountId));
        }

        [Then(@"endpoint /Pledges\?accountId=\{accountId} can be accessed")]
        public void ThenEndpointPledgesAccountIdAccountIdCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _employerFinanceOuterApiHelper.GetPledges(long.Parse(accountId));
        }


        [Then(@"endpoint /Projections/\{accountId} can be accessed")]
        public void ThenEndpointProjectionsAccountIdCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _employerFinanceOuterApiHelper.GetProjections(long.Parse(accountId));
        }

        [Then(@"endpoint /Providers can be accessed")]
        public void ThenEndpointProvidersCanBeAccessed()
        {
            _employerFinanceOuterApiHelper.GetProviders();
        }

        [Then(@"endpoint /Profiders/\{id} can be accessed")]
        public void ThenEndpointProfidersIdCanBeAccessed()
        {
            _employerFinanceOuterApiHelper.GetProvidersById();
        }

        [Then(@"endpoint /TrainingCourses/frameworks can be accessed")]
        public void ThenEndpointTrainingCoursesFrameworksCanBeAccessed()
        {
            _employerFinanceOuterApiHelper.GetTrainingCoursesFrameworks();
        }

        [Then(@"endpoint /TrainingCourses/standards can be accessed")]
        public void ThenEndpointTrainingCoursesStandardsCanBeAccessed()
        {
            _employerFinanceOuterApiHelper.GetTrainingCoursesStandards();
        }

        [Then(@"endpoint /Transfers/\{accountId}/counts can be accessed")]
        public void ThenEndpointTransfersAccountIdCountsCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _employerFinanceOuterApiHelper.GetTransfersCounts(long.Parse(accountId));
        }

        [Then(@"endpoint /Transfers/\{accountId}/financial-breakdown can be accessed")]
        public void ThenEndpointTransfersAccountIdFinancial_BreakdownCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _employerFinanceOuterApiHelper.GetTransfersFinancialBreakdown(long.Parse(accountId));
        }

        [Then(@"endpoint das-employer-finance-api /ping can be accessed")]
        public void ThenEndpointDas_Employer_Finance_ApiPingCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/ping", HttpStatusCode.OK);
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
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transferAllowance", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/levy/english-fraction-current can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLevyEnglishFractionCurrentCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy/english-fraction-current", HttpStatusCode.OK);
        }

        [Then(@"endpoint api/accounts/\{hashedAccountId}/levy/english-fraction-history can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLevyEnglishFractionHistoryCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            var empRef = _objectContext.GetEmpRef();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/levy/english-fraction-history?empRef={empRef}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/transfers/connections can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdTransfersConnectionsCanBeAccessed()
        {
            var hashedAccountId = _objectContext.GetHashedAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{hashedAccountId}/transfers/connections", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/internal/\{accountId}/transfers/connections can be accessed")]
        public void ThenEndpointApiAccountsInternalAccountIdTransfersConnectionsCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{accountId}/transfers/connections", HttpStatusCode.OK);
        }
    }
}
