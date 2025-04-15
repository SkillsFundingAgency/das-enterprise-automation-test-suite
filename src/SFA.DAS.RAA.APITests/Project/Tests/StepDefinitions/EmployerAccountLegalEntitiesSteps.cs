namespace SFA.DAS.RAA.APITests.Project.Tests.StepDefinitions;


[Binding]
public class EmployerAccountLegalEntitiesSteps(ScenarioContext context)
{
    private readonly Outer_RecruitApiClient _restClient = context.GetRestClient<Outer_RecruitApiClient>();

    private readonly EmployerLegalEntitiesSqlDbHelper _employerLegalEntitiesSqlHelper = context.Get<EmployerLegalEntitiesSqlDbHelper>();
    private string _accountId;
    private string _expected;
    private RestResponse _apiResponse;

    [Given(@"user prepares request with Employer ID")]
    public void GivenUserPreparesRequestWithEmployerId()
        => (_accountId, _expected) = _employerLegalEntitiesSqlHelper.GetEmployerAccountDetails();

    [When(@"the user sends (GET) request to (.*)")]
    public void WhenTheUserSendsGETRequestToVacanciesEmployeraccountlegalentities(Method method, string endpoint)
    {
        _restClient.CreateRestRequest(method, endpoint.Replace("{hashedAccountId}", _accountId), null);
    }

    [Then(@"a (OK) response is received")]
    public void ThenAOKResponseIsReceived(HttpStatusCode responseCode)
    {
        _apiResponse = _restClient.Execute(responseCode);
    }

    [Then(@"verify response body displays correct information")]
    public void ThenVerifyResponseBodyDisplaysCorrectInformation()
        => StringAssert.Contains(_expected, _apiResponse.Content);

}
