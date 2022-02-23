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
        }

        [Then(@"call to DC api is not made")]
        public void ThenCallToDCApiIsNotMade()
        {
        }

        [Then(@"an employment check request to HMRC is created using the Nino provided")]
        public void ThenAnEmploymentCheckRequestToHMRCIsCreatedUsingTheNinoProvided()
        {
        }

    }
}
