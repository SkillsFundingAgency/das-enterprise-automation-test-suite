using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class ApplyDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => string.Empty;

        public ApplyDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApplyDatabaseConnectionString) { }
    }
}
