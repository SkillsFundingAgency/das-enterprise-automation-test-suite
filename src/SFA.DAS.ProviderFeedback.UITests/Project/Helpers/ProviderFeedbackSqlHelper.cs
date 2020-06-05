using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Helpers
{
    public class ProviderFeedbackSqlHelper : SqlDbHelper
    {
        public ProviderFeedbackSqlHelper(ProviderFeedbackConfig config) : base(config.ProviderFeedbackDbConnectionString) { }

        public string GetUniqueSurveyCode() => GetData("SELECT TOP (1) [UniqueSurveyCode] FROM [dbo].[vw_EmployerSurveyHistoryComplete] where CodeBurntDate is null order by LastReminderSentDate desc");
    }
}
