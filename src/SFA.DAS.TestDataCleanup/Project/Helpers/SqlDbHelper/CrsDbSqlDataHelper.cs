namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class CrsDbSqlDataHelper : ProjectSqlDbHelper
{
    public CrsDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.CRSDbConnectionString) { }
}