namespace SFA.DAS.Registration.UITests.Project.Helpers.SqlDbHelpers;

public class TransferMatchingSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.TMDbConnectionString)
{
    public int GetNumberTransferPledgeApplicationsByApplicationStatus(string employerAccountId, string applicationStatusId)
    {
        Dictionary<string, string> sqlParameters = new()
        {
            { "@EmployerAccountId", employerAccountId },
            { "@ApplicationStatus" , applicationStatusId }
        };

        string query = @"select COUNT(app.Id) from [dbo].[Application] app
                                inner join [dbo].[Pledge] pledge
                                on pledge.Id = app.PledgeId
                                where app.Status = @ApplicationStatus
                                and pledge.EmployerAccountId = @EmployerAccountId;";

        return (int)GetDataAsObject(query, sqlParameters);
    }

    public List<int> GetTransferPledgeApplicationsByApplicationStatus(string employerAccountId, string applicationStatusId)
    {       
        string query = @$"
        SELECT app.Id 
        FROM [dbo].[Application] app
        INNER JOIN [dbo].[Pledge] pledge
            ON pledge.Id = app.PledgeId
        WHERE app.Status = {applicationStatusId}
            AND pledge.EmployerAccountId = {employerAccountId};";

        List<string[]> rawResults = GetMultipleData(query);
        List<int> applicationIds = [];

        foreach (var row in rawResults)
        {
            if (row.Length > 0 && int.TryParse(row[0], out int id))
            {
                applicationIds.Add(id);
            }
        }

        return applicationIds;
    }
}
