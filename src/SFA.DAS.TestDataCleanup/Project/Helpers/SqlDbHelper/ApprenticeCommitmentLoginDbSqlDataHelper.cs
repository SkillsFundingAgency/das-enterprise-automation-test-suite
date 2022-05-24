using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class ApprenticeCommitmentLoginDbSqlDataHelper : ProjectSqlDbHelper
    {
        public ApprenticeCommitmentLoginDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentLoginDbConnectionString) { }
    }
}
