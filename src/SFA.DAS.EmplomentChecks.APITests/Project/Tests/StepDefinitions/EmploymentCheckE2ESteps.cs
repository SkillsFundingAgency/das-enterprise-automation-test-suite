using System;
using TechTalk.SpecFlow;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using System.Threading.Tasks;
using NUnit.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmploymentCheckE2ESteps
    {
        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;
        private readonly SetupScenarioTestData _setupScenarioTestData;
        private TestData _testData;
        private List<string> _payeSchemes = new List<string>();
        private readonly ScenarioContext _context;
        private readonly Helper _helper;

        public EmploymentCheckE2ESteps(ScenarioContext context)
        {
            _context = context;
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
            _setupScenarioTestData = new SetupScenarioTestData();
            _testData = new TestData();
            _helper = context.Get<Helper>();
        }

        [Given(@"employment check has been requested for an apprentice with '(.*)', '(.*)', '(.*)'")]
        public async Task GivenEmploymentCheckHasBeenRequestedForAnApprenticeWith(int scenarioId, DateTime minDate, DateTime maxDate)
        {
            _testData = _setupScenarioTestData.SetData(scenarioId);
            string checkType = _context.ScenarioInfo.Title.Substring(0, 10);

            await _employmentChecksSqlDbHelper.InsertData(checkType, _testData.ULN, _testData.AccountId, minDate, maxDate);
            await _helper.EmploymentCheckOrchestrationHelper.StartEmploymentChecksOrchestrator();
        }

        [Then(@"employment check record status is '([^']*)'")]
        [Given(@"employment check record status is '([^']*)'")]
        public void GivenEmploymentCheckRecordHasBeenPickedForProcessing(int expectedStatus)
        {
            int? completionStatus = _employmentChecksSqlDbHelper.getEmploymentCheckStatusWithId();

            Assert.AreEqual(expectedStatus, completionStatus, "Unexpected RequestCompletionStatus column value in [Business].[EmploymentCheck] table");
        }

        [Then(@"business outcome for the check is set to '([^']*)'")]
        public void ThenBusinessOutcomeForTheCheckIsSetTo(string errorType)
        {
            Assert.AreEqual(errorType, _employmentChecksSqlDbHelper.getErrorTypeFromEmploymentCheckTable(), "Unexpected Error Type found");
        }



        [When(@"apprentice employment check is triggered")]
        public void WhenApprenticeEmploymentCheckIsTriggered()
        {
            // Check EmploymentCheckHttpTrigger is running 
            // If it is not then start it
        }

        [When(@"multiple paye schemes are found on account")]
        [When(@"data is enriched with results from DC and Accounts")]
        [Then(@"data is enriched with results from DC and Accounts")]
        public void ThenDataIsEnrichedWithResultsFromDCAndAccounts()
        {
            static List<string> ToList(string value) => (!string.IsNullOrEmpty(value) && value.Contains(',')) ? value.Split(',').ToList() : new List<string> { value };

            var (nino, payeScheme) = _employmentChecksSqlDbHelper.GetEnrichmentData();

            TestContext.Out.WriteLine($"Post Enrichment, Nino value in the queue is: {nino} and PayeScheme: {payeScheme}");

            Assert.Multiple(() => 
            {
                Assert.AreEqual(_testData.NationalInsuranceNumber, nino, "Unexpected National Insurance Number returned");

                CollectionAssert.AreEquivalent(ToList(_testData.PayeScheme), ToList(payeScheme), "Unexpected Paye Scheme(s) returned");
            });
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

            Assert.AreEqual(0, numOfRequests, $"Expected number of Employment Checks to be 0 but was {numOfRequests}");
        }

        [Then(@"employment check database is updated with the result from HMRC '(.*)', '(.*)', '(.*)'")]
        public void ThenEmploymentCheckDatabaseIsUpdatedWithTheResult(bool? employed, string returnCode, string returnMessage)
        {
            var employmentCheckResults = _employmentChecksSqlDbHelper.GetEmploymentCheckResults();

            returnCode = returnCode == "null" ? null : returnCode;
  
            Assert.AreEqual(employed, employmentCheckResults.isEmployed, "Unexpected Employement Status returned.");
            Assert.AreEqual(returnCode, employmentCheckResults.returnCode, "Unexpected Return Code is returned." );
            Assert.AreEqual(returnMessage, employmentCheckResults.returnMessage, "Unexpected Return Message returned.");
        }

        [When(@"an employment check request is created for each unique Nino and paye scheme combination")]
        [Then(@"an employment check request is created for each unique Nino and paye scheme combination")]
        public void ThenAnEmploymentCheckRequestIsCreatedForEachUniqueNinoAndPayeSchemeCombination()
        {
            _payeSchemes = _testData.PayeScheme.Split(',').ToList();

            var requests = _employmentChecksSqlDbHelper.getRelatedsPayeFromEmploymentCheckCacheRequestRows();

            Assert.AreEqual(_payeSchemes.Count, requests.Count, $"Incorrect number of EmploymentCheckCacheRequest returned.");

            for (int i = 0; i < _payeSchemes.Count; i++)
            {
                Assert.AreEqual(String.Concat(_payeSchemes[i].Where(c => !Char.IsWhiteSpace(c))), requests[i][0], "Incorrect PayeScheme displayed in EmploymentCheckCacheRequest table");
            }
        }
    }
}