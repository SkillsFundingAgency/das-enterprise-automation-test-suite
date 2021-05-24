using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Helpers;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.AssessorCertification.APITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.AssessorCertification.APITests.Project.StepDefinitions
{
    [Binding]
    public class AssessorCertificationSteps
    {
        private readonly Outer_AssessorCertificationApiRestClient _restClient;
        private readonly AssessorCertificationSqlDbHelper _assessorCertificationSqlDbHelper;

   


        public AssessorCertificationSteps(ScenarioContext context)
        {
            _restClient = context.GetRestClient<Outer_AssessorCertificationApiRestClient>();
            _assessorCertificationSqlDbHelper = context.Get<AssessorCertificationSqlDbHelper>();
           
        }
        string contextUln;
        [Given(@"the user prepares payload with uln (.*)")]
        public void GivenTheUserPreparesPayloadWithUln(string uln)
        {
            _assessorCertificationSqlDbHelper.DeleteCertificate(uln);
            contextUln = uln;
        }

        [Given(@"the user prepares payload with updated epa outcome for uln (.*)")]
        public void GivenTheUserPreparesPayloadWithUpdatedEpaOutcomeForUln(string uln)
        {
            contextUln = uln;
        }


        [When(@"the user sends (GET|POST|PUT) request to (.*) with payload (.*)")]
        public void TheUserSendsRequestTo(Method method, string endppoint, string payload) => CreateRestRequest(method, endppoint, payload);

        IRestResponse restResponse = null;

        [Then(@"a (OK|BadRequest|Unauthorized|Forbidden|NotFound|Accepted) response is received")]
        public void AResponseIsReceived(HttpStatusCode responsecode)
        {
            restResponse = _restClient.Execute(responsecode);
        }

        [Then(@"the EPARefNumber in the response is same as in the Certificates table in the database")]
        public void ThenTheEPARefNumberInTheResponseIsSameAsInTheCertificatesTableInTheDatabase()
        {
            var actualEPARef = _assessorCertificationSqlDbHelper.GetEPAreferenceAfterAPI(contextUln);

            Assert.True(restResponse.Content.ToString().Contains(actualEPARef), "Value is not contained in response");
            
        }

        private void CreateRestRequest(Method method, string endppoint, string payload) => _restClient.CreateRestRequest(method, endppoint, payload);
    }
}
