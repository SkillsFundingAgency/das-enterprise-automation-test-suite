using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanupComtSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanupComtSqlDataHelper(DbConfig dbConfig) : base(dbConfig.CommitmentsDbConnectionString) { }

        public async Task<(List<string>, List<string>)> CleanUpComtTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return await CleanUpTestData(() => GetComtAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpComtTestData(x));
        }

        internal async Task CleanUpComtTestData(List<string> accountIdToDelete)
        {
            await CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasComtTestDataCleanUp");
        }

        private List<string> GetComtAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select EmployerAccountId from dbo.Commitment where EmployerAccountId > {greaterThan} and EmployerAccountId < {lessThan} and EmployerAccountId not in ({string.Join(",", easaccountidsnottodelete)}) order by EmployerAccountId desc");
        }
    }
}
