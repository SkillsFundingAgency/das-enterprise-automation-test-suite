using System;
using SFA.DAS.ProvideFeedback.UITests.Project.Models;

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

    public void CreateApprenticeProviderFeedback(List<ProviderRating> ratings, string ukprn, string providerName)
    {
        var sql = $@"
        DELETE FROM ProviderStarsSummary WHERE Ukprn = {ukprn};
        DELETE FROM ProviderRatingSummary WHERE Ukprn = {ukprn};
        DELETE FROM ProviderAttribute WHERE ApprenticeFeedbackResultId IN (SELECT Id FROM ApprenticeFeedbackResult WHERE ApprenticeFeedbackTargetId IN (SELECT Id FROM ApprenticeFeedbackTarget WHERE Ukprn = {ukprn}));
        DELETE FROM ApprenticeFeedbackResult WHERE ApprenticeFeedbackTargetId IN (SELECT Id FROM ApprenticeFeedbackTarget WHERE Ukprn = {ukprn});
        DELETE FROM ApprenticeFeedbackTarget WHERE Ukprn = {ukprn};
        ";

        var apprenticeshipId = 1;
        var currentAcademicYearDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
        var previousAcademicYearDate = DateTime.UtcNow.AddYears(-1).ToString("yyyy-MM-dd");

        foreach (var rating in ratings)
        {
            var targetId = Guid.NewGuid();
            var resultId = Guid.NewGuid();
            var resultDate = rating.AcademicYear == "Previous" ? previousAcademicYearDate : currentAcademicYearDate;

            sql += $@"
            INSERT INTO [dbo].[ApprenticeFeedbackTarget]
            ([Id], [ApprenticeId], [ApprenticeshipId], [Status], [StartDate], [EndDate], [Ukprn], [ProviderName], [StandardUId], [LarsCode], [StandardName], [FeedbackEligibility], [EligibilityCalculationDate], [CreatedOn], [UpdatedOn], [Withdrawn], [IsTransfer], [DateTransferIdentified], [ApprenticeshipStatus])
            VALUES 
            ('{targetId}', 'B46EDA62-4621-4187-AA2B-A65280B41BDC', {apprenticeshipId}, 2, GETDATE(), DATEADD(year, 2, GETDATE()), {ukprn}, '{providerName}', 'ST0005_1.1', 119, NULL, 1, GETDATE(), GETDATE(), GETDATE(), 0, 0, NULL, 1);

            INSERT INTO [dbo].[ApprenticeFeedbackResult]
            ([Id],[ApprenticeFeedbackTargetId],[StandardUId],[DateTimeCompleted],[ProviderRating],[AllowContact])
            VALUES 
            ('{resultId}', '{targetId}', 'ST0418_1.0', '{resultDate}', '{rating.Rating}', 0);

            INSERT INTO [dbo].[ProviderAttribute]
            ([ApprenticeFeedbackResultId],[AttributeId],[AttributeValue])
            VALUES 
            ('{resultId}', 1, 1),
            ('{resultId}', 2, 1),
            ('{resultId}', 3, 1);
            ";

            apprenticeshipId++;
        }

        ExecuteSqlCommand(sql);
    }

    public void GenerateFeedbackSummaries()
    {
        var query = $"EXEC [dbo].[GenerateProviderAttributesSummary] 24, 5";
        ExecuteSqlCommand(query);

        query = $"EXEC [dbo].[GenerateProviderRatingAndStarsSummary] 24, 5";
        ExecuteSqlCommand(query);
    }
}
