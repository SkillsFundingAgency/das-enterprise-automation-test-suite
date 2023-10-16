namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class AssessorDbSqlDataHelper : ProjectSqlDbHelper
{
    public AssessorDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.AssessorDbConnectionString) { }
}