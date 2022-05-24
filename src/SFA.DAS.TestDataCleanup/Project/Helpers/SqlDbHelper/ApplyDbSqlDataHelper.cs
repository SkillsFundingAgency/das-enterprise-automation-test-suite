using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class ApplyDbSqlDataHelper : ProjectSqlDbHelper
    {
        public ApplyDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApplyDatabaseConnectionString) { }
    }
}