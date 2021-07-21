using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpPsrepDbSqlDataHelper : ProjectSqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public TestDataCleanUpPsrepDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PublicSectorReportingConnectionString) => _dbConfig = dbConfig;

        internal async Task CleanUpPsrTestData(List<string> accountIdToDelete)
        {
            var easaccounthashedids = new TestDataCleanUpEasAccDbSqlDataHelper(_dbConfig).GetAccountHashedIds(accountIdToDelete);

            var insertquery = easaccounthashedids.Select(x => $"Insert into #accounthashedids values ('{x[0]}')").ToList();

            var sqlQuery = $"create table #accounthashedids (id nvarchar(255));{string.Join(";", insertquery)};" + GetSql("EasPsrepTestDataCleanUp");

            await TryExecuteSqlCommand(sqlQuery);
        }
    }
}
