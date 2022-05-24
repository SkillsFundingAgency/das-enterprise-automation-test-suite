using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class EmploymentCheckDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => string.Empty;

        public EmploymentCheckDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.EmploymentCheckDbConnectionString) { }
    }
}
