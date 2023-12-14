using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions;

[Binding]
internal class InputInterface_CheckIsRegisteredSteps(ScenarioContext context)
{
    private readonly Outer_EmploymentCheckApiClient _restClient = context.GetRestClient<Outer_EmploymentCheckApiClient>();
    private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();

    [Given(@"Employer Incentives service are validing employment status of apprentice")]
    public void GivenEmployerIncentivesServiceAreValidingEmploymentStatusOfApprentice()
    {
    }

    [When(@"an employment check '([^']*)' request is successfully made to '([^']*)' with payload '([^']*)'")]
    public void WhenAnEmploymentCheckRequestIsSuccessfullyMadeToWithPayload(Method method, string endpoint, string payload)
    {
        _restClient.CreateRestRequest(method, endpoint, payload);
    }

    [Then(@"a '([^']*)' response is received")]
    public void ThenAResponseIsReceived(HttpStatusCode code)
    {
        _ = _restClient.Execute(code);
    }

    [Then(@"the check is '([^']*)' in Employment Check business table")]
    public void ThenTheCheckIsInEmploymentCheckBusinessTable(bool registered)
    {
        string checkType = context.ScenarioInfo.Title[..10];
        int count = _employmentChecksSqlDbHelper.GetCheckFromEmploymentCheckTable(checkType);

        if (registered) 
            Assert.AreEqual(1, count, $"Unexpected number of records for test {checkType} in [Business].[EmploymentCheck] table");
        else
            Assert.AreEqual(0, count, $"Unexpected number of records for test {checkType} in [Business].[EmploymentCheck] table");
    }
}
