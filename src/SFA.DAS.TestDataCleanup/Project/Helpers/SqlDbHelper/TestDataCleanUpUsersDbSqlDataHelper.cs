using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanUpUsersDbSqlDataHelper : TestDataCleanupSqlDataHelper
    {
        public override string SqlFileName => "EasUsersTestDataCleanUp";

        public TestDataCleanUpUsersDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.UsersDbConnectionString) { }

        internal int CleanUpUsersDbTestData(string email) => CleanUpUsingEmail(email);
    }
}
