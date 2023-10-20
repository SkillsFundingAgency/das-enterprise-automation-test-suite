namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class EmploymentCheckDbSqlDataHelper : ProjectSqlDbHelper
{
    public EmploymentCheckDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.EmploymentCheckDbConnectionString) { }
}