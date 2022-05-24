using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanUpEasLtmcSqlDataHelper : TestDataCleanupSqlDataHelper
    {
        public override string SqlFileName => "EasLtmTestDataCleanUp";

        public TestDataCleanUpEasLtmcSqlDataHelper(DbConfig dbConfig) : base(dbConfig.TMDbConnectionString) { }

        public (List<string>, List<string>) CleanUpEasLtmTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return CleanUpTestData(() => GetEasLtmAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEasLtmTestData(x));
        }

        internal int CleanUpEasLtmTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);

        private List<string> GetEasLtmAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select id from dbo.EmployerAccount where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
