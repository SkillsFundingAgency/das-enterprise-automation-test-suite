using System;
using System.IO;
using Newtonsoft.Json.Linq;
using SFA.DAS.API.Framework.Configs;

namespace SFA.DAS.RAA.APITests.Project.Tests.StepDefinitions;

[Binding]
public class EmployerAccountLegalEntitiesSteps(ScenarioContext context)
{
    private Outer_RecruitApiClient _restClient;
    private CreateVacancyApiClient _raaRestClient;
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
    private readonly Outer_ApiAuthTokenConfig _apiAuthTokenConfig = context.Get<Outer_ApiAuthTokenConfig>();
    private readonly EmployerLegalEntitiesSqlDbHelper _employerLegalEntitiesSqlHelper = context.Get<EmployerLegalEntitiesSqlDbHelper>();
    private string _hashedAccountId;
    private string _expected;
    private RestResponse _apiResponse;

    [Given(@"user prepares request with Employer ID")]
    public void GivenUserPreparesRequestWithEmployerId()
        => (_hashedAccountId, _expected) = _employerLegalEntitiesSqlHelper.GetEmployerAccountDetails();

    [When(@"the user sends (GET) request to (.*)")]
    public void WhenTheUserSendsGETRequestToVacanciesEmployeraccountlegalentities(Method method, string endpoint)
    {
        var apiBaseUrl = UrlConfig.OuterApiUrlConfig.Outer_ApiBaseUrl;
        _restClient = new Outer_RecruitApiClient(_objectContext, _apiAuthTokenConfig, apiBaseUrl);
        _restClient.CreateRestRequest(method, endpoint.Replace("{hashedAccountId}", _hashedAccountId), null);
    }

    [Then(@"a (OK|Created) response is received")]
    public void ThenAOKResponseIsReceived(HttpStatusCode responseCode)
    {
        if(responseCode == HttpStatusCode.OK)
        {
            _apiResponse = _restClient.Execute(responseCode);
            
        } else
        {
            _apiResponse = _raaRestClient.Execute(responseCode);
        }
        
    }

    [Then(@"verify response body displays correct information")]
    public void ThenVerifyResponseBodyDisplaysCorrectInformation()
        => StringAssert.Contains(_expected, _apiResponse.Content);

    [When(@"the user sends POST request to vacancy endpoint with (.*)")]
    public void WhenTheUserSendsPOSTRequestToWithPayload(string filename)
    {
        var apiBaseUrl = UrlConfig.OuterApiUrlConfig.Outer_RAAApiBaseUrl;
        _raaRestClient = new CreateVacancyApiClient(_objectContext, _apiAuthTokenConfig, apiBaseUrl);
        Console.WriteLine($"base url: {apiBaseUrl} \n api key: {_apiAuthTokenConfig.EmployerRecruit_ApiKey} \n ukprn: {_apiAuthTokenConfig.RAA_API_Ukprn} \n hash id: {_apiAuthTokenConfig.RAA_API_Hashed_AccountId} \n payload: {json}");

        var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Project/Tests/Payload/{filename}");
        var payload = File.ReadAllText(jsonFilePath);
        JObject json = JObject.Parse(payload);
        JObject contractingParties = (JObject)json["contractingParties"];

        contractingParties["ukprn"] = _apiAuthTokenConfig.RAA_API_Ukprn;
        contractingParties["accountLegalEntityPublicHashedId"] = $"{_apiAuthTokenConfig.RAA_API_Hashed_AccountId}";

        var dynamicGuid = Guid.NewGuid().ToString();

        _raaRestClient.CreateRestRequest(Method.Post, $"/managevacancies/vacancy/{dynamicGuid}", json.ToString());
    }

    [Then(@"verify response body displays vacancy reference number")]
    public void ThenVerifyResponseBodyDisplaysVacancyReferenceNumber()
    {
        var expected = "vacancyReference";
        StringAssert.Contains(expected, _apiResponse.Content);
    }
}
