using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.API.Framework
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string Fatv2ApiProjectConfigKey = "fatv2apiprojectconfigkey";
        #endregion

        #region Setters
        public static void SetFatV2ApiConfig<T>(this ScenarioContext context, T value) => Set(context, value, Fatv2ApiProjectConfigKey);
        private static void Set<T>(ScenarioContext context, T value, string key) => context.Set(value, key);
        #endregion

        #region Getters
        public static T GetFatV2ApiConfig<T>(this ScenarioContext context) => Get<T>(context, Fatv2ApiProjectConfigKey);
        public static T Get<T>(ScenarioContext context, string key) => context.GetValue<T>(key);
        #endregion
    }
}
