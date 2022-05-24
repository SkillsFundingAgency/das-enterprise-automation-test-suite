using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class LoginDbSqlDataHelper : ProjectSqlDbHelper
    {
        public LoginDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.LoginDatabaseConnectionString) { }
    }
}
