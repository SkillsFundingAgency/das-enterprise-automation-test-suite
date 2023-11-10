namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class TprDbSqlDataHelper : ProjectSqlDbHelper
{
    public TprDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.TPRDbConnectionString) { }
}