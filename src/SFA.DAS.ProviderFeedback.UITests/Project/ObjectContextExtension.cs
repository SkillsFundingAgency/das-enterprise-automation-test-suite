using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.ProviderFeedback.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string UniqueSurveyCode = "uniquesurveycode";
        #endregion

        public static void SetUniqueSurveyCode(this ObjectContext objectContext, string uniqueSurveyCode) => objectContext.Set(UniqueSurveyCode, uniqueSurveyCode);
        public static string GetUniqueSurveyCode(this ObjectContext objectContext) => objectContext.Get(UniqueSurveyCode);
    }
}
