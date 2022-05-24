using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class CrsDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => string.Empty;

        public CrsDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.CRSDbConnectionString) { }
    }
}
