using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Login.Service.Project.Helpers;

public class AssessorStubLoginSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.AssessorDbConnectionString)
{
    internal List<(string signInId, string displayName)> GetSignInIds(List<string> emails)
    {
        var query = emails.Select(GetSqlQuery).ToList();

        var accountdetails = new List<(string, string)>();

        foreach (var data in GetListOfMultipleData(query)) accountdetails.Add((Func(data.ListOfArrayToList(0)), Func(data.ListOfArrayToList(1))));

        return accountdetails;
    }

    private static string GetSqlQuery(string email) => $"select SignInId, DisplayName from dbo.Contacts where email = '{email}'";
}

public class CandidateAccountStubLoginSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.CanAccDbConnectionString)
{
    internal List<(string signInId, string firstName, string lastName, string mobilePhone)> GetSignInIds(List<string> emails)
    {
        var query = emails.Select(GetSqlQuery).ToList();

        var accountdetails = new List<(string, string, string, string)>();

        foreach (var data in GetListOfMultipleData(query)) accountdetails.Add((Func(data.ListOfArrayToList(0)), Func(data.ListOfArrayToList(1)), Func(data.ListOfArrayToList(2)), Func(data.ListOfArrayToList(3))));

        return accountdetails;
    }

    private static string GetSqlQuery(string email) => $"select GovUkIdentifier, FirstName, LastName, PhoneNumber from dbo.Candidate where email = '{email}'";
}
