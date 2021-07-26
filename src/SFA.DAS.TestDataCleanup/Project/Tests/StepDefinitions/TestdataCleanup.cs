using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions
{
    [Binding]
    public class TestdataCleanup
    {
        private readonly DbConfig _dbConfig;
        private readonly TestDataCleanUpReport _testDataCleanUpReport;

        public TestdataCleanup(ScenarioContext context)
        {
            _dbConfig = context.Get<DbConfig>();
            _testDataCleanUpReport = new TestDataCleanUpReport(context.Get<ObjectContext>());
        }

        [Then(@"the test data are cleaned up for email (.*)")]
        public async Task ThenTheTestDataAreCleanedUpForEmail(string email) => await CleanUpTestData(email);

        [Then(@"the test data are cleaned up")]
        public async Task ThenTheTestDataAreCleanedUp() => await CleanUpTestData("dele.odusanya@lynkmiigroup.com");

        [Then(@"the test data are cleaned up in comt dbs for accounts between '(\d*)' and '(\d*)'")]
        public async void ThenTheTestDataAreCleanedUpInComtDbsForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await GetCleanUpHelper(greaterThan, lessThan).CleanUpComtTestData();

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
        }


        [Then(@"the test data are cleaned up in other dbs for accounts between '(\d*)' and '(\d*)'")]
        public async Task ThenTheTestDataAreCleanedUpForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var helper = GetCleanUpHelper(greaterThan, lessThan);

            var (comtusersdeleted, comtuserswithconstraints) = await helper.CleanUpComtTestData();

            var (prelusersdeleted, preluserswithconstraints) = await helper.CleanUpPrelTestData();

            comtusersdeleted.AddRange(prelusersdeleted);
            comtuserswithconstraints.AddRange(preluserswithconstraints);

            var (pfbeusersdeleted, pfbeuserswithconstraints) = await helper.CleanUpPfbeTestData();

            prelusersdeleted.AddRange(pfbeusersdeleted);
            preluserswithconstraints.AddRange(pfbeuserswithconstraints);

            var (fcastusersdeleted, fcastuserswithconstraints) = await helper.CleanUpEmpFcastTestData();

            fcastusersdeleted.AddRange(prelusersdeleted);
            fcastuserswithconstraints.AddRange(preluserswithconstraints);

            var (empfinusersdeleted, empfinuserswithconstraints) = await helper.CleanUpEmpFinTestData();

            empfinusersdeleted.AddRange(fcastusersdeleted);
            empfinuserswithconstraints.AddRange(fcastuserswithconstraints);

            _testDataCleanUpReport.TestCleanUpReport(empfinusersdeleted, empfinuserswithconstraints);
        }

        private async Task CleanUpTestData(string email)
        {
            var (usersdeleted, userswithconstraints) = await new TestDataCleanUpSqlDataHelper(_dbConfig).CleanUpTestData(email);

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        private TestdataCleanUpStepsHelper GetCleanUpHelper(int greaterThan, int lessThan)
        {
            var easAccountIds = new TestDataCleanUpEasAccDbSqlDataHelper(_dbConfig).GetAccountIds(greaterThan, lessThan);

            var easAccountsNotToDelete =  easAccountIds.ListOfArrayToList(0);

            return new TestdataCleanUpStepsHelper(_dbConfig, greaterThan, lessThan, easAccountsNotToDelete);
        }
    }
}
