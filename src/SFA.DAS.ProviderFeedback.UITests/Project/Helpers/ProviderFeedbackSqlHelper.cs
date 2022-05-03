using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Helpers
{
    public class ProviderFeedbackSqlHelper : SqlDbHelper
    {
        public ProviderFeedbackSqlHelper(DbConfig config) : base(config.ProviderFeedbackDbConnectionString) { }

        public string GetUniqueSurveyCode() => FetchProviderFeedbackDataHelper.UniqueSurveyCode(connectionString);

        public void ClearDownDataFromUniqueSurveyCode(string uniqueSurveyCode) => ExecuteSqlCommand($"UPDATE [dbo].[vw_EmployerSurveyHistoryComplete] SET CodeBurntDate = NULL WHERE UniqueSurveyCode = '{uniqueSurveyCode}'");

        public void ClearDownDataForAdhocJourney () =>
            ExecuteSqlCommand($"Delete from [dbo].[ProviderAttributes] where EmployerFeedbackResultId in (select Id from EmployerFeedbackResult where FeedbackId = '10836')" +
                $"Delete from[dbo].[EmployerFeedbackResult] where Id in (select Id from EmployerFeedbackResult where FeedbackId = '10836')" +
               $"Update EmployerSurveyCodes set BurnDate = null where FeedbackId = '10836'");
    }
}
