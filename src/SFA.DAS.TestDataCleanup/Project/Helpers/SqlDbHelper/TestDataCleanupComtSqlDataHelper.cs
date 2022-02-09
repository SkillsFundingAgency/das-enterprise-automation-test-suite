using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanupComtSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanupComtSqlDataHelper(DbConfig dbConfig) : base(dbConfig.CommitmentsDbConnectionString) { }

        public (List<string>, List<string>) CleanUpComtTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return CleanUpTestData(() => GetComtAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpComtTestData(x));
        }

        internal int CleanUpComtTestData(List<string> accountIdToDelete)
        {
            return CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasComtTestDataCleanUp");
        }

        private List<string> GetComtAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select id from dbo.Accounts where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
