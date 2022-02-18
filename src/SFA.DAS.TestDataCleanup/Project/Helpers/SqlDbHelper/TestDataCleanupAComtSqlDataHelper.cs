using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanupAComtSqlDataHelper : ProjectSqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public TestDataCleanupAComtSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentDbConnectionString) => _dbConfig = dbConfig;

        internal int CleanUpAComtTestData(List<string> accountIdToDelete)
        {
            var apprenticeIds = new EasComtDbSqlDataHelper(_dbConfig).GetApprenticeIds(accountIdToDelete);

            if (IsNoDataFound(apprenticeIds)) return 0;

            return CleanUpTestData(apprenticeIds.ListOfArrayToList(0), (x) => $"Insert into #commitmentsapprenticeshipid values ({x})", "create table #commitmentsapprenticeshipid (id bigint)", "EasAComtTestDataCleanUp");
        }
    }
}
