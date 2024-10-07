using System;
using SFA.DAS.ProvideFeedback.UITests.Project.Models;

namespace SFA.DAS.ProvideFeedback.UITests.Project.Helpers;

public class ApprenticeFeedbackSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.ApprenticeFeedbackDbConnectionString)
{
    private long _apprenticeshipId = 0;

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

    public void ClearProviderFeedback(string ukprn)
    {
        var sql =
            $"delete from ProviderStarsSummary where Ukprn = {ukprn};" +
            $"delete from ProviderRatingSummary where Ukprn = {ukprn}; " +
            $"delete from ProviderAttribute where ApprenticeFeedbackResultId in (select Id from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select Id from ApprenticeFeedbackTarget where Ukprn = {ukprn}))" +
            $"delete from ApprenticeFeedbackResult where ApprenticeFeedbackTargetId in (select Id from ApprenticeFeedbackTarget where Ukprn = {ukprn})" +
            $"delete from ApprenticeFeedbackTarget where Ukprn = {ukprn}";

        ExecuteSqlCommand(sql);
    }

    public void CreateProviderFeedback(string ukprn, ProviderRating rating)
    {
        var targetId = Guid.NewGuid();
        var resultId = Guid.NewGuid();
        var apprenticeshipId = _apprenticeshipId++;

        var sql = $"INSERT INTO [dbo].[ApprenticeFeedbackTarget]([Id], [ApprenticeId], [ApprenticeshipId], [Status], [StartDate], [EndDate], [Ukprn], [ProviderName], [StandardUId], [LarsCode], [StandardName], [FeedbackEligibility], [EligibilityCalculationDate], [CreatedOn], [UpdatedOn], [Withdrawn], [IsTransfer], [DateTransferIdentified], [ApprenticeshipStatus])" +
                  $"VALUES ('{targetId}', 'B46EDA62-4621-4187-AA2B-A65280B41BDC', {apprenticeshipId}, 2, GETDATE(), DATEADD(year, 2, GETDATE()), {ukprn}, 'MERCEDES-BENZ CARS UK LIMITED', 'ST0005_1.1', 119, NULL, 1, GETDATE(), GETDATE(), GETDATE(), 0, 0, NULL, 1);";

        ExecuteSqlCommand(sql);

        var resultDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
        if (rating.AcademicYear == "Previous")
        {
            resultDate = DateTime.UtcNow.AddYears(-1).ToString("yyyy-MM-dd");
        }

        sql = $"INSERT INTO [dbo].[ApprenticeFeedbackResult] ([Id],[ApprenticeFeedbackTargetId],[StandardUId],[DateTimeCompleted],[ProviderRating],[AllowContact])" +
              $"VALUES ('{resultId}' ,'{targetId}' ,'ST0418_1.0' ,'{resultDate}' ,'{rating.Rating}' ,0)";
        ExecuteSqlCommand(sql);

        ExecuteSqlCommand($"INSERT INTO [dbo].[ProviderAttribute]([ApprenticeFeedbackResultId],[AttributeId],[AttributeValue]) VALUES ('{resultId}',1,1)");
        ExecuteSqlCommand($"INSERT INTO [dbo].[ProviderAttribute]([ApprenticeFeedbackResultId],[AttributeId],[AttributeValue]) VALUES ('{resultId}',2,1)");
        ExecuteSqlCommand($"INSERT INTO [dbo].[ProviderAttribute]([ApprenticeFeedbackResultId],[AttributeId],[AttributeValue]) VALUES ('{resultId}',3,1)");
    }


    public void GenerateFeedbackSummaries()
    {
        var query = $"EXEC [dbo].[GenerateProviderAttributesSummary] 24, 5";
        ExecuteSqlCommand(query);

        query = $"EXEC [dbo].[GenerateProviderRatingAndStarsSummary] 24, 5";
        ExecuteSqlCommand(query);
    }
}
