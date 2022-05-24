using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class AssessorDbSqlDataHelper : ProjectSqlDbHelper
    {
        public AssessorDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }
    }
}