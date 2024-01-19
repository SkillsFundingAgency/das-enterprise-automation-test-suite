namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class CrsDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.CRSDbConnectionString)
{
}