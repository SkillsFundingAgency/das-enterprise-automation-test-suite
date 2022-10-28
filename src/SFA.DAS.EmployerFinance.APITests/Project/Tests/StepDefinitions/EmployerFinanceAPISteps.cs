using Newtonsoft.Json;
using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerFinance.APITests.Project;
using SFA.DAS.EmployerFinance.APITests.Project.Helpers;
using SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers;
//using SFA.DAS.HashingService;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.APITests.Project.Tests.StepDefinitions
{

    [Binding]
    public class EmployerFinanceAPISteps
    {
        private readonly Inner_EmployerFinanceApiRestClient _innerApiRestClient;        
        private readonly EmployerFinanceSqlDbHelper _employerAccountsSqlDbHelper;
        private readonly ObjectContext _objectContext;
        //private readonly IHashingService _hashingService;

        public EmployerFinanceAPISteps(ScenarioContext context)
        {
            _innerApiRestClient = context.GetRestClient<Inner_EmployerFinanceApiRestClient>();            
            _employerAccountsSqlDbHelper = context.Get<EmployerFinanceSqlDbHelper>();
            _objectContext = context.Get<ObjectContext>();
            _employerAccountsSqlDbHelper.GetAccountId();
            _employerAccountsSqlDbHelper.GetInternalAccountId();
            _employerAccountsSqlDbHelper.GetLegalEntityId();
            //_hashingService = new HashingService.HashingService("46789BCDFGHJKLMNPRSTVWXY", "SFA: digital apprenticeship service");
        }

        [Then(@"das-employer-finance-api /ping endpoint can be accessed")]
        public void ThenDas_Employer_Finance_ApiPingEndpointCanBeAccessed()
        {
            _innerApiRestClient.ExecuteEndpoint("/ping", HttpStatusCode.OK);
        }


    }
}
