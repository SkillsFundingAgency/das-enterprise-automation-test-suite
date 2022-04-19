using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;
using System;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class ProviderCreateVacancySqlDbHelper : SqlDbHelper
    {
        public ProviderCreateVacancySqlDbHelper(DbConfig config) : base(config.AccountsDbConnectionString) { }

        public int GetNoOfLegalEntity(string hashedid) => Convert.ToInt32(GetDataAsObject($"SELECT count(*) FROM employer_account.AccountLegalEntity al JOIN employer_account.Account a ON a.id = al.AccountId WHERE a.HashedId = '{hashedid}'"));
    }
}
