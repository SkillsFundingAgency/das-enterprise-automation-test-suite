using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.TestDataCleanup.Project.Helpers.StepsHelper;

namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions
{
    [Binding]
    public class TestdataCleanupWithAccountId
    {
        private readonly TestdataCleanupStepsHelper _testDataCleanUpStepsHelper;

        public TestdataCleanupWithAccountId(ScenarioContext context) => _testDataCleanUpStepsHelper = new TestdataCleanupStepsHelper(context);

        [Then(@"the test data are cleaned up in comt db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInComtDbs(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpComtTestData(greaterThan, lessThan);

        [Then(@"the test data are cleaned up in prel db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInPrelDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpPrelTestData(greaterThan, lessThan);

        [Then(@"the test data are cleaned up in pfbe db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInPfbeDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpPfbeTestData(greaterThan, lessThan);

        [Then(@"the test data are cleaned up in fcast db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInFcastDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpEmpFcastTestData(greaterThan, lessThan);

        [Then(@"the test data are cleaned up in fin db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInFinDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpEmpFinTestData(greaterThan, lessThan);
        
        [Then(@"the test data are cleaned up in rsvr db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInRsvrDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpRsvrTestData(greaterThan, lessThan);
        
        [Then(@"the test data are cleaned up in emp inc db for accounts between '(\d*)' and '(\d*)'")]
        public void TestDataAreCleanedUpInEmpIncDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpEmpIncTestData(greaterThan, lessThan);

    }
}
