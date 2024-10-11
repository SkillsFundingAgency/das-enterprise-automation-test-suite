using DnsClient;
using Microsoft.Identity.Client;
using MongoDB.Driver;
using SFA.DAS.ProvideFeedback.UITests.Project.Models;
using System;
using System.Text;
using TechTalk.SpecFlow.CommonModels;

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

    public void CreateEmployerFeedback(string ukprn, List<ProviderRating> data)
    {
        var userReference = "21ABB8EE-D5C3-46E3-A3BA-00039E3F3584";
        var accountId = 1;

        var sql =
            $"delete from ProviderStarsSummary where Ukprn = {ukprn};" +
            $"delete from ProviderRatingSummary where Ukprn = {ukprn}; " +
            $"delete from EmployerSurveyCodes where FeedbackId in (select FeedbackId from EmployerFeedback where Ukprn = {ukprn}); " +
            $"delete from ProviderAttributes where EmployerFeedbackResultId in (select Id from EmployerFeedbackResult where FeedbackId in (select FeedbackId from EmployerFeedback where Ukprn = {ukprn}))" +
            $"delete from EmployerFeedbackResult where FeedbackId in (select FeedbackId from EmployerFeedback where Ukprn = {ukprn})" +
            $"delete from EmployerFeedback where Ukprn = {ukprn}";

        foreach (var row in data)
        {
            sql += $"INSERT INTO [dbo].[EmployerFeedback]([UserRef], [Ukprn], [AccountId], [IsActive])" +
                  $"VALUES ('{userReference}', {ukprn}, {accountId}, 1);";

            accountId++;
        }

        ExecuteSqlCommand(sql);
    }

    public void CreateEmployerFeedbackResults(string ukprn, List<ProviderRating> data)
    {
        if (data.Count == 0) return;

        var currentAcademicYearDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
        var previousAcademicYearDate = DateTime.UtcNow.AddYears(-1).ToString("yyyy-MM-dd");

        var count = data.Count;
        var feedbackIds = GetMultipleData($"SELECT TOP {count} FeedbackId FROM [EmployerFeedback] WHERE Ukprn = {ukprn} ORDER BY FeedbackId DESC");

        var sql = new StringBuilder();

        var i = 0;
        foreach (var row in data)
        {
            var feedbackId = feedbackIds[i].First();
            var resultDate = row.AcademicYear == "Previous" ? previousAcademicYearDate : currentAcademicYearDate;
            var resultId = Guid.NewGuid();

            sql.Append($@"
            INSERT INTO [dbo].[EmployerFeedbackResult]
            ([Id],[FeedbackId],[DateTimeCompleted],[ProviderRating],[FeedbackSource])
            VALUES 
            ('{resultId}',{feedbackId},'{resultDate}','{row.Rating}',1);");

            sql.Append($@"
            INSERT INTO [dbo].[ProviderAttributes]([EmployerFeedbackResultId],[AttributeId],[AttributeValue]) VALUES 
            ('{resultId}', 1, 1),
            ('{resultId}', 2, 1),
            ('{resultId}', 3, 1);
            ");

            i++;
        }

        ExecuteSqlCommand(sql.ToString());
    }

    public void GenerateFeedbackSummaries()
    {
        var query = $"EXEC [dbo].[GenerateProviderRatingResults]";
        ExecuteSqlCommand(query);

        query = $"EXEC [dbo].[GenerateProviderAttributeResults]";
        ExecuteSqlCommand(query);
    }
}
