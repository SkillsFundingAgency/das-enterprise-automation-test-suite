namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class LoginDbSqlDataHelper : ProjectSqlDbHelper
{
    public LoginDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.LoginDatabaseConnectionString) { }
}