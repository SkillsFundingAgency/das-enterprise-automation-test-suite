using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanUpPregDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => "EasPregTestDataCleanUp";
        public TestDataCleanUpPregDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PregDbConnectionString) { }

        internal int CleanUpPregDbTestData(string email) => CleanUpUsingEmail(email);
    }
}
