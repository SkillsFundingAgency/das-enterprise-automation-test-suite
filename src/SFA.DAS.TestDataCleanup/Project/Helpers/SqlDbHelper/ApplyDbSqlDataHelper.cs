using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class ApplyDbSqlDataHelper : ProjectSqlDbHelper
    {
        public ApplyDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApplyDatabaseConnectionString) { }
    }
}
