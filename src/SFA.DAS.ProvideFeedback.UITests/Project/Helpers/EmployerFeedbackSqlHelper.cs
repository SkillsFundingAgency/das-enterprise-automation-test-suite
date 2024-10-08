using SFA.DAS.ProvideFeedback.UITests.Project.Models;
using System;

namespace SFA.DAS.ProvideFeedback.UITests.Project.Helpers;


public class EmployerFeedbackSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.EmployerFeedbackDbConnectionString)
{
    public (string uniqueSurveycode, string ukprn) GetTestData(string email)
    {
        var data = GetData($"select TOP (1) [UniqueSurveyCode] , [Ukprn] FROM [dbo].[vw_EmployerSurveyHistoryComplete] where EmailAddress = '{email}'");

        return (data[0], data[1]);
    }

    public void ClearDownEmployerFeedbackResult(string uniqueSurveyCode)
    {
        var query = $"DECLARE @varaccountid bigint, @varukprn bigint, @varfeedbackid bigint;" +
            $"SELECT TOP(1) @varaccountid = [AccountId], @varukprn = [Ukprn] FROM [dbo].[vw_EmployerSurveyHistoryComplete] WHERE UniqueSurveyCode = '{uniqueSurveyCode}';" +
            $"SELECT @varfeedbackid = FeedbackId FROM EmployerFeedback WHERE AccountId = @varaccountid AND ukprn = @varukprn;" +
            $"DELETE FROM [dbo].[ProviderAttributes] WHERE EmployerFeedbackResultId in (SELECT Id FROM EmployerFeedbackResult WHERE FeedbackId = @varfeedbackid);" +
            $"DELETE FROM [dbo].[EmployerFeedbackResult] WHERE FeedbackId = @varfeedbackid;" +
            $"UPDATE EmployerSurveyCodes SET BurnDate = null WHERE FeedbackId = @varfeedbackid;" +
            $"UPDATE [dbo].[vw_EmployerSurveyHistoryComplete] SET CodeBurntDate = NULL WHERE UniqueSurveyCode = '{uniqueSurveyCode}'";

        ExecuteSqlCommand(query);
    }

    public void CreateEmployerProviderFeedback(string ukprn, int accountId, ProviderRating rating)
    {
        var userReference = "21ABB8EE-D5C3-46E3-A3BA-00039E3F3584";
        

        var sql = $"INSERT INTO [dbo].[EmployerFeedback]([UserRef], [Ukprn], [AccountId], [IsActive])" +
                  $"VALUES ('{userReference}', {ukprn}, {accountId}, 1);";

        ExecuteSqlCommand(sql);

        var feedbackId = GetData($"select MAX(FeedbackId) from [EmployerFeedback] where Ukprn = 10022856").First();
        
        var resultId = Guid.NewGuid();

        var resultDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
        if (rating.AcademicYear == "Previous")
        {
            resultDate = DateTime.UtcNow.AddYears(-1).ToString("yyyy-MM-dd");
        }

        sql = $"INSERT INTO [dbo].[EmployerFeedbackResult]([Id],[FeedbackId],[DateTimeCompleted],[ProviderRating],[FeedbackSource])" +
              $"VALUES ('{resultId}',{feedbackId},'{resultDate}','{rating.Rating}',1)";

        ExecuteSqlCommand(sql);

        ExecuteSqlCommand($"INSERT INTO [dbo].[ProviderAttributes]([EmployerFeedbackResultId],[AttributeId],[AttributeValue]) VALUES ('{resultId}',1,1)");
        ExecuteSqlCommand($"INSERT INTO [dbo].[ProviderAttributes]([EmployerFeedbackResultId],[AttributeId],[AttributeValue]) VALUES ('{resultId}',2,1)");
        ExecuteSqlCommand($"INSERT INTO [dbo].[ProviderAttributes]([EmployerFeedbackResultId],[AttributeId],[AttributeValue]) VALUES ('{resultId}',3,1)");
    }

    public void ClearProviderFeedback(string ukprn)
    {
        var sql =
            $"delete from ProviderStarsSummary where Ukprn = {ukprn};" +
            $"delete from ProviderRatingSummary where Ukprn = {ukprn}; " +
            $"delete from ProviderAttributes where EmployerFeedbackResultId in (select Id from EmployerFeedbackResult where FeedbackId in (select FeedbackId from EmployerFeedback where Ukprn = {ukprn}))" +
            $"delete from EmployerFeedbackResult where FeedbackId in (select FeedbackId from EmployerFeedback where Ukprn = {ukprn})" +
            $"delete from EmployerFeedback where Ukprn = {ukprn}";

        ExecuteSqlCommand(sql);
    }

    public void GenerateFeedbackSummaries()
    {
        var query = $"EXEC [dbo].[GenerateProviderRatingResults]";
        ExecuteSqlCommand(query);

        query = $"EXEC [dbo].[GenerateProviderAttributeResults]";
        ExecuteSqlCommand(query);
    }
}
