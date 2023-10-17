namespace SFA.DAS.ProvideFeedback.UITests.Project.Helpers;

public class ApprenticeFeedbackSqlHelper : SqlDbHelper
{
    public ApprenticeFeedbackSqlHelper(ObjectContext objectContext, DbConfig config) : base(objectContext, config.ApprenticeFeedbackDbConnectionString) { }

    public void ClearDownApprenticeFeedbackResult(string apprenticeshipid, string ukprn)
    {
        var query = $"select id into #appfeedbacktargetid from ApprenticeFeedbackTarget where ApprenticeId = '{apprenticeshipid}' and Ukprn = '{ukprn}' " +
            $"select id into #appfeedbackresult from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select id from #appfeedbacktargetid);" +
            $"delete from ProviderAttribute where ApprenticeFeedbackResultId in (select id from #appfeedbackresult);" +
            $"delete from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select id from #appfeedbacktargetid); ";

        ExecuteSqlCommand(query);
    }
}
