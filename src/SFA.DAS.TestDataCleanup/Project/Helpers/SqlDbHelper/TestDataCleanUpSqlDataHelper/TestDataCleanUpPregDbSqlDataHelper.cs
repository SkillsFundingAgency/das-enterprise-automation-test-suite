using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public class TestDataCleanUpPregDbSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
    {
        public override string SqlFileName => "EasPregTestDataCleanUp";

        public TestDataCleanUpPregDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PregDbConnectionString) { }

        internal int CleanUpPregDbTestData(string email) => CleanUpUsingEmail(email);
    }
}
