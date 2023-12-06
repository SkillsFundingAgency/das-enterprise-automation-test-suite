using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Login.Service.Project.Helpers;

internal class EasAccountsSqlDataHelper : SqlDbHelper
{
    public EasAccountsSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.AccountsDbConnectionString) { }

    internal List<(List<string> listoflegalEntities, string idOrUserRef)> GetAccountDetails(List<string> emails)
    {
        var query = emails.Select(x => GetSqlQuery(x)).ToList();

        var listoflegalEntities = new List<List<string>>();

        var accountdetails = new List<(List<string>, string)>();

        foreach (var legalEntities in GetListOfMultipleData(query))
        {
            var legalEntitieslist = legalEntities.ListOfArrayToList(0);

            var userref = legalEntities.ListOfArrayToList(1);

            var x = legalEntitieslist.IsNoDataFound() ? new List<string>() : legalEntitieslist;

            listoflegalEntities.Add(x);

            var y = userref.IsNoDataFound() ? string.Empty : userref.FirstOrDefault();

            accountdetails.Add((x, y));
        }

        return accountdetails;
    }

    private static string GetSqlQuery(string email) => $"SELECT ale.[name], u.Userref FROM employer_account.AccountLegalEntity ale JOIN employer_account.Membership m ON ale.AccountId = m.AccountId JOIN employer_account.[User] u ON m.UserId = u.id WHERE ale.deleted is null AND u.Email = '{email}' ORDER BY ale.Created ASC;";
}
