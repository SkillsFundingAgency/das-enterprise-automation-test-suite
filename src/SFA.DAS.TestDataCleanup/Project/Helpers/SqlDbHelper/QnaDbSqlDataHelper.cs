namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class QnaDbSqlDataHelper : ProjectSqlDbHelper
{
    public QnaDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.QnaDatabaseConnectionString) { }
}