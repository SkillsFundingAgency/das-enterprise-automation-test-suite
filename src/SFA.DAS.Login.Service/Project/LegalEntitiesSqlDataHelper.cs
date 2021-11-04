using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Login.Service
{
    internal class LegalEntitiesSqlDataHelper : SqlDbHelper
    {
        public LegalEntitiesSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        internal List<string> GetAccountLegalEntities(string email)
        {
            var legalEntities = GetMultipleData($"select [name] from employer_account.AccountLegalEntity where AccountId in (select AccountId from employer_account.Membership where UserId in ( select id from employer_account.[User] where Email = '{email}' )) order by Created asc", 1).ListOfArrayToList(0);

            return IsNoDataFound(legalEntities) ? new List<string>() : legalEntities;
        }
    }
}
