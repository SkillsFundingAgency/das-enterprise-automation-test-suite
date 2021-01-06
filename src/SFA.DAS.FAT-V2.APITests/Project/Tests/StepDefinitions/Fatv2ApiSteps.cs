using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TransformationSteps
    {
        public TransformationSteps(ScenarioContext context) { }

        [StepArgumentTransformation(@"(GET|POST)")]
        public Method HttpMethodTransformation(string method) => Enum.Parse<Method>(method, true);

    }
    

    [Binding]
    public class Fatv2ApiSteps
    {
        private readonly Fatv2ApiConfig fatv2ApiConfig;
        private FrameworkRestClient frameworkRestClient;

        public Fatv2ApiSteps(ScenarioContext context)
        {
            fatv2ApiConfig = context.GetFatV2ApiConfig<Fatv2ApiConfig>();
        }

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

        [When(@"the user sends (GET|POST) request to (.*)")]
        public void TheUserSendsRequestTo(Method method, string endppoint)
        {
            frameworkRestClient.CreateRestRequest(method, endppoint);
        }

        [Then(@"a valid response is received")]
        public void ThenAValidResponseIsReceived()
        {
            var response = frameworkRestClient.Execute();

            Assert.Multiple(() => 
            {
                Assert.IsTrue(response.IsSuccessful);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"{response.StatusCode} - {response.Content}");
            });
        }
    }
}
