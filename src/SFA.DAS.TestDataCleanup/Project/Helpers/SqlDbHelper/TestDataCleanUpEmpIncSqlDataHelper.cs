using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanUpEasLtmcSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpEasLtmcSqlDataHelper(DbConfig dbConfig) : base(dbConfig.TMDbConnectionString) { }

        public (List<string>, List<string>) CleanUpEasLtmTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return CleanUpTestData(() => GetEasLtmAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEasLtmTestData(x));
        }

        internal int CleanUpEasLtmTestData(List<string> accountIdToDelete)
        {
            return CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasLtmTestDataCleanUp");
        }

        private List<string> GetEasLtmAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select EmployerAccountId from dbo.Pledge where EmployerAccountId > {greaterThan} and EmployerAccountId < {lessThan} and EmployerAccountId not in ({string.Join(",", easaccountidsnottodelete)}) order by EmployerAccountId desc");
        }
    }


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
