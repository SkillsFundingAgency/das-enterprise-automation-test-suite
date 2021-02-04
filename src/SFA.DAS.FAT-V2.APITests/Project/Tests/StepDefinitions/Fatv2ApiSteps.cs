using RestSharp;
using SFA.DAS.API.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class Fatv2ApiSteps
    {
        private readonly FrameworkRestClient _restClient;

        public Fatv2ApiSteps(ScenarioContext context) => _restClient = context.GetRestClient<FrameworkRestClient>();

        [When(@"the user sends (GET|POST) request to (.*) with payload (.*)")]
        public void TheUserSendsRequestTo(Method method, string endppoint, string payload) => CreateRestRequest(method, endppoint, payload);

        [When(@"the user sends (GET) request to (.*) without payload")]
        public void WhenTheUserSendsGETRequestToEpaoregisterEpaosWithoutPayload(Method method, string endppoint) => CreateRestRequest(method, endppoint, null);

        private void CreateRestRequest(Method method, string endppoint, string payload) => _restClient.CreateRestRequest(method, endppoint, payload);
    }
}
