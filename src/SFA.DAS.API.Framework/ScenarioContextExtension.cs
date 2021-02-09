using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.API.Framework
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private static string RestClientKey<T>() => $"{(typeof(T).Name)}_restclient";
        #endregion

        #region Setters
        public static void SetRestClient<T>(this ScenarioContext context, T value) => Set(context, value, RestClientKey<T>());
        private static void Set<T>(ScenarioContext context, T value, string key) => context.Set(value, key);
        #endregion

        #region Getters
        public static T GetRestClient<T>(this ScenarioContext context) => Get<T>(context, RestClientKey<T>());
        public static T Get<T>(ScenarioContext context, string key) => context.GetValue<T>(key);
        #endregion
    }
}
