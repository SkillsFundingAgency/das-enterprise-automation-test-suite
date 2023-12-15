namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class ApplyDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.ApplyDatabaseConnectionString)
{
}