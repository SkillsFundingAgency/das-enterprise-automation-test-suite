namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class QnaDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.QnaDatabaseConnectionString)
{
}