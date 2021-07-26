using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpEmpFcastSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpEmpFcastSqlDataHelper(DbConfig dbConfig) : base(dbConfig.FcastDbConnectionString) { }

        public (List<string>, List<string>) CleanUpEmpFcastTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return CleanUpTestData(() => GetEmpFcastAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEmpFcastTestData(x));
        }

        internal int CleanUpEmpFcastTestData(List<string> accountIdToDelete)
        {
            return CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasFcastTestDataCleanUp");
        }

        private List<string> GetEmpFcastAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select EmployerAccountId from dbo.LevyDeclaration where EmployerAccountId > {greaterThan} and EmployerAccountId < {lessThan} and EmployerAccountId not in ({string.Join(",", easaccountidsnottodelete)}) order by EmployerAccountId desc");
        }
    }
}
