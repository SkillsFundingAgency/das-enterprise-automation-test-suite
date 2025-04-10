namespace SFA.DAS.RAA.APITests.Project.Tests.StepDefinitions;

[Binding]
public class ManageVacanciesSteps(ScenarioContext context)
{
    private Outer_ManageVacancyApiClient _restClient;

    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    private RestResponse _apiResponse;

    [When(@"the user sends (POST) request to (.*) with payload (.*)")]
    public void TheUserSendsRequestTo(Method method, string endpoint, string payload)
    {
        Raa_Outer_ApiAuthTokenConfig apiAuthTokenConfig = context.ScenarioInfo.Tags.Contains("raaapiemployer") ? context.Get<Raa_Emp_Outer_ApiAuthTokenConfig>() : context.Get<Raa_Pro_Outer_ApiAuthTokenConfig>();

        (string msg, string apiKey) = context.ScenarioInfo.Tags.Contains("invalidapikey") ? ("An invalid", apiAuthTokenConfig.InvalidApiKey) : ("A valid", apiAuthTokenConfig.ApiKey);

        string hashedid = apiAuthTokenConfig.Hashed_AccountId;

        string ukprn = apiAuthTokenConfig.Ukprn;

        _objectContext.SetDebugInformation($"'{msg}' Api key - '{apiKey}' is used to create vacancy for hashedid - '{hashedid}'and ukprn - '{ukprn}'");

        _restClient = new Outer_ManageVacancyApiClient(_objectContext, apiKey);

        var dynamicGuid = Guid.NewGuid().ToString();

        var payloadreplacement = new Dictionary<string, string>
        {
            { "ukprn", ukprn},
            { "hashedid", hashedid},
        };

        _restClient.CreateRestRequest(method, $"/managevacancies/{endpoint}/{dynamicGuid}", payload, payloadreplacement);
    }

    [Then(@"a (Created|Unauthorized) response is received")]
    public void ThenAOKResponseIsReceived(HttpStatusCode responseCode)
    {
        _apiResponse = _restClient.Execute(responseCode);
    }

    [Then(@"verify response body displays vacancy reference number")]
    public void ThenVerifyResponseBodyDisplaysVacancyReferenceNumber()
    {
        var expected = "vacancyReference";
        StringAssert.Contains(expected, _apiResponse.Content);
    }

    [Then("verify response body displays Access denied due to invalid subscription key")]
    public void ThenVerifyResponseBodyDisplaysAccessDeniedDueToInvalidSubscriptionKey()
    {
        var expected = "Access denied due to invalid subscription key";
        StringAssert.Contains(expected, _apiResponse.Content);
    }
}
