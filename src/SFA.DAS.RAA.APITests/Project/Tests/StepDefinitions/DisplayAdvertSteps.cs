
namespace SFA.DAS.RAA.APITests.Project.Tests.StepDefinitions;

[Binding]
public class DisplayAdvertSteps(ScenarioContext context)
{
    private Outer_DisplayAdvertApiClient _restClient;

    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    private RestResponse _apiResponse;

    [When(@"the user sends a (GET) request to (.*)")]
    public void TheUserSendsAGetRequestTo(Method method, string endpoint)
    {
        Raa_Outer_ApiAuthTokenConfig apiAuthTokenConfig = context.ScenarioInfo.Tags.Contains("raaapiemployer") ? context.Get<Raa_Emp_Outer_ApiAuthTokenConfig>() : context.Get<Raa_Pro_Outer_ApiAuthTokenConfig>();

        (string msg, string apiKey) = context.ScenarioInfo.Tags.Contains("invalidapikey") ? ("An invalid", apiAuthTokenConfig.InvalidApiKey) : ("A valid", apiAuthTokenConfig.DisplayAdvertApiKey);

        _restClient = new Outer_DisplayAdvertApiClient(_objectContext, apiKey);

        if (endpoint.Contains("vacancyref", StringComparison.OrdinalIgnoreCase))
        {
            endpoint = endpoint.Replace("vacancyref", apiAuthTokenConfig.VacancyReference, StringComparison.OrdinalIgnoreCase);
        }

        _restClient.CreateRestRequest(method, endpoint, null);
    }

    [Then(@"a (OK|Unauthorized) response status is received")]
    public void ThenAOKResponseIsReceived(HttpStatusCode responseCode)
    {
        _apiResponse = _restClient.Execute(responseCode);
    }

    [Then(@"verify response body displays (.*) data")]
    public void ThenVerifyResponseBodyDisplaysVacancyInformation(string expected)
    {
        StringAssert.Contains(expected, _apiResponse.Content);
    }

    [Then("verify response body displays Access denied due to invalid key")]
    public void ThenVerifyResponseBodyDisplaysAccessDenied()
    {
        var expected = "Access denied due to invalid subscription key";
        StringAssert.Contains(expected, _apiResponse.Content);
    }
}
