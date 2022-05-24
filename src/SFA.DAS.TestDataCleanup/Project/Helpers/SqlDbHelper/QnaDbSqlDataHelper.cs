using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class QnaDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => string.Empty;

        public QnaDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.QnaDatabaseConnectionString) { }
    }
}
