using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class RoatpDbSqlDataHelper : ProjectSqlDbHelper
    {
        public RoatpDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.RoatpDatabaseConnectionString) { }
    }
}