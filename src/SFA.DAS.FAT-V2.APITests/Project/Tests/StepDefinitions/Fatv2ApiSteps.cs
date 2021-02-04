using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class Fatv2ApiSteps
    {
        private readonly FatV2RestClient _restClient;

        public Fatv2ApiSteps(ScenarioContext context) => _restClient = new FatV2RestClient(context.GetApiSubscriptionKeyConfig<ApiFrameworkConfig>().Fatv2ApiKey);

        [When(@"the user sends (GET|POST) request to (.*) with payload (.*)")]
        public void TheUserSendsRequestTo(Method method, string endppoint, string payload) => CreateRestRequest(method, endppoint, payload);

        [When(@"the user sends (GET) request to (.*) without payload")]
        public void WhenTheUserSendsGETRequestToEpaoregisterEpaosWithoutPayload(Method method, string endppoint) => CreateRestRequest(method, endppoint, null);

        [Then(@"a (OK|BadRequest|Unauthorized|Forbidden|NotFound) response is received")]
        public void AResponseIsReceived(HttpStatusCode responsecode)
        {
            var response = _restClient.Execute();

            Assert.Multiple(() => 
            {
                if (responsecode == HttpStatusCode.OK) Assert.IsTrue(response.IsSuccessful);

                Assert.AreEqual(responsecode, response.StatusCode, $"{response.StatusCode} - {response.Content}");
            });
        }

        private void CreateRestRequest(Method method, string endppoint, string payload) => _restClient.CreateRestRequest(method, endppoint, payload);
    }
}
