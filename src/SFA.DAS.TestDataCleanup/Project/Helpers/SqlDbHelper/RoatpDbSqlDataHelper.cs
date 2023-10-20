namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class RoatpDbSqlDataHelper : ProjectSqlDbHelper
{
    public RoatpDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.RoatpDatabaseConnectionString) { }
}