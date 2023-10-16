namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class ApplyDbSqlDataHelper : ProjectSqlDbHelper
{
    public ApplyDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.ApplyDatabaseConnectionString) { }
}