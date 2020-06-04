using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Helpers
{
    public class ProviderFeedbackDatahelper : RandomElementHelper
    {
        public ProviderFeedbackDatahelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator) { }
    }



    public class ProviderFeedbackSqlHelper : SqlDbHelper
    {
        public ProviderFeedbackSqlHelper(ProviderFeedbackConfig config) : base(config.ProviderFeedbackDbConnectionString) { }

        public string GetUniqueSurveyCode() => GetData("SELECT TOP (1) [UniqueSurveyCode] FROM [dbo].[vw_EmployerSurveyHistoryComplete] where CodeBurntDate is null order by LastReminderSentDate desc");

        public void ClearDownDataFromUniqueSurveyCode(string uniqueSurveyCode) => ExecuteSqlCommand($"UPDATE [dbo].[vw_EmployerSurveyHistoryComplete] SET CodeBurntDate = NULL WHERE UniqueSurveyCode = '{uniqueSurveyCode}'");
    }
}
