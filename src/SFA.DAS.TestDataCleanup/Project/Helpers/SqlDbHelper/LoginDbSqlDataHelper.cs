using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class LoginDbSqlDataHelper : ProjectSqlDbHelper
    {
        public LoginDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.LoginDatabaseConnectionString) { }
    }
}