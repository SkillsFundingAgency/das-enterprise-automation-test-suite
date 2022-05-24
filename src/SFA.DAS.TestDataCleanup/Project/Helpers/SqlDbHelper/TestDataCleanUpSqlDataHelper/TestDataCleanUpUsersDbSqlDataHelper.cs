using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public class TestDataCleanUpUsersDbSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
    {
        public override string SqlFileName => "EasUsersTestDataCleanUp";

        public TestDataCleanUpUsersDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.UsersDbConnectionString) { }

        internal int CleanUpUsersDbTestData(string email) => CleanUpUsingEmail(email);
    }
}
