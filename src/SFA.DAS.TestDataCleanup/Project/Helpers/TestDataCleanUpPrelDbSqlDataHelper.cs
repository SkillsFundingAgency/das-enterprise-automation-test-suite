using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpPrelDbSqlDataHelper : TestDataCleanUpSqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public TestDataCleanUpPrelDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PermissionsDbConnectionString) => _dbConfig = dbConfig;

        public async Task<(List<string>, List<string>)> CleanUpPrelTestData(int greaterThan, int lessThan)
        {
            var easaccountids = new TestDataCleanUpEasAccDbSqlDataHelper(_dbConfig).GetAccountIds(greaterThan, lessThan);

            return await CleanUpPrelTestData(greaterThan, lessThan, easaccountids.ListOfArrayToList(0));
        }

        internal async Task CleanUpPrelTestData(List<string> accountIdToDelete)
        {
            var insertquery = accountIdToDelete.Select(x => $"Insert into #accountids values ({x})").ToList();

            var sqlQuery = $"create table #accountids (id bigint);{string.Join(";", insertquery)};" + GetSql("EasPrelTestDataCleanUp");

            await TryExecuteSqlCommand(sqlQuery);
        }

        private async Task<(List<string>, List<string>)> CleanUpPrelTestData(int greaterThan, int lessThan, List<string> easaccountids)
        {
            return await CleanUpPrelTestData(() => GetPrelAccountids(greaterThan, lessThan, easaccountids), (x) => CleanUpPrelTestData(x));
        }

        private List<string> GetPrelAccountids(int greaterThan, int lessThan, List<string> easaccountids)
        {
            var prelaccountids = GetMultipleData($"select Id from dbo.Accounts where Id > {greaterThan} and id < {lessThan} and Id not in ({string.Join(",", easaccountids)}) order by id desc", 1);

            return prelaccountids.ListOfArrayToList(0);
        }
    }
}
