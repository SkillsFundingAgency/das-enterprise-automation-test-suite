using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.ProviderFeedback.APITests.Project.Tests.Responses;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.APITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderFeedbackApiSteps(ScenarioContext context)
{
    private readonly Outer_ProviderFeedbackApiClient _restClient = context.GetRestClient<Outer_ProviderFeedbackApiClient>();

    private RestResponse _restResponse = new();

    [Given("the user sends GET request to (.*) without payload")]
    public void TheUserSendsGETRequestToWithoutPayload(string endpoint) => _restClient.CreateRestRequest(Method.Get, endpoint, string.Empty);

    [Then(@"api (OK) response is received")]
    public void ThenApiOKResponseIsReceived(HttpStatusCode responseCode)
    {
        _restResponse = _restClient.Execute(responseCode);
    }

    [Then(@"verify response body contains correct information for Ukprn '([^']*)'")]
    public void ThenVerifyResponseBodyContainsCorrectInformationForUkprn(string ukprn)
    {
        var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ProviderFeedbackApiResponse>(_restResponse.Content);

        Assert.That(jsonResponse, Is.Not.Null);
        Assert.That(jsonResponse?.ProviderFeedback.ProviderId, Is.EqualTo(ukprn), "Unexpected UKPRN in response.");
    }
}
