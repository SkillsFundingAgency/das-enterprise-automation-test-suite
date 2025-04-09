using System;

namespace SFA.DAS.RAA.APITests.Project.Tests.StepDefinitions;

[Binding]
public class EmployerManageVacanciesSteps(ScenarioContext context)
{
    private Outer_ManageVacancyApiClient _restClient;

    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    private RestResponse _apiResponse;

    private readonly Raa_Emp_Outer_ApiAuthTokenConfig _apiAuthTokenConfig = context.Get<Raa_Emp_Outer_ApiAuthTokenConfig>();

    [When(@"the user sends (POST) request to (.*) with payload (.*)")]
    public void TheUserSendsRequestTo(Method method, string endpoint, string payload)
    {
        _restClient = new Outer_ManageVacancyApiClient(_objectContext, _apiAuthTokenConfig.ApiKey);

        var dynamicGuid = Guid.NewGuid().ToString();

        var payloadreplacement = new Dictionary<string, string>
        {
            { "ukprn", _apiAuthTokenConfig.Ukprn},
            { "hashedid", _apiAuthTokenConfig.Hashed_AccountId},
        };

        _restClient.CreateRestRequest(method, $"/managevacancies/{endpoint}/{dynamicGuid}", payload, payloadreplacement);
    }

    [Then(@"a (Created) response is received")]
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
