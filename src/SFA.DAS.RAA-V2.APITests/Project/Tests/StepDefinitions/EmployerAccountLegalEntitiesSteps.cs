namespace SFA.DAS.RAA_V2.APITests.Project.Tests.StepDefinitions;

[Binding]
public class EmployerAccountLegalEntitiesSteps
{
    private readonly Outer_RecruitApiClient _restClient;
    private readonly EmployerLegalEntitiesSqlDbHelper _employerLegalEntitiesSqlHelper;
    private string _hashedAccountId;
    private string _expected;
    private IRestResponse _apiResponse;

    public EmployerAccountLegalEntitiesSteps(ScenarioContext context)
    {
        _restClient = context.GetRestClient<Outer_RecruitApiClient>();

        _employerLegalEntitiesSqlHelper = context.Get<EmployerLegalEntitiesSqlDbHelper>();
    }

    [Given(@"user prepares request with Employer HashedID")]
    public void GivenUserPreparesRequestWithEmployerHashedId()
        => (_hashedAccountId, _expected) = _employerLegalEntitiesSqlHelper.GetEmployerAccountDetails();

    [When(@"the user sends (GET) request to (.*)")]
    public void WhenTheUserSendsGETRequestToVacanciesEmployeraccountlegalentities(Method method, string endpoint)
        => _restClient.CreateRestRequest(method, endpoint.Replace("{hashedAccountId}", _hashedAccountId), null);

    [Then(@"a (OK) response is received")]
    public void ThenAOKResponseIsReceived(HttpStatusCode responseCode)
        => _apiResponse = _restClient.Execute(responseCode);

    [Then(@"verify response body displays correct information")]
    public void ThenVerifyResponseBodyDisplaysCorrectInformation() 
        => StringAssert.Contains(_expected, _apiResponse.Content);
}
