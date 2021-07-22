using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpPsrDbSqlDataHelper : ProjectSqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public TestDataCleanUpPsrDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PublicSectorReportingConnectionString) => _dbConfig = dbConfig;

        internal async Task CleanUpPsrTestData(List<string> accountIdToDelete)
        {
            var easaccounthashedids = new TestDataCleanUpEasAccDbSqlDataHelper(_dbConfig).GetAccountHashedIds(accountIdToDelete);

            await CleanUpTestData(easaccounthashedids.ListOfArrayToList(0), (x) => $"Insert into #accounthashedids values ('{x}')", "create table #accounthashedids (id nvarchar(255))", "EasPsrTestDataCleanUp");
        }
    }
}
