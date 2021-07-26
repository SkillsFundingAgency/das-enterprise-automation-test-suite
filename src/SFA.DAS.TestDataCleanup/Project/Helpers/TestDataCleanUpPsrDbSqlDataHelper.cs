using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpPsrDbSqlDataHelper : ProjectSqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public TestDataCleanUpPsrDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PublicSectorReportingConnectionString) => _dbConfig = dbConfig;

        internal int CleanUpPsrTestData(List<string> accountIdToDelete)
        {
            var easaccounthashedids = new TestDataCleanUpEasAccDbSqlDataHelper(_dbConfig).GetAccountHashedIds(accountIdToDelete);

            return CleanUpTestData(easaccounthashedids.ListOfArrayToList(0), (x) => $"Insert into #accounthashedids values ('{x}')", "create table #accounthashedids (id nvarchar(255))", "EasPsrTestDataCleanUp");
        }
    }
}
