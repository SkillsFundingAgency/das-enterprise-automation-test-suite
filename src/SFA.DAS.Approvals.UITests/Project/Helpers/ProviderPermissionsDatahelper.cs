using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using SFA.DAS.CosmosDb;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class ProviderPermissionsDatahelper
    {
        private readonly SqlDatabaseConnectionHelper _sqlDatabase;
        private readonly ProviderPermissionsConfig _config;

        private readonly string _connectionString;

        public ProviderPermissionsDatahelper(ProviderPermissionsConfig config, SqlDatabaseConnectionHelper sqlDatabase)
        {
            _config = config;
            _sqlDatabase = sqlDatabase;
            _connectionString = config.PermissionsDbConnectionString;
        }

        public int GetAccountIdOfAProvider()
        {
            string sqlQueryToGetAccountId = $"SELECT AccountId from [AccountProviders] WHERE ProviderUkprn = {Convert.ToInt64(_config.AP_ProviderUkprn)}";

            List<object[]> responseData = _sqlDatabase.ReadDataFromDataBase(sqlQueryToGetAccountId, _connectionString);

            if (responseData.Count == 0)
                return 0;
            else
                return Convert.ToInt32(responseData[0][0]);
        }

        public void RemoveAllPermissionsOfAProvider(int accountId)
        {
            string sqlQueryToDeleteAllPermissions = $"DELETE aple FROM AccountProviderLegalEntities aple INNER JOIN AccountProviders ap ON ap.Id = aple.AccountProviderId WHERE ap.AccountId = {accountId};DELETE FROM AccountProviders WHERE AccountId = {accountId}";

            _sqlDatabase.ExecuteSqlCommand(_connectionString, sqlQueryToDeleteAllPermissions);
        }
    }
}
