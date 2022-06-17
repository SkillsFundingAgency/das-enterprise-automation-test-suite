namespace SFA.DAS.ProvideFeedback.UITests.Project.Helpers;

public class ApprenticeFeedbackSqlHelper : SqlDbHelper
{
    public ApprenticeFeedbackSqlHelper(DbConfig config) : base(config.ApprenticeFeedbackDbConnectionString) { }

    public void ClearDownApprenticeFeedbackResult(string apprenticeshipid, string ukprn)
    {
        var query = $"CREATE TABLE #appfeedbacktargetid (id uniqueidentifier) " +
            $"select id into #appfeedbacktargetid from ApprenticeFeedbackTarget where ApprenticeId = '{apprenticeshipid}' and Ukprn = '{ukprn}' " +
            $"CREATE TABLE #appfeedbackresult (id uniqueidentifier) " +
            $"select id into #appfeedbackresult from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select id from #appfeedbacktargetid);" +
            $"delete from ProviderAttribute where ApprenticeFeedbackResultId in (select id from #appfeedbackresult);" +
            $"delete from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select id from #appfeedbacktargetid); ";

        ExecuteSqlCommand(query);
    }
}
