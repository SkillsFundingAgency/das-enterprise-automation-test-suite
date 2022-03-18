using NUnit.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using TechTalk.SpecFlow;
namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    internal class EmploymentCheckE2E_ManuallyInsertNino_Steps
    {
        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;
        private readonly SetupScenarioTestData _setupScenarioTestData;
        private TestData _testData;
        private ScenarioContext _context;
        private string _checkType;

        public EmploymentCheckE2E_ManuallyInsertNino_Steps(ScenarioContext context)
        {
            _context = context;
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
            _setupScenarioTestData = new SetupScenarioTestData();
            _testData = new TestData();
        }

        [Given(@"employment check has been requested for an apprentice with '([^']*)' and ULN '([^']*)'")]
        public void GivenEmploymentCheckHasBeenRequestedForAnApprenticeWithAndULN(int scenarioId, long Uln)
        {
            _testData = _setupScenarioTestData.SetData(scenarioId);
            
            _testData.ULN = Uln;
        }

        [Given(@"a NINO '([^']*)' has been manually inserted")]
        public void GivenANINOHasBeenManuallyInserted(string Nino)
        {
            _testData.NationalInsuranceNumber = Nino;
            _checkType = _context.ScenarioInfo.Title.Substring(0, 10);

            _employmentChecksSqlDbHelper.InsertEmploymentCheckRecordwithNino(_testData.ULN, _testData.NationalInsuranceNumber, _testData.AccountId, _checkType);
        }

        [When(@"check is picked up for enrichment process")]
        public void WhenCheckIsPickedUpForEnrichmentProcess()
        {
            int? checkStatus = _employmentChecksSqlDbHelper.getEmploymentCheckStatusWithCorrelationId();

            Assert.AreEqual(1, checkStatus, "EmploymentCheck was not been picked up for enrichment");
        }

        [Then(@"call to DC api is not made")]
        public void ThenCallToDCApiIsNotMade()
        {
            // Verify that there is only 1 record in [Cache].[DataCollectionsResponse] table that is manually inserted
            // Use the correlationId and Uln for the check

            int count = _employmentChecksSqlDbHelper.getCountFromDataCollectionResponse(_testData.ULN);

            Assert.AreEqual(1, count, "Unexpected number of DataCollectionsResponse rows found!");
        }

        [Then(@"an employment check request to HMRC is created using the Nino provided")]
        public void ThenAnEmploymentCheckRequestToHMRCIsCreatedUsingTheNinoProvided()
        {
            var request = _employmentChecksSqlDbHelper.getEmploymentCheckCacheRequestRows();

            Assert.AreEqual(1, request.Count, "Unexpected number of requests in [Cache].[EmploymentCheckCacheRequest] table");
            Assert.AreEqual(_testData.NationalInsuranceNumber, request[0][3].ToString(), "Unexpected NINO found in [Cache].[EmploymentCheckCacheRequest] table");
        }

    }
}
