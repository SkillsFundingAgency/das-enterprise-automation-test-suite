using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public class TestDataCleanupAComtSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
    {
        private readonly DbConfig _dbConfig;

        public override string SqlFileName => "EasAComtTestDataCleanUp";

        public TestDataCleanupAComtSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentDbConnectionString) => _dbConfig = dbConfig;

        internal int CleanUpAComtTestData(List<string> accountIdToDelete)
        {
            var apprenticeIds = new TestDataCleanupComtSqlDataHelper(_dbConfig).GetApprenticeIds(accountIdToDelete);

            if (apprenticeIds.IsNoDataFound()) return 0;

            return CleanUpTestData(apprenticeIds.ListOfArrayToList(0), (x) => $"Insert into #commitmentsapprenticeshipid values ({x})", "create table #commitmentsapprenticeshipid (id bigint)");
        }
    }
}
