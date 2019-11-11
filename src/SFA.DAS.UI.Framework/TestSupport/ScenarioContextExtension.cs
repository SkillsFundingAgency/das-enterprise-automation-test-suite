using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string TestProjectConfigKey = "testprojectconfig";
        private const string RegistrationProjectConfigKey = "registrationprojectconfig";
        private const string ApprovalsSupportProjectConfigKey = "approvalssupportprojectconfigkey";
        private const string RAAV1ProjectConfigKey = "raav1projectconfigkey";
        private const string ApprovalsProjectConfigKey = "approvalsprojectconfig";
        private const string ProviderPermissionConfigKey = "providerpermissionconfigkey";
        private const string TransfersProjectConfigKey = "transfersprojectconfig";
        private const string MongoDbConfigKey = "mongodbconfig";
        private const string WebDriverKey = "webdriver";
        #endregion

        public static void SetTestProjectConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, TestProjectConfigKey);
        }

        public static void SetRegistrationConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, RegistrationProjectConfigKey);
        }

        public static void SetApprovalsConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, ApprovalsProjectConfigKey);
        }

        public static void SetProviderPermissionConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, ProviderPermissionConfigKey);
        }

        public static void SetTransfersConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, TransfersProjectConfigKey);
        }

        public static T GetRegistrationConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, RegistrationProjectConfigKey);
        }

        public static T GetTestProjectConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, TestProjectConfigKey);
        }

        public static T GetApprovalsConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, ApprovalsProjectConfigKey);
        }

        public static T GetProviderPermissionConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, ProviderPermissionConfigKey);
        }

        public static T GetTransfersConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, TransfersProjectConfigKey);
        }

        public static T GetRAAV1Config<T>(this ScenarioContext context)
        {
            return Get<T>(context, RAAV1ProjectConfigKey);
        }

        public static T GetApprovalsSupportConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, ApprovalsSupportProjectConfigKey);
        }

        public static void SetApprovalsSupportConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, ApprovalsSupportProjectConfigKey);
        }

        public static void SetRAAV1Config<T>(this ScenarioContext context, T value)
        {
            Set(context, value, RAAV1ProjectConfigKey);
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
            Replace(context, webDriver, WebDriverKey);
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return Get<IWebDriver>(context, WebDriverKey);
        }

        private static void Replace<T>(ScenarioContext context, T value, string key)
        {
            context.Replace(key, value);
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
