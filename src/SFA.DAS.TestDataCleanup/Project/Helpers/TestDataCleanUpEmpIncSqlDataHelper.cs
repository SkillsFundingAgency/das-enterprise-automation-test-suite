using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpEmpIncSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpEmpIncSqlDataHelper(DbConfig dbConfig) : base(dbConfig.IncentivesDbConnectionString) { }

        public async Task<(List<string>, List<string>)> CleanUpEmpIncTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return await CleanUpTestData(() => GetEmpIncAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEmpIncTestData(x));
        }

        internal async Task CleanUpEmpIncTestData(List<string> accountIdToDelete)
        {
            await CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EmpIncTestDataCleanUp");
        }

        private List<string> GetEmpIncAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select id from dbo.Accounts where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
