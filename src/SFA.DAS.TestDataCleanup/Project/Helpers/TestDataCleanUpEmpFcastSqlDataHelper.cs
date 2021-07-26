using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpEmpFcastSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpEmpFcastSqlDataHelper(DbConfig dbConfig) : base(dbConfig.FcastDbConnectionString) { }

        public async Task<(List<string>, List<string>)> CleanUpEmpFcastTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return await CleanUpTestData(() => GetEmpFcastAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEmpFcastTestData(x));
        }

        internal async Task CleanUpEmpFcastTestData(List<string> accountIdToDelete)
        {
            await CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasFcastTestDataCleanUp");
        }

        private List<string> GetEmpFcastAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select EmployerAccountId from dbo.LevyDeclaration where EmployerAccountId > {greaterThan} and EmployerAccountId < {lessThan} and EmployerAccountId not in ({string.Join(",", easaccountidsnottodelete)}) order by EmployerAccountId desc");
        }
    }
}
