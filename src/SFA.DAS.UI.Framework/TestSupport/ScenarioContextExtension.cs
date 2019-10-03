using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string RegistrationProjectConfigKey = "registrationprojectconfig";
        private const string ApprovalsProjectConfigKey = "approvalsprojectconfig";
        private const string TransfersProjectConfigKey = "transfersprojectconfig";
        private const string MongoDbConfigKey = "mongodbconfig";
        private const string WebDriverKey = "webdriver";
        #endregion

        public static void SetRegistrationConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, RegistrationProjectConfigKey);
        }

        public static void SetApprovalsConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, ApprovalsProjectConfigKey);
        }

        public static void SetTransfersConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, TransfersProjectConfigKey);
        }

        public static T GetRegistrationConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, RegistrationProjectConfigKey);
        }

        public static T GetApprovalsConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, ApprovalsProjectConfigKey);
        }

        public static T GetTransfersConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, TransfersProjectConfigKey);
        }

        public static void SetMongoDbConfig(this ScenarioContext context, MongoDbConfig value)
        {
            Set(context, value, MongoDbConfigKey);
        }

        public static MongoDbConfig GetMongoDbConfig(this ScenarioContext context)
        {
            return Get<MongoDbConfig>(context, MongoDbConfigKey);
        }

        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            Set(context, webDriver, WebDriverKey);
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return Get<IWebDriver>(context, WebDriverKey);
        }

        private static void Set<T>(ScenarioContext context, T value, string key)
        {
            context.Set(value, key);
        }

        public static T Get<T>(ScenarioContext context, string key)
        {
            return context.Get<T>(key);
        }
    }
}
