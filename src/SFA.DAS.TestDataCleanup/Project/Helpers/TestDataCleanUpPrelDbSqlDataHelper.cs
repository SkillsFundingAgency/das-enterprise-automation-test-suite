using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpPrelDbSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpPrelDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PermissionsDbConnectionString) { }

        public async Task<(List<string>, List<string>)> CleanUpPrelTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return await CleanUpTestData(() => GetPrelAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpPrelTestData(x));
        }

        internal async Task CleanUpPrelTestData(List<string> accountIdToDelete)
        {
            await CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasPrelTestDataCleanUp");
        }

        private List<string> GetPrelAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select Id from dbo.Accounts where Id > {greaterThan} and id < {lessThan} and Id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
