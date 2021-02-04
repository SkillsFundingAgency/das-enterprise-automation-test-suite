using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.API.Framework
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string ApiFrameworkConfigkey = "apiframeworkconfigkey";
        private const string ApprenticeCommitmentsApiProjectConfigKey = "apprenticecommitmentsapiprojectconfigkey";
        #endregion

        #region Setters
        public static void SetApiFrameworkConfig<T>(this ScenarioContext context, T value) => Set(context, value, ApiFrameworkConfigkey);
        public static void SetApprenticeCommitmentsApiConfig<T>(this ScenarioContext context, T value) => Set(context, value, ApprenticeCommitmentsApiProjectConfigKey);
        private static void Set<T>(ScenarioContext context, T value, string key) => context.Set(value, key);
        #endregion

        #region Getters
        public static T GetApiSubscriptionKeyConfig<T>(this ScenarioContext context) => Get<T>(context, ApiFrameworkConfigkey);
        public static T GetApprenticeCommitmentsApiConfig<T>(this ScenarioContext context) => Get<T>(context, ApprenticeCommitmentsApiProjectConfigKey);
        public static T Get<T>(ScenarioContext context, string key) => context.GetValue<T>(key);
        #endregion
    }
}
