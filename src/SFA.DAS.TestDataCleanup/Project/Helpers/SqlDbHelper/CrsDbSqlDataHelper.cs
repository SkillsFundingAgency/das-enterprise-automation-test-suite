using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class CrsDbSqlDataHelper : ProjectSqlDbHelper
    {
        public CrsDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.CRSDbConnectionString) { }
    }
}
