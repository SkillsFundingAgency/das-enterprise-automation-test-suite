using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Courses.APITests.Project;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAccountsAPISteps
    {
        private readonly Inner_EmployerAccountsApiRestClient _innerApiRestClient;

        public EmployerAccountsAPISteps(ScenarioContext context)
        {
            _innerApiRestClient = new Inner_EmployerAccountsApiRestClient(context.Get<ObjectContext>(), (context.Get<Inner_ApiFrameworkConfig>()));//context.GetRestClient<Inner_EmployerAccountsApiRestClient>();
        }       

        [Then(@"das-employer-accounts-api /ping endpoint can be accessed")]
        public void ThenDas_Employer_Accounts_ApiPingEndpointCanBeAccessed()
        {
            /************************************Employer Accounts******************************************/

            //_innerApiRestClient.PerformHeathCheck("/ping", HttpStatusCode.OK);
            //_innerApiRestClient.PerformHeathCheck("/api/accounts/M66NNB", HttpStatusCode.OK);

            //_innerApiRestClient.PerformHeathCheck("/api/accounts/M66NNB/users", HttpStatusCode.OK);
            //_innerApiRestClient.PerformHeathCheck("/api/accounts/internal/10757/users", HttpStatusCode.OK);


            /************************************Legal  Entities******************************************/
            //_innerApiRestClient.PerformHeathCheck("/api/accounts/M66NNB/legalentities", HttpStatusCode.OK);
            //_innerApiRestClient.PerformHeathCheck("/api/accounts/M66NNB/legalentities/3842", HttpStatusCode.OK);

            /************************************Statistics******************************************/
            //_innerApiRestClient.PerformHeathCheck("/api/statistics", HttpStatusCode.OK);

            /************************************Transfer Connections******************************************/
            //_innerApiRestClient.PerformHeathCheck("/api/accounts/M66NNB/transfers/connections", HttpStatusCode.OK);
            //_innerApiRestClient.PerformHeathCheck("/api/accounts/internal/10757/transfers/connections", HttpStatusCode.OK);


            /************************************User******************************************/
            //_innerApiRestClient.PerformHeathCheck("/api/User?email=test@account.com", HttpStatusCode.OK);

            /************************************AccountLegalEntities******************************************/
            //_innerApiRestClient.PerformHeathCheck("/api/accountlegalentities?query.pageNumber=1&query.pageSize=100", HttpStatusCode.OK);

            /************************************AccountPayeSchemes******************************************/
            // _innerApiRestClient.PerformHeathCheck("/api/accounts/MD9BYJ/payeschemes", HttpStatusCode.OK);
            //TODO : Not working
            //_innerApiRestClient.PerformHeathCheck("/api/accounts/MD9BYJ/payeschemes/100%2FGDS00011", HttpStatusCode.OK);
        

            /************************************Employer Agreement******************************************/

        }

    }
}
