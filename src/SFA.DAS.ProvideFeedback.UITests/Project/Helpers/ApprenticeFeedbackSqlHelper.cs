namespace SFA.DAS.ProvideFeedback.UITests.Project.Helpers;

public class ApprenticeFeedbackSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.ApprenticeFeedbackDbConnectionString)
{
    public void RemoveAllFeedback(string apprenticeshipId)
    {
        var query = $"select id into #appfeedbacktargetid from ApprenticeFeedbackTarget where ApprenticeId = '{apprenticeshipId}' " +
            $"select id into #appfeedbackresult from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select id from #appfeedbacktargetid);" +
            $"delete from ProviderAttribute where ApprenticeFeedbackResultId in (select id from #appfeedbackresult);" +
            $"delete from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select id from #appfeedbacktargetid); ";

        ExecuteSqlCommand(query);
    }

    public void ResetFeedbackEligibility(string apprenticeshipId)
    {
        var query = $"select id into #appfeedbacktargetid from ApprenticeFeedbackTarget where ApprenticeId = '{apprenticeshipId}' " +
                    $"update [ApprenticeFeedbackTarget] set [Status]=2, [FeedbackEligibility]=1 where Id in (select id from #appfeedbacktargetid);";

        ExecuteSqlCommand(query);
    }
}
