using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class LoginDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => string.Empty;

        public LoginDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.LoginDatabaseConnectionString) { }
    }
}
