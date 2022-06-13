namespace SFA.DAS.ProvideFeedback.UITests.Project.Helpers;

public class ProvideFeedbackSqlHelper : SqlDbHelper
{
    public ProvideFeedbackSqlHelper(DbConfig config) : base(config.ProviderFeedbackDbConnectionString) { }

    public string GetUniqueSurveyCode() => FetchProvideFeedbackDataHelper.UniqueSurveyCode(connectionString);

    public void ClearDownDataFromUniqueSurveyCode(string uniqueSurveyCode) => ExecuteSqlCommand($"UPDATE [dbo].[vw_EmployerSurveyHistoryComplete] SET CodeBurntDate = NULL WHERE UniqueSurveyCode = '{uniqueSurveyCode}'");

    public void ClearDownDataForAdhocJourney() =>
        ExecuteSqlCommand($"Delete from [dbo].[ProviderAttributes] where EmployerFeedbackResultId in (select Id from EmployerFeedbackResult where FeedbackId = '10836')" +
            $"Delete from[dbo].[EmployerFeedbackResult] where Id in (select Id from EmployerFeedbackResult where FeedbackId = '10836')" +
           $"Update EmployerSurveyCodes set BurnDate = null where FeedbackId = '10836'");
}
