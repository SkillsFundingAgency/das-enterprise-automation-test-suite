using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Login.Service.Project.Helpers;

public class AssessorStubLoginSqlDataHelper : SqlDbHelper
{
    public AssessorStubLoginSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.AssessorDbConnectionString) { }

    internal List<(string signInId, string displayName)> GetSignInIds(List<string> emails)
    {
        static string func(List<string> x) => x.IsNoDataFound() ? string.Empty : x.FirstOrDefault();

        var query = emails.Select(GetSqlQuery).ToList();

        var accountdetails = new List<(string, string)>();

        foreach (var data in GetListOfMultipleData(query)) accountdetails.Add((func(data.ListOfArrayToList(0)), func(data.ListOfArrayToList(1))));

        return accountdetails;
    }

    private static string GetSqlQuery(string email) => $"select SignInId, DisplayName from dbo.Contacts where email = '{email}'";
}
