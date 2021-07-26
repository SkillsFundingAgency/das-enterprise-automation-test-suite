using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpRsvrSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpRsvrSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ReservationsDbConnectionString) { }

        public async Task<(List<string>, List<string>)> CleanUpRsvrTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return await CleanUpTestData(() => GetRsvrAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpRsvrTestData(x));
        }

        internal async Task CleanUpRsvrTestData(List<string> accountIdToDelete)
        {
            await CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasRsrvTestDataCleanUp");
        }

        private List<string> GetRsvrAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select id from dbo.Account where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
