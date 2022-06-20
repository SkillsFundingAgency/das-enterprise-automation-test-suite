namespace SFA.DAS.SupportConsole.UITests.Project.SqlHelpers;

public class CommitmentsSqlDataHelper : SqlDbHelper
{
    public CommitmentsSqlDataHelper(DbConfig dBConfig) : base(dBConfig.CommitmentsDbConnectionString) { }

    public void UpdateApprenticeshipStatus(string uln, int status)
    {
        string stopDate, pauseDate, completionDate;

        if (uln.Equals(null))
            throw new Exception("ULN is not set");

        if (status < 1 || status > 4)
            throw new Exception("Invalid Status!");


        pauseDate = (status == 2) ? DateTime.Now.ToString("yyyy-MM-dd") : null;
        stopDate = (status == 3) ? DateTime.Now.ToString("yyyy-MM-dd") : null;
        completionDate = (status == 4) ? DateTime.Now.ToString("yyyy-MM-dd") : null;

        string sqlQueryToSetDataLockSuccessStatus = $@"UPDATE Apprenticeship
                                                            SET PaymentStatus = {status.ToString()}, StopDate = '{stopDate}', PauseDate = '{pauseDate}', CompletionDate = '{completionDate}'
                                                            WHERE ULN = '{uln}'";

        ExecuteSqlCommand(sqlQueryToSetDataLockSuccessStatus);
    }

    public List<(string uln, string fname, string lname, string cohortRef, string publichashedId)> GetCommtDetails(string publicHashedId)
    {
        var query = $"Select ULN, FirstName, LastName, Reference, PublicHashedId from  " +
            $"(select Top 1 app.ULN, app.FirstName, app.LastName, c.Reference, a.PublicHashedId from Accounts a " +
            $"JOIN Commitment c on c.EmployerAccountId = a.Id " +
            $"JOIN Apprenticeship app on app.CommitmentId = c.Id " +
            $"where a.PublicHashedId = '{publicHashedId}' ORDER BY NEWID()) temp" +
            $"UNION " +
            $"Select ULN, FirstName, LastName, Reference, PublicHashedId from " +
            $"(select Top 1 app.ULN, app.FirstName, app.LastName, c.Reference, a.PublicHashedId from Commitment c " +
            $"join Accounts a on c.EmployerAccountId = a.Id " +
            $"JOIN Apprenticeship app on app.CommitmentId = c.Id " +
            $"where a.PublicHashedId != '{publicHashedId}' ORDER BY NEWID()) temp";

        var result =  GetMultipleData(query);

        List<(string, string, string, string, string)> resultList = new();

        foreach (var item in result) resultList.Add((item[0], item[1], item[2], item[3], item[4]));

        return resultList;

    }
}
