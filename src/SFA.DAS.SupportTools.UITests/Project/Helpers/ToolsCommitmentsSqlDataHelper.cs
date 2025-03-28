namespace SFA.DAS.SupportTools.UITests.Project.Helpers;

public class ToolsCommitmentsSqlDataHelper(ObjectContext objectContext, DbConfig dBConfig) : SqlDbHelper(objectContext, dBConfig.CommitmentsDbConnectionString)
{
    public void UpdateApprenticeshipStatus(string uln, int status)
    {
        if (uln.Equals(null))
        {
            throw new Exception("ULN is not set");
        }

        if (status is < 1 or > 4)
        {
            throw new Exception("Invalid Status!");
        }

        var pauseDate = status == 2 ? DateTime.Now.ToString("yyyy-MM-dd") : null;
        var stopDate = status == 3 ? DateTime.Now.ToString("yyyy-MM-dd") : null;
        var completionDate = status == 4 ? DateTime.Now.ToString("yyyy-MM-dd") : null;

        var sqlQueryToSetDataLockSuccessStatus = $"UPDATE Apprenticeship " +
                                                 $"SET PaymentStatus = {status}, StopDate = '{stopDate}', PauseDate = '{pauseDate}', CompletionDate = '{completionDate}' " +
                                                 $"WHERE ULN = '{uln}'";

        ExecuteSqlCommand(sqlQueryToSetDataLockSuccessStatus);
    }
}
