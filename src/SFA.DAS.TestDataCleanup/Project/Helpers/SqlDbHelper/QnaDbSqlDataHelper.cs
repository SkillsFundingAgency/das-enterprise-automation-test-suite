using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class QnaDbSqlDataHelper : ProjectSqlDbHelper
    {
        public QnaDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.QnaDatabaseConnectionString) { }
    }
}
