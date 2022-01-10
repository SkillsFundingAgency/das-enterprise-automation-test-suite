using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions
{
    [Binding]
    public class TestdataCleanupWithAccountId : TestdataCleanupBaseSteps
    {
        public TestdataCleanupWithAccountId(ScenarioContext context) : base(context) { }

        [Then(@"the test data are cleaned up in comt db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInComtDbs(int greaterThan, int lessThan) => CleanUpTestData(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpComtTestData());
        
        [Then(@"the test data are cleaned up in prel db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInPrelDb(int greaterThan, int lessThan) => CleanUpTestData(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpPrelTestData());

        [Then(@"the test data are cleaned up in pfbe db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInPfbeDb(int greaterThan, int lessThan) => CleanUpTestData(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpPfbeTestData());

        [Then(@"the test data are cleaned up in fcast db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInFcastDb(int greaterThan, int lessThan) => CleanUpTestData(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpFcastTestData());

        [Then(@"the test data are cleaned up in fin db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInFinDb(int greaterThan, int lessThan) => CleanUpTestData(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpFinTestData());
        
        [Then(@"the test data are cleaned up in rsvr db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInRsvrDb(int greaterThan, int lessThan) => CleanUpTestData(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpRsvrTestData());
        
        [Then(@"the test data are cleaned up in emp inc db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInEmpIncDb(int greaterThan, int lessThan) => CleanUpTestData(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpIncTestData());

        private TestdataCleanupWithAccountIdStepsHelper GetCleanUpHelper(int greaterThan, int lessThan)
        {
            var easAccountIds = new EasAccDbSqlDataHelper(_dbConfig).GetAccountIds(greaterThan, lessThan);

            var easAccountsNotToDelete =  easAccountIds.ListOfArrayToList(0);

            return new TestdataCleanupWithAccountIdStepsHelper(_dbConfig, greaterThan, lessThan, easAccountsNotToDelete);
        }
    }
}
