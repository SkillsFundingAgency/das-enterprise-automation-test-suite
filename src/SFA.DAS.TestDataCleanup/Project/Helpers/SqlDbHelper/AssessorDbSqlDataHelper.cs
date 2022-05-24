using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class AssessorDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => string.Empty;

        public AssessorDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }
    }
}
