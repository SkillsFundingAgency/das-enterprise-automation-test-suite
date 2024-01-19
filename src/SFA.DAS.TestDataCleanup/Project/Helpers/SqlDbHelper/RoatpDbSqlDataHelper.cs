namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class RoatpDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.RoatpDatabaseConnectionString)
{
}