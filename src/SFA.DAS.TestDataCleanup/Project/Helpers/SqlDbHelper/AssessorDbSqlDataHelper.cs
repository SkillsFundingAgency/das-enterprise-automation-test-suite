using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class AssessorDbSqlDataHelper : ProjectSqlDbHelper
    {
        public AssessorDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }
    }
}
