using System;
using System.Linq;

namespace SFA.DAS.RAA.APITests.Project.Tests.StepDefinitions;

[Binding]
public class EmployerManageVacanciesSteps(ScenarioContext context)
{
    private Outer_ManageVacancyApiClient _restClient;

    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    private RestResponse _apiResponse;

    [When(@"the user sends (POST) request to (.*) with payload (.*)")]
    public void TheUserSendsRequestTo(Method method, string endpoint, string payload)
    {
        Raa_Outer_ApiAuthTokenConfig apiAuthTokenConfig = context.ScenarioInfo.Tags.Contains("raaapiemployer") ? context.Get<Raa_Emp_Outer_ApiAuthTokenConfig>() : context.Get<Raa_Pro_Outer_ApiAuthTokenConfig>();

        string apiKey = context.ScenarioInfo.Tags.Contains("invalidapikey") ? apiAuthTokenConfig.InvalidApiKey : apiAuthTokenConfig.ApiKey;

        _restClient = new Outer_ManageVacancyApiClient(_objectContext, apiKey);

        var dynamicGuid = Guid.NewGuid().ToString();

        var payloadreplacement = new Dictionary<string, string>
        {
            { "ukprn", apiAuthTokenConfig.Ukprn},
            { "hashedid", apiAuthTokenConfig.Hashed_AccountId},
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
}
