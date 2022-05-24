using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class RoatpDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => string.Empty;

        public RoatpDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.RoatpDatabaseConnectionString) { }
    }
}
