using System.Threading.Tasks;
using NUnit.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions;

[Binding]
internal class EmploymentCheckE2E_ManuallyInsertNino_Steps(ScenarioContext context)
{
    private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
    private string _checkType;
    private readonly Helper _helper = context.Get<Helper>();
    private TestData _testData = new();

    [Given(@"employment check has been requested for an apprentice with '([^']*)' and ULN '([^']*)'")]
    public void GivenEmploymentCheckHasBeenRequestedForAnApprenticeWithAndULN(int scenarioId, long Uln)
    {
        _testData = SetupScenarioTestData.SetData(scenarioId);
        
        _testData.ULN = Uln;
    }

    [Given(@"a NINO '([^']*)' has been manually inserted")]
    public async Task GivenANINOHasBeenManuallyInserted(string Nino)
    {
        _testData.NationalInsuranceNumber = Nino;
        _checkType = context.ScenarioInfo.Title[..10];

        _employmentChecksSqlDbHelper.InsertEmploymentCheckRecordWithNino(_testData.ULN, _testData.NationalInsuranceNumber, _testData.AccountId, _checkType);

        await _helper.EmploymentCheckOrchestrationHelper.StartEmploymentChecksOrchestrator();
    }

    [When(@"check is picked up for enrichment process")]
    public void WhenCheckIsPickedUpForEnrichmentProcess()
    {
        int? checkStatus = _employmentChecksSqlDbHelper.GetEmploymentCheckStatusWithCorrelationId();

        Assert.AreEqual(1, checkStatus, "EmploymentCheck was not been picked up for enrichment");
    }

    [Then(@"call to DC api is not made")]
    public void ThenCallToDCApiIsNotMade()
    {
        // Verify that there is only 1 record in [Cache].[DataCollectionsResponse] table that is manually inserted
        // Use the correlationId and Uln for the check

        int count = _employmentChecksSqlDbHelper.GetCountFromDataCollectionResponse(_testData.ULN);

        Assert.AreEqual(1, count, "Unexpected number of DataCollectionsResponse rows found!");
    }

    [Then(@"an employment check request to HMRC is created using the Nino provided")]
    public void ThenAnEmploymentCheckRequestToHMRCIsCreatedUsingTheNinoProvided()
    {
        var request = _employmentChecksSqlDbHelper.GetEmploymentCheckCacheRequestRows();

        Assert.AreEqual(1, request.Count, "Unexpected number of requests in [Cache].[EmploymentCheckCacheRequest] table");
        Assert.AreEqual(_testData.NationalInsuranceNumber, request[0][3].ToString(), "Unexpected NINO found in [Cache].[EmploymentCheckCacheRequest] table");
    }

}
