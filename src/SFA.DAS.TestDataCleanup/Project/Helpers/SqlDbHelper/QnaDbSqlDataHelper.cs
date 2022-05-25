using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class QnaDbSqlDataHelper : ProjectSqlDbHelper
    {
        public QnaDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.QnaDatabaseConnectionString) { }
    }
}