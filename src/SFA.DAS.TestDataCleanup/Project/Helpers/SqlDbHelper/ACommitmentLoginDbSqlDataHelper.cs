using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class ACommitmentLoginDbSqlDataHelper : ProjectSqlDbHelper
    {
        public ACommitmentLoginDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentLoginDbConnectionString) { }
    }
}