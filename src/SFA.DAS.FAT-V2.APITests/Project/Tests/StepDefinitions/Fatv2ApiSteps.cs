using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class Fatv2ApiSteps
    {
        private readonly Fatv2ApiConfig fatv2ApiConfig;
        private FrameworkRestClient frameworkRestClient;

        public Fatv2ApiSteps(ScenarioContext context) => fatv2ApiConfig = context.GetFatV2ApiConfig<Fatv2ApiConfig>();

        [Given(@"the fatv2 api client is created")]
        public void TheFatvApiClientIsCreated()
        {
            frameworkRestClient = new FrameworkRestClient(UrlConfig.FATV2_BaseUrl);

            frameworkRestClient.Addheaders(
                new Dictionary<string, string>
                {
                    { "X-Version", "1" },
                    { "Ocp-Apim-Subscription-Key", fatv2ApiConfig.ApiKey }
                });
        }

        [When(@"the user sends (GET|POST) request to (.*) with payload (.*)")]
        public void TheUserSendsRequestTo(Method method, string endppoint, string payload)
        {
            frameworkRestClient.CreateRestRequest(method, endppoint, payload);
        }

        [When(@"the user sends (GET) request to (.*) without payload")]
        public void WhenTheUserSendsGETRequestToEpaoregisterEpaosWithoutPayload(Method method, string endppoint)
        {
            frameworkRestClient.CreateRestRequest(method, endppoint, null);
        }

        [Then(@"a (OK|BadRequest|Unauthorized|Forbidden|NotFound) response is received")]
        public void AResponseIsReceived(HttpStatusCode responsecode)
        {
            var response = frameworkRestClient.Execute();

            Assert.Multiple(() => 
            {
                if (responsecode == HttpStatusCode.OK) Assert.IsTrue(response.IsSuccessful);

                Assert.AreEqual(responsecode, response.StatusCode, $"{response.StatusCode} - {response.Content}");
            });
        }
    }
}
