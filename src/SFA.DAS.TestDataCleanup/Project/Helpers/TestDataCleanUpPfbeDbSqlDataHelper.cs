using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class TestDataCleanUpPfbeDbSqlDataHelper : ProjectSqlDbHelper
    {
        public TestDataCleanUpPfbeDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ProviderFeedbackDbConnectionString) { }

        public (List<string>, List<string>) CleanUpPfbeTestData(int greaterThan, int lessThan, List<string> easaccountids)
        {
            return CleanUpTestData(() => GetPfbeAccountids(greaterThan, lessThan, easaccountids), (x) => CleanUpPfbeTestData(x));
        }

        internal int CleanUpPfbeTestData(List<string> accountIdToDelete)
        {
            return CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id int)", "EasPfbeTestDataCleanUp");
        }

        private List<string> GetPfbeAccountids(int greaterThan, int lessThan, List<string> easaccountids)
        {
            return GetAccountids($"select AccountId from dbo.EmployerEmailDetails where AccountId > {greaterThan} and AccountId < {lessThan} and AccountId not in ({string.Join(",", easaccountids)}) order by AccountId desc");
        }
    }
}
