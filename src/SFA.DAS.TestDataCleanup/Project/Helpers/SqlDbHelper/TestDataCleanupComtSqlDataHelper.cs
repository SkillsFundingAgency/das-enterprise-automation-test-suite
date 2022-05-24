using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class TestDataCleanupComtSqlDataHelper : ProjectSqlDbHelper
    {
        public override string SqlFileName => "EasComtTestDataCleanUp";

        public TestDataCleanupComtSqlDataHelper(DbConfig dbConfig) : base(dbConfig.CommitmentsDbConnectionString) { }

        internal List<string[]> GetApprenticeIds(List<string> accountIdToDelete)
        {
            return GetMultipleData($"select a.id from Apprenticeship a Join Commitment c on c.id = a.CommitmentId and c.EmployerAccountId in ({string.Join(",", accountIdToDelete)})");
        }

        public (List<string>, List<string>) CleanUpComtTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return CleanUpTestData(() => GetComtAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpComtTestData(x));
        }

        internal int CleanUpComtTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);
        
        private List<string> GetComtAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
        {
            return GetAccountids($"select id from dbo.Accounts where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
        }
    }
}
