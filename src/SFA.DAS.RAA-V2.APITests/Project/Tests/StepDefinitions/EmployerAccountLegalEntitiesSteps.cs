namespace SFA.DAS.RAA_V2.APITests.Project.Tests.StepDefinitions;

[Binding]
public class EmployerAccountLegalEntitiesSteps
{
    private readonly Outer_EmployerAccountLegalEntitiesApiClient _restClient;
    private readonly EmployerLegalEntitiesSqlDbHelper _employerLegalEntitiesSqlHelper;
    private string _hashedAccountId;
    private IRestResponse _apiResponse;

    public EmployerAccountLegalEntitiesSteps(ScenarioContext context)
    {
        _restClient = context.GetRestClient<Outer_EmployerAccountLegalEntitiesApiClient>();

        _employerLegalEntitiesSqlHelper = context.Get<EmployerLegalEntitiesSqlDbHelper>();
    }

    [Given(@"user prepares request with Employer HashedID")]
    public void GivenUserPreparesRequestWithEmployerHashedId()
        => _hashedAccountId = _employerLegalEntitiesSqlHelper.GetEmployerAccountHashedID();

    [When(@"the user sends (GET) request to (.*)")]
    public void WhenTheUserSendsGETRequestToVacanciesEmployeraccountlegalentities(Method method, string endpoint)
        => _restClient.CreateRestRequest(method, endpoint.Replace("{hashedAccountId}", _hashedAccountId), null);

    [Then(@"a (OK) response is received")]
    public void ThenAOKResponseIsReceived(HttpStatusCode responseCode)
        => _apiResponse = _restClient.Execute(responseCode);

    [Then(@"verify response body displays correct information")]
    public void ThenVerifyResponseBodyDisplaysCorrectInformation()
    {
        var expected = _employerLegalEntitiesSqlHelper.GetEmployerAccountLegalEntities(_hashedAccountId);

        StringAssert.AreEqualIgnoringCase(expected, _apiResponse.Content); 
    }
}
