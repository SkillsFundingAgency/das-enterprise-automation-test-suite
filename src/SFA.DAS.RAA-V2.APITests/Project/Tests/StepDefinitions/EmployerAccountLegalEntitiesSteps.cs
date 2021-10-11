using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.RAA_V2.APITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAccountLegalEntitiesSteps
    {
        private readonly Outer_EmployerAccountLegalEntitiesApiClient _restClient;
        private readonly EmployerLegalEntitiesSqlDbHelper _employerLegalEntitiesSqlHelper;
        private string _contextId;
        private IRestResponse apiResponse;

        public EmployerAccountLegalEntitiesSteps(ScenarioContext context)
        {
            _restClient = context.GetRestClient<Outer_EmployerAccountLegalEntitiesApiClient>();
            _employerLegalEntitiesSqlHelper = context.Get<EmployerLegalEntitiesSqlDbHelper>();
        }

        [Given(@"user prepares request with Employer HashedID")]
        public void GivenUserPreparesRequestWithEmployerHashedId() =>  _contextId = _employerLegalEntitiesSqlHelper.GetEmployerAccountHashedID();

        [When(@"the user sends (GET) request to (.*)")]
        public void WhenTheUserSendsGETRequestToVacanciesEmployeraccountlegalentities(Method method, string endpoint)
        {
            endpoint += $"/{ _contextId}";
            CreateRequest(method, endpoint);
        }
           
        [Then(@"a (OK) response is received")]
        public void ThenAOKResponseIsReceived(HttpStatusCode responseCode) => apiResponse = _restClient.Execute(responseCode);

        
        [Then(@"verify response body displays correct information")]
        public void ThenVerifyResponseBodyDisplaysCorrectInformation()
        {

            var queryResponse = _employerLegalEntitiesSqlHelper.GetEmployerAccountLegalEntities(_contextId);

            Assert.AreEqual(apiResponse.Content, queryResponse[0]);
        }

        private void CreateRequest(Method method, string endpoint) => _restClient.CreateRestRequest(method, endpoint, null);
    }
}
