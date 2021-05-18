using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Helpers;
using SFA.DAS.API.Framework.RestClients;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.AssessorCertification.APITests.Project.StepDefinitions
{
    [Binding]
    public class AssessorCertificationSteps
    {
        private readonly Outer_AssessorCertificationApiRestClient _restClient;

        public AssessorCertificationSteps(ScenarioContext context) => _restClient = context.GetRestClient<Outer_AssessorCertificationApiRestClient>();

        [When(@"the user sends (GET|POST|PUT) request to (.*) with payload (.*)")]
        public void TheUserSendsRequestTo(Method method, string endppoint, string payload) => CreateRestRequest(method, endppoint, payload);

        [Then(@"a (OK|BadRequest|Unauthorized|Forbidden|NotFound|Accepted) response is received")]
        public void AResponseIsReceived(HttpStatusCode responsecode) => _restClient.Execute(responsecode);

        private void CreateRestRequest(Method method, string endppoint, string payload) => _restClient.CreateRestRequest(method, endppoint, payload);
    }
}
