using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class CrsDbSqlDataHelper : ProjectSqlDbHelper
    {
        public CrsDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.CRSDbConnectionString) { }
    }
}