namespace SFA.DAS.SupportConsole.UITests.Project.Helpers.SqlHelpers;

public class AccountsSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.AccountsDbConnectionString)
{
    public (string name, DateTime createdDate, string hashedId, string email, string fName, string lName, string payeref) GetAccountDetails(string publicHashedId)
    {
        var query = $"select Top 1 a.Name,a.CreatedDate,a.HashedId,u.Email,u.FirstName,u.LastName,ah.PayeRef from employer_account.Account a " +
            $"JOIN employer_account.Membership m ON m.AccountId = a.id " +
            $"JOIN employer_account.[User] u ON u.id = m.UserId " +
            $"JOIN employer_account.AccountHistory ah ON a.Id = ah.AccountId " +
            $"where a.PublicHashedId = '{publicHashedId}' and ah.RemovedDate is null " +
            "Order by NEWID()";

        var result = GetData(query);

        return (result[0], DateTime.Parse(result[1]), result[2], result[3], result[4], result[5], result[6]);
    }
}
