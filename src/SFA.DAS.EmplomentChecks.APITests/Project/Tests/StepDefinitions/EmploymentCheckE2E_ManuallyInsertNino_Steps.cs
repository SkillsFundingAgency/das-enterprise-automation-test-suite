using NUnit.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using TechTalk.SpecFlow;
namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    internal class EmploymentCheckE2E_ManuallyInsertNino_Steps
    {
        private ScenarioContext _context;
        private long _uln;
        private string _nino, _checkType;

        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;

        public EmploymentCheckE2E_ManuallyInsertNino_Steps(ScenarioContext context)
        {
            _context = context;
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
        }

        [Given(@"employment check has been requested for an apprentice with ULN '([^']*)'")]
        public void GivenEmploymentCheckHasBeenRequestedForAnApprenticeWithULN(long Uln)
        {
            _uln = Uln;
        }

        [Given(@"a NINO '([^']*)' has been manually inserted")]
        public void GivenANINOHasBeenManuallyInserted(string Nino)
        {
            _nino = Nino;
            _checkType = _context.ScenarioInfo.Title.Substring(0, 10);

            _employmentChecksSqlDbHelper.InsertEmploymentCheckRecordwithNino(_uln, _nino, _checkType);
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

            int count = _employmentChecksSqlDbHelper.getCountFromDataCollectionResponse(_uln);

            Assert.AreEqual(1, count, "Unexpected number of DataCollectionsResponse rows found!");
        }

        [Then(@"an employment check request to HMRC is created using the Nino provided")]
        public void ThenAnEmploymentCheckRequestToHMRCIsCreatedUsingTheNinoProvided()
        {
            var request = _employmentChecksSqlDbHelper.getEmploymentCheckCacheRequestRows();

            Assert.AreEqual(1, request.Count);
            Assert.AreEqual(_nino, request[0][3].ToString());
        }

    }
}
