namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class EmploymentCheckDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.EmploymentCheckDbConnectionString)
{
}