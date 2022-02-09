using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.StepsHelper
{
    public class TestdataCleanupStepsHelper : TestdataCleanupStepsHelperBase
    {
        public TestdataCleanupStepsHelper(ScenarioContext context) : base(context) { }

        public void CleanUpAllDbTestData(string email) => ReportTestDataCleanUp(() => new TestDataCleanUpAllDbSqlDataHelper(_dbConfig).CleanUpAllDbTestData(email));

        public void CleanUpComtTestData(int greaterThan, int lessThan) => ReportTestDataCleanUp(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpComtTestData());

        public void CleanUpPrelTestData(int greaterThan, int lessThan) => ReportTestDataCleanUp(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpPrelTestData());

        public void CleanUpPfbeTestData(int greaterThan, int lessThan) => ReportTestDataCleanUp(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpPfbeTestData());

        public void CleanUpEmpFcastTestData(int greaterThan, int lessThan) => ReportTestDataCleanUp(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpFcastTestData());

        public void CleanUpEmpFinTestData(int greaterThan, int lessThan) => ReportTestDataCleanUp(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpFinTestData());

        public void CleanUpRsvrTestData(int greaterThan, int lessThan) => ReportTestDataCleanUp(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpRsvrTestData());

        public void CleanUpEmpIncTestData(int greaterThan, int lessThan) => ReportTestDataCleanUp(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpEmpIncTestData());

        public void CleanUpEasLtmTestData(int greaterThan, int lessThan) => ReportTestDataCleanUp(() => GetCleanUpHelper(greaterThan, lessThan).CleanUpEasLtmTestData());
    }
}
