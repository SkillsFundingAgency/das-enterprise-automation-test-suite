namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class AssessorDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.AssessorDbConnectionString)
{
}