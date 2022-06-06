using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Login.Service.Project.Helpers
{
    internal class LegalEntitiesSqlDataHelper : SqlDbHelper
    {
        public LegalEntitiesSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        internal List<List<string>> GetAccountLegalEntities(List<string> emails)
        {
            var query = emails.Select(x => GetSqlQuery(x)).ToList();

            var listoflegalEntities = new List<List<string>>();

            foreach (var legalEntities in GetListOfMultipleData(query))
            {
                var legalEntitieslist = legalEntities.ListOfArrayToList(0);

                listoflegalEntities.Add(legalEntitieslist.IsNoDataFound() ? new List<string>() : legalEntitieslist);
            }

            return listoflegalEntities;
        }

        private static string GetSqlQuery(string email) => $"select [name] from employer_account.AccountLegalEntity where deleted is null and AccountId in (select AccountId from employer_account.Membership where UserId in ( select id from employer_account.[User] where Email = '{email}' )) order by Created asc;";
    }
}
