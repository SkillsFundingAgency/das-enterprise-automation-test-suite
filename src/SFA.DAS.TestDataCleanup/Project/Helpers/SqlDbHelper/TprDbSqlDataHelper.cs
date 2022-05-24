using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TprDbSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => string.Empty;

        public TprDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.TPRDbConnectionString) { }
    }
}
