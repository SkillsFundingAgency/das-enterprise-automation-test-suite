using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
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

        [Then(@"the test data are cleaned up in comt db for accounts between '(\d*)' and '(\d*)'")]
        public async void ThenTheTestDataAreCleanedUpInComtDbsForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await GetCleanUpHelper(greaterThan, lessThan).CleanUpComtTestData();

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        [Then(@"the test data are cleaned up in prel db for accounts between '(\d*)' and '(\d*)'")]
        public async void ThenTheTestDataAreCleanedUpInPrelDbForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await GetCleanUpHelper(greaterThan, lessThan).CleanUpPrelTestData();

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        [Then(@"the test data are cleaned up in pfbe db for accounts between '(\d*)' and '(\d*)'")]
        public async void ThenTheTestDataAreCleanedUpInPfbeDbForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await GetCleanUpHelper(greaterThan, lessThan).CleanUpPfbeTestData();

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        [Then(@"the test data are cleaned up in fcast db for accounts between '(\d*)' and '(\d*)'")]
        public async void ThenTheTestDataAreCleanedUpInFcastDbForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpFcastTestData();

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        [Then(@"the test data are cleaned up in fin db for accounts between '(\d*)' and '(\d*)'")]
        public async void ThenTheTestDataAreCleanedUpInFinDbForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpFinTestData();

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        [Then(@"the test data are cleaned up in rsvr db for accounts between '(\d*)' and '(\d*)'")]
        public async void ThenTheTestDataAreCleanedUpInRsvrDbForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await GetCleanUpHelper(greaterThan, lessThan).CleanUpRsvrTestData();

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        [Then(@"the test data are cleaned up in emp inc db for accounts between '(\d*)' and '(\d*)'")]
        public async void ThenTheTestDataAreCleanedUpInEmpIncDbForAccountsBetweenAnd(int greaterThan, int lessThan)
        {
            var (usersdeleted, userswithconstraints) = await GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpIncTestData();

            _testDataCleanUpReport.TestCleanUpReport(usersdeleted, userswithconstraints);
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
