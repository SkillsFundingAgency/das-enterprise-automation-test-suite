using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanUpEmpFinSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpEmpFinSqlDataHelper(DbConfig dbConfig) : base(dbConfig.FinanceDbConnectionString) { }

        public (List<string>, List<string>) CleanUpEmpFinTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return CleanUpTestData(() => GetEmpFinAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEmpFinTestData(x));
        }

        internal int CleanUpEmpFinTestData(List<string> accountIdToDelete)
        {
            return CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasFinTestDataCleanUp");
        }

        private List<string> GetEmpFinAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select id from employer_financial.Account where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
