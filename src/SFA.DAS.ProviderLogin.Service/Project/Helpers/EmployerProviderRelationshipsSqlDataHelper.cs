using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers;

internal class EmployerProviderRelationshipsSqlDataHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.PermissionsDbConnectionString)
{
    public List<ProviderDetails> GetProviderName(List<int> ukprn)
    {
        var query = ukprn.Select(GetSqlQuery).ToList();

        var multiresult = GetListOfMultipleData(query).ToList();

        var dfeProviderDetailsList = new FrameworkList<ProviderDetails>();

        foreach (var result in multiresult)
        {
            dfeProviderDetailsList.Add(new ProviderDetails($"{result[0][0]}", $"{result[0][1]}"));
        }

        return dfeProviderDetailsList;
    }

    private static string GetSqlQuery(int ukprn) => $"select Ukprn, [Name] from  Providers WHERE Ukprn = {ukprn}";
}
