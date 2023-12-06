using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Login.Service.Project.Helpers;

public class AssessorStubLoginSqlDataHelper : SqlDbHelper
{
    public AssessorStubLoginSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.AssessorDbConnectionString) { }

    internal List<string> GetSignInIds(List<string> emails)
    {
        var query = emails.Select(GetSqlQuery).ToList();

        var accountdetails = new List<string>();

        foreach (var userrefs in GetListOfMultipleData(query))
        {
            var userref = userrefs.ListOfArrayToList(0);

            var y = userref.IsNoDataFound() ? string.Empty : userref.FirstOrDefault();

            accountdetails.Add(y);
        }

        return accountdetails;
    }

    private static string GetSqlQuery(string email) => $"select SignInId from dbo.Contacts where email = '{email}'";
}
