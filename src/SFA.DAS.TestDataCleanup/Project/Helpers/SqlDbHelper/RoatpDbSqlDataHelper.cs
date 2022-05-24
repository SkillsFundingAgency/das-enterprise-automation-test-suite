using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class RoatpDbSqlDataHelper : ProjectSqlDbHelper
    {
        public RoatpDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.RoatpDatabaseConnectionString) { }
    }
}
