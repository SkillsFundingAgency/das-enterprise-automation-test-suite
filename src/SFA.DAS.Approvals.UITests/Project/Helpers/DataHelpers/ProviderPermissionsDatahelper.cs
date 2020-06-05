using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class ProviderPermissionsDatahelper
    {
        private readonly string _connectionString;

        public ProviderPermissionsDatahelper(ProviderPermissionsConfig config) => _connectionString = config.PermissionsDbConnectionString;

        public int GetAccountIdOfAProvider(string ukprn)
        {
            string sqlQueryToGetAccountId = $"SELECT AccountId from [AccountProviders] WHERE ProviderUkprn = {Convert.ToInt64(ukprn)}";

            List<object[]> responseData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(sqlQueryToGetAccountId, _connectionString);

            if (responseData.Count == 0)
                return 0;
            else
                return Convert.ToInt32(responseData[0][0]);
        }

        public void RemoveAllPermissionsOfAProvider(int accountId)
        {
            string sqlQueryToDeleteAllPermissions = $"DELETE aple FROM AccountProviderLegalEntities aple INNER JOIN AccountProviders ap ON ap.Id = aple.AccountProviderId WHERE ap.AccountId = {accountId};DELETE FROM AccountProviders WHERE AccountId = {accountId}";

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, sqlQueryToDeleteAllPermissions);
        }
    }
}
