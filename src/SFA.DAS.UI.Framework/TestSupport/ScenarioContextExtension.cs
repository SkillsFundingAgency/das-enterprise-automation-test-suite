using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string ProjectConfigKey = "projectspecificconfig";
        private const string MongoDbConfigKey = "mongodbconfig";
        private const string WebDriverKey = "webdriver";
        #endregion

        public static void SetProjectConfig<T>(this ScenarioContext context, T value)
        {
            context.Set(value, ProjectConfigKey);
        }

        public static T GetProjectConfig<T>(this ScenarioContext context)
        {
            return context.Get<T>(ProjectConfigKey);
        }

        public static void SetMongoDbConfig(this ScenarioContext context, MongoDbConfig value)
        {
            context.Set(value, MongoDbConfigKey);
        }

        public static MongoDbConfig GetMongoDbConfig(this ScenarioContext context)
        {
            return context.Get<MongoDbConfig>(MongoDbConfigKey);
        }

        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            context.Set(webDriver, WebDriverKey);
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return context.Get<IWebDriver>(WebDriverKey);
        }
    }
}
