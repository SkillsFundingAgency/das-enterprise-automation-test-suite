using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.TestDataExport.Helper;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnect.APITests.Project.Tests.StepDefinitions;

[Binding]
public class EarlyConnectAPISteps(ScenarioContext context)
{
    private readonly Outer_EarlyConnectAPIClient _restClient = context.GetRestClient<Outer_EarlyConnectAPIClient>();

    private RestResponse _restResponse = null; 

    [When(@"the user sends (GET|POST|PUT|DELETE) request to (.*) with payload (.*)")]
    public void TheUserSendsRequestTo(Method method, string endpoint, string payload)
    {
        var data = context.Get<ApprenticePPIDataHelper>();

        var dob = data.ApprenticeDob;

        var payloadreplacement = new Dictionary<string, string>
        {
            { "email", data.ApprenticeEmail },
            { "fname", data.ApprenticeFirstname },
            { "lname", data.ApprenticeLastname},
            { "doby", dob.ToString("yyyy")},
            { "dobm", dob.ToString("MM")},
            { "dobd", dob.ToString("dd")},
        };

        _restClient.CreateRestRequest(method, endpoint, payload, payloadreplacement);
    }

    [Then(@"api (OK) response is received")]
    public void ThenApiOKResponseIsReceived(HttpStatusCode responseCode)
    {
        _restResponse = Execute(responseCode);
    }

    [Then(@"api (Created) response is received")]
    public void ThenApiCreatedResponseIsReceived(HttpStatusCode responseCode)
    {
        _restResponse = Execute(responseCode);
    }

    [Then(@"api (Bad Request) response is received")]
    public void ThenApiBadRequestResponseIsReceived(HttpStatusCode responseCode)
    {
        _restResponse = Execute(responseCode);
    }

    [Then(@"verify response body displays correct '([^']*)' information")]
    public void ThenVerifyResponseBodyDisplaysCorrectInformation(string region)
    {
        Assert.IsTrue(_restResponse.Content.Contains(region));
    }

    private RestResponse Execute(HttpStatusCode responseCode) => _restClient.Execute(responseCode);
}
