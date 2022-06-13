namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class EmploymentCheckDbSqlDataHelper : ProjectSqlDbHelper
{
    public EmploymentCheckDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.EmploymentCheckDbConnectionString) { }
}