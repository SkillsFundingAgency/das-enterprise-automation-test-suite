using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanUpPrelDbSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpPrelDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PermissionsDbConnectionString) { }

        public (List<string>, List<string>) CleanUpPrelTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return CleanUpTestData(() => GetPrelAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpPrelTestData(x));
        }

        internal int CleanUpPrelTestData(List<string> accountIdToDelete)
        {
            return CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)", "EasPrelTestDataCleanUp");
        }

        private List<string> GetPrelAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select Id from dbo.Accounts where Id > {greaterThan} and id < {lessThan} and Id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
