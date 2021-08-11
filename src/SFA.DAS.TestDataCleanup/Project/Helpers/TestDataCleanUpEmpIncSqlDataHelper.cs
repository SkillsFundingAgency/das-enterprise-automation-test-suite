using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpEmpIncSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpEmpIncSqlDataHelper(DbConfig dbConfig) : base(dbConfig.IncentivesDbConnectionString) { }

        public (List<string>, List<string>) CleanUpEmpIncTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return CleanUpTestData(() => GetEmpIncAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEmpIncTestData(x));
        }

        internal int CleanUpEmpIncTestData(List<string> accountIdToDelete)
        {
            return CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EmpIncTestDataCleanUp");
        }

        private List<string> GetEmpIncAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select id from dbo.Accounts where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
