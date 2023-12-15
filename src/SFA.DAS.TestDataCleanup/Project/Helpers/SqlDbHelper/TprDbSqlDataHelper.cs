namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class TprDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.TPRDbConnectionString)
{
}