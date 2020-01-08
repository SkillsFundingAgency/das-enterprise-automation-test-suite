using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service
{
    public static class ScenarioContextExtension
    {
        #region Constants
        static string Key<T>() => typeof(T).FullName;
        #endregion

        public static void SetUser<T>(this ScenarioContext context, T value)
        {
            context.Set(value, Key<T>());
        }

        public static T GetUser<T>(this ScenarioContext context)
        {
            return context.Get<T>(Key<T>());
        }
    }
}
