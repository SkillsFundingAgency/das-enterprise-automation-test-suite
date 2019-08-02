using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string ProjectSpecificConfigKey = "projectspecificconfig";
        #endregion

        public static void SetProjectSpecificConfig<T>(this ScenarioContext context, T value)
        {
            context.Set(value, ProjectSpecificConfigKey);
        }

        public static T GetProjectSpecificConfig<T>(this ScenarioContext context)
        {
            return context.Get<T>(ProjectSpecificConfigKey);
        }

        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            context.Set(webDriver, "webdriver");
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return context.Get<IWebDriver>("webdriver");
        }
    }
}
