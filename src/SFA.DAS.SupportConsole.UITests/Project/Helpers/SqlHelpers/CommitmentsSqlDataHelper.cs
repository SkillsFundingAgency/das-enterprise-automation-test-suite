namespace SFA.DAS.SupportConsole.UITests.Project.Helpers.SqlHelpers;

public class CommitmentsSqlDataHelper : SqlDbHelper
{
    public CommitmentsSqlDataHelper(ObjectContext objectContext, DbConfig dBConfig) : base(objectContext, dBConfig.CommitmentsDbConnectionString) { }

   

    public Dictionary<int, (string uln, string fname, string lname, string cohortRef)> GetCommtDetails(string publicHashedId)
    {
        var query = $"Select ULN, FirstName, LastName, Reference, indentifier from ({GetCohortDetails(publicHashedId)}) temp UNION " +
            $"Select ULN, FirstName, LastName, Reference, indentifier from ({GetCohortNotAssociatedToAccount(publicHashedId)}) temp UNION " +
            $"Select ULN, FirstName, LastName, Reference, indentifier from ({GetCohortDetailsWithPendingChanges(publicHashedId)}) temp UNION " +
            $"Select ULN, FirstName, LastName, Reference, indentifier from ({GetCohortDetailsWithTrainingProviderHistory(publicHashedId)}) temp" ;

        var result = GetMultipleData(query);

        Dictionary<int, (string, string, string, string)> resultList = new();

        foreach (var item in result) resultList.Add(int.Parse(item[4]), (item[0], item[1], item[2], item[3]));

        return resultList;

    }

    private static string GetCohortDetails(string publicHashedId)
    {
        return $@"select Top 1 app.ULN, app.FirstName, app.LastName, c.Reference, 0 as indentifier from Accounts a JOIN Commitment c on c.EmployerAccountId = a.Id JOIN Apprenticeship app on app.CommitmentId = c.Id where a.PublicHashedId = '{publicHashedId}' and app.uln is not null ORDER BY NEWID()";
    }

    private static string GetCohortNotAssociatedToAccount(string publicHashedId)
    {
        return $@"select Top 1 app.ULN, app.FirstName, app.LastName, c.Reference, 1 as indentifier from Commitment c join Accounts a on c.EmployerAccountId = a.Id JOIN Apprenticeship app on app.CommitmentId = c.Id where a.PublicHashedId != '{publicHashedId}' and app.uln is not null ORDER BY NEWID()";
    }

    private static string GetCohortDetailsWithPendingChanges(string publicHashedId)
    {
        return @$"SELECT TOP (1) A.ULN, A.FirstName, A.LastName, C.Reference, 2 as indentifier
                          FROM[dbo].[ApprenticeshipUpdate] AU
                          Inner join Apprenticeship A on AU.ApprenticeshipId = A.Id
                          Inner join Commitment C on C.Id = A.CommitmentId
                          Inner join AccountLegalEntities ALE on ALE.Id = C.AccountLegalEntityId
                          Inner join Accounts AC on AC.Id = ALE.AccountId
                          Where AC.PublicHashedId = '{publicHashedId}'
                          AND AU.Status = 0
                          Order by C.Id desc";
    }

    private static string GetCohortDetailsWithTrainingProviderHistory(string publicHashedId)
    {
        return @$"Select top 1 A.ULN, A.FirstName, A.LastName, C.Reference, 3 as indentifier
						  From Apprenticeship A
						  Inner Join Commitment C on A.CommitmentId = C.Id
						  Inner join AccountLegalEntities  ALE on ALE.Id = C.AccountLegalEntityId
                          Inner join Accounts AC on AC.Id = ALE.AccountId
                          Inner join ChangeOfPartyRequest Cpr on Cpr.NewApprenticeshipId = A.Id
                          Where AC.PublicHashedId ='{publicHashedId}'
						  AND A.ContinuationOfId is not null
                          AND Cpr.ChangeOfPartyType = 1 
						  Order by C.Id desc";
    }
}
