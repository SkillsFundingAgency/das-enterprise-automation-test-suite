using System;
using TechTalk.SpecFlow;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using System.Threading.Tasks;
using NUnit.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmploymentCheckE2ESteps
    {
        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;
        private readonly SetupScenarioTestData _setupScenarioTestData;
        private int _employmentCheckId;
        private TestData _testData;

        public EmploymentCheckE2ESteps(ScenarioContext context)
        {
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
            _setupScenarioTestData = new SetupScenarioTestData();
            _testData = new TestData();

        }

        [Given(@"employment check has been requested for an apprentice with '(.*)', '(.*)', '(.*)'")]
        public async Task GivenEmploymentCheckHasBeenRequestedForAnApprenticeWith(int scenarioId, DateTime minDate, DateTime maxDate)
        {
            _testData = _setupScenarioTestData.SetData(scenarioId);
            _employmentCheckId = await _employmentChecksSqlDbHelper.InsertData(_testData.ULN, _testData.AccountId, minDate, maxDate);
        }

        [When(@"apprentice employment check is triggered")]
        public void WhenApprenticeEmploymentCheckIsTriggered()
        {
            // Check EmploymentCheckHttpTrigger is running 
            // If it is not then start it
        }

        [When(@"data is enriched with results from DC and Accounts")]
        [Then(@"data is enriched with results from DC and Accounts")]
        public void ThenDataIsEnrichedWithResultsFromDCAndAccounts()
        {
            var enrichedData = _employmentChecksSqlDbHelper.GetEnrichmentData();

            TestContext.Out.WriteLine($"Post Enrichment, Nino value in the queue is: {enrichedData.nino} and PayeScheme: {enrichedData.payeScheme}");

            Assert.AreEqual(_testData.NationalInsuranceNumber, enrichedData.nino);
            Assert.AreEqual(_testData.PayeScheme, enrichedData.payeScheme);
        }

        [When(@"Nino is not found")]
        public void WhenNinoIsNotFound()
        {
            // Verified in step definition = (@"data is enriched with results from DC and Accounts")
        }

        [When(@"Paye/Scheme is not found")]
        public void WhenPayeSchemeIsNotFound()
        {
            // Verified in step definition = (@"data is enriched with results from DC and Accounts")
        }



        [When(@"Nino and Paye/Scheme are not found")]
        public void WhenNinoAndPayeSchemeAreNotFound()
        {
            // Verified in step definition = (@"data is enriched with results from DC and Accounts")
        }

        [Then(@"do not create an Employment Check request")]
        public void ThenDoNotCreateAnEmploymentCheckRequest()
        {
            int numOfRequests = _employmentChecksSqlDbHelper.GetNumberOfEmploymentCheckRequests();

            Assert.AreEqual(0, numOfRequests);
        }



        [Then(@"employment check database is updated with the result from HMRC '(.*)', '(.*)', '(.*)'")]
        public void ThenEmploymentCheckDatabaseIsUpdatedWithTheResult(bool? employed, string returnCode, string returnMessage)
        {
            var employmentCheckResults = _employmentChecksSqlDbHelper.GetEmploymentCheckResults();

            Assert.AreEqual(employed, employmentCheckResults.isEmployed);
            Assert.AreEqual(returnCode == "null" ? null : returnCode, employmentCheckResults.returnCode);
            Assert.AreEqual(returnMessage, employmentCheckResults.returnMessage);
        }

    }
}
