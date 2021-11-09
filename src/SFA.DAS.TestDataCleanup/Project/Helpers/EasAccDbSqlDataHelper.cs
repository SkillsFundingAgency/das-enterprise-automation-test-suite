using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers
{
    public class EasAccDbSqlDataHelper : ProjectSqlDbHelper
    {
        public EasAccDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        internal List<string[]> GetAccountIds(int greaterThan, int lessThan)
        {
            return GetMultipleAccountData($"select Id from employer_account.Account where id > {greaterThan} and id < {lessThan} order by id desc");
        }

        internal List<string[]> GetAccountHashedIds(List<string> accountIdToDelete)
        {
            return GetMultipleAccountData($"select HashedId from employer_account.Account where id in ({string.Join(",", accountIdToDelete)})");
        }

        private List<string[]> GetMultipleAccountData(string sqlQuery)
        {
            var id = GetMultipleData(sqlQuery, 1);

            if (IsNoDataFound(id)) id[0][0] = "0";

            return id;
        }

    }
}
