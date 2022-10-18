using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Courses.APITests.Project;
using SFA.DAS.EmployerAccounts.APITests.Project.Helpers.SqlDbHelpers;
using System.Net;
using System.Web;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAccountsAPISteps
    {
        private readonly Inner_EmployerAccountsApiRestClient _innerApiRestClient;
        private readonly EmployerAccountsSqlDbHelper _employerAccountsSqlDbHelper;
        private readonly ObjectContext _objectContext;

        public EmployerAccountsAPISteps(ScenarioContext context)
        {
            _innerApiRestClient = context.GetRestClient<Inner_EmployerAccountsApiRestClient>();
            _employerAccountsSqlDbHelper = context.Get<EmployerAccountsSqlDbHelper>();
            _objectContext = context.Get<ObjectContext>();
            _employerAccountsSqlDbHelper.GetAccountId();
            _employerAccountsSqlDbHelper.GetInternalAccountId();
        }


        [Then(@"endpoint /api/accountlegalentities can be accessed")]
        public void ThenEndpointApiAccountlegalentitiesCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/api/accountlegalentities?query.pageNumber=1&query.pageSize=100", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/payeschemes can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdPayeschemesCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
           _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/payeschemes", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/payeschemes/\{payeSchemeRef} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdPayeschemesPayeSchemeRefCanBeAccessed()
        {           
            var accountId = _objectContext.GetAccountId();
            var payeschemeRef = _employerAccountsSqlDbHelper.GetpayeSchemeRef();
            var encode = HttpUtility.UrlEncode(payeschemeRef);
            var doubleEncode = HttpUtility.UrlEncode(encode);
            payeschemeRef = payeschemeRef.Replace("/", "%252F"); //double encoded             
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/payeschemes/{payeschemeRef}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts can be accessed")]
        public void ThenEndpointApiAccountsCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/", HttpStatusCode.OK);            
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdCanBeAccessed()
        {               
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{accountId}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /accounts/internal/\{accountId} can be accessed")]
        public void ThenEndpointAccountsInternalAccountIdCanBeAccessed()
        {
            var internalAccountId = _objectContext.GetInternalAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{internalAccountId}/users", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/users can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdUsersCanBeAccessed()
        {   
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/users", HttpStatusCode.OK);
        }


        [Then(@"endpoint /api/accounts/internal/\{accountId}/users can be accessed")]
        public void ThenEndpointApiAccountsInternalAccountIdUsersCanBeAccessed()
        {       
            var internalAccountId = _objectContext.GetInternalAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{internalAccountId}/users", HttpStatusCode.OK);
        }

        //TODO
        [Then(@"endpoint /api/accounts/\{hashedAccountId}/legalEntities/\{hashedlegalEntityId}/agreements/\{agreementId} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLegalEntitiesHashedlegalEntityIdAgreementsAgreementIdCanBeAccessed()
        {
            throw new PendingStepException();
        }
        
        [Then(@"endpoint /api/user/\{userRef}/accounts can be accessed")]
        public void ThenEndpointApiUserUserRefAccountsCanBeAccessed()
        {
            var userEmail = _employerAccountsSqlDbHelper.GetUserEmail();
            _innerApiRestClient.ExecuteEndpoint($"/api/User?email={userEmail}", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/legalentities can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLegalentitiesCanBeAccessed()
        {   
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/legalentities", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/accounts/\{hashedAccountId}/legalentities/\{legalEntityId} can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdLegalentitiesLegalEntityIdCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/api/accounts/M66NNB/legalentities/3842", HttpStatusCode.OK);
        }

        [Then(@"endpoint /api/statistics can be accessed")]
        public void ThenEndpointApiStatisticsCanBeAccessed()
        {   
            _innerApiRestClient.ExecuteEndpoint("/api/statistics", HttpStatusCode.OK);
        }


        [Then(@"endpoint /api/accounts/\{hashedAccountId}/transfers/connections can be accessed")]
        public void ThenEndpointApiAccountsHashedAccountIdTransfersConnectionsCanBeAccessed()
        {
            var accountId = _objectContext.GetAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/{accountId}/transfers/connections", HttpStatusCode.OK);            
        }


        [Then(@"endpoint /api/accounts/internal/\{accountId}/transfers/connections can be accessed")]
        public void ThenEndpointApiAccountsInternalAccountIdTransfersConnectionsCanBeAccessed()
        {
            var internalAccountId = _employerAccountsSqlDbHelper.GetInternalAccountId();
            _innerApiRestClient.ExecuteEndpoint($"/api/accounts/internal/{internalAccountId}/transfers/connections", HttpStatusCode.OK);
            
        }

        [Then(@"endpoint /api/user can be accessed")]
        public void ThenEndpointApiUserCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/api/User?email=test@account.com", HttpStatusCode.OK);            
        }
    }
}
