namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class TprDbSqlDataHelper : ProjectSqlDbHelper
{
    public TprDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.TPRDbConnectionString) { }
}