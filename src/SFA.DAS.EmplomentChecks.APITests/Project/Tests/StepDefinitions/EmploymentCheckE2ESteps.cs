using System;
using TechTalk.SpecFlow;
using SFA.DAS.API.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using System.Threading.Tasks;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmploymentCheckE2ESteps
    {
        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;
        public EmploymentCheckE2ESteps(ScenarioContext context)
        {
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
        }

        [Given(@"employment check has been requested for an apprentice with '(.*)', '(.*)', '(.*)', '(.*)'")]
        public async Task GivenEmploymentCheckHasBeenRequestedForAnApprenticeWith(string uln, string accountId, DateTime minDate, DateTime maxDate)
        {
            await _employmentChecksSqlDbHelper.InsertData(uln, accountId, minDate, maxDate);
        }

        [When(@"apprentice employment check is triggered")]
        public void WhenApprenticeEmploymentCheckIsTriggered()
        {
        }

        [Then(@"data is enriched with results from DC and Accounts")]
        public void ThenDataIsEnrichedWithResultsFromDCAndAccounts()
        {
        }

        [Then(@"HMRC check is performed for the apprentice")]
        public void ThenHMRCCheckIsPerformedForTheApprentice()
        {
        }

        [Then(@"employment check database is updated with the result '(.*)'")]
        public void ThenEmploymentCheckDatabaseIsUpdatedWithTheResult(string employed)
        {
        }

    }
}
