using RestSharp;
using SFA.DAS.API.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnect.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StudentDataStepDefinitions(ScenarioContext context)
    {
      
        private readonly Outer_EarlyConnectAPIClient _restClient = context.GetRestClient<Outer_EarlyConnectAPIClient>();
        private RestResponse _restResponse = null;
        private string _expected;
        private RestResponse _apiResponse;



        [When(@"the user sends (GET|POST|PUT|DELETE) request to (.*) with payload (.*)")]
        public void TheUserSendsRequestTo(Method method, string endppoint, string payload)
        {
            _restClient.CreateRestRequest(method, endppoint, payload);
        }

        [Then(@"api OK response is received")]
        public void ThenApiOKResponseIsReceived()
        {
            throw new PendingStepException();
        }



        [Then(@"a <ResponseStatus> response is received")]
        public void ThenAResponseStatusResponseIsReceived()
        {
            throw new PendingStepException();
        }




    }
}
