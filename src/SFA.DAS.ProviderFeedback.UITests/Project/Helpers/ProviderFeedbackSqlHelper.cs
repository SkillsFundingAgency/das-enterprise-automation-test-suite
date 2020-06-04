using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Helpers
{
    public class ProviderFeedbackSqlHelper : SqlDbHelper
    {
        public ProviderFeedbackSqlHelper(ProviderFeedbackConfig config) : base(config.ProviderFeedbackDbConnectionString) { }

        public string GetUniqueSurveyCode() => FetchProviderFeedbackData.UniqueSurveyCode(connectionString);

        public void ClearDownDataFromUniqueSurveyCode(string uniqueSurveyCode) => ExecuteSqlCommand($"UPDATE [dbo].[vw_EmployerSurveyHistoryComplete] SET CodeBurntDate = NULL WHERE UniqueSurveyCode = '{uniqueSurveyCode}'");
    }
}
