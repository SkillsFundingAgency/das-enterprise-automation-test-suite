namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class LoginDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.LoginDatabaseConnectionString)
{
}