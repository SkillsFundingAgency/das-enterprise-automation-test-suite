namespace SFA.DAS.ProvideFeedback.UITests.Project.Helpers;


public class EmployerFeedbackSqlHelper : SqlDbHelper
{
    public EmployerFeedbackSqlHelper(DbConfig config) : base(config.EmployerFeedbackDbConnectionString) { }

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
}
