using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string WebDriverKey = "webdriverkey";
        private const string ProviderConfigKey = "providerconfigkey";
        private const string TestProjectConfigKey = "testprojectconfigkey";
        private const string RegistrationProjectConfigKey = "registrationprojectconfigkey";
        private const string TprProjectConfigKey = "tprprojectconfigkey";
        private const string RoatpProjectConfigKey = "roatpprojectconfigkey";
        private const string SupportConsoleProjectConfigKey = "supportconsoleprojectconfigkey";
        private const string RAAV1ProjectConfigKey = "raav1projectconfigkey";
        private const string RAAV2QAProjectConfigKey = "raav2qaprojectconfigkey";
        private const string ApprovalsProjectConfigKey = "approvalsprojectconfigkey";
        private const string FAAProjectConfigKey = "faaprojectconfigkey";
        private const string ProviderPermissionConfigKey = "providerpermissionconfigkey";
        private const string TransfersProjectConfigKey = "transfersprojectconfigkey";
        private const string FATProjectConfigKey = "fatprojectconfigkey";
        private const string EPAOProjectConfigKey = "epaoprojectconfigkey";
        private const string CampaignsConfigKey = "campaignsprojectconfigkey";
        private const string AskConfigKey = "askprojectconfigkey";
        private const string MailinatorConfigKey = "mailinatorconfigkey";
        #endregion

        #region Setters
        public static void SetRoatpConfig<T>(this ScenarioContext context, T value) => Set(context, value, RoatpProjectConfigKey);
        public static void SetTestProjectConfig<T>(this ScenarioContext context, T value) => Set(context, value, TestProjectConfigKey);
        public static void SetRegistrationConfig<T>(this ScenarioContext context, T value) => Set(context, value, RegistrationProjectConfigKey);
        public static void SetMailinatorConfig<T>(this ScenarioContext context, T value) => Set(context, value, MailinatorConfigKey);
        public static void SetTprConfig<T>(this ScenarioContext context, T value) => Set(context, value, TprProjectConfigKey);
        public static void SetApprovalsConfig<T>(this ScenarioContext context, T value) => Set(context, value, ApprovalsProjectConfigKey);
        public static void SetProviderConfig<T>(this ScenarioContext context, T value) => Set(context, value, ProviderConfigKey);
        public static void SetProviderPermissionConfig<T>(this ScenarioContext context, T value) => Set(context, value, ProviderPermissionConfigKey);
        public static void SetTransfersConfig<T>(this ScenarioContext context, T value) => Set(context, value, TransfersProjectConfigKey);
        public static void SetFATConfig<T>(this ScenarioContext context, T value) => Set(context, value, FATProjectConfigKey);
        public static void SetSupportConsoleConfig<T>(this ScenarioContext context, T value) => Set(context, value, SupportConsoleProjectConfigKey);
        public static void SetRAAV1Config<T>(this ScenarioContext context, T value) => Set(context, value, RAAV1ProjectConfigKey);
        public static void SetRAAV2QAConfig<T>(this ScenarioContext context, T value) => Set(context, value, RAAV2QAProjectConfigKey);
        public static void SetFAAConfig<T>(this ScenarioContext context, T value) => Set(context, value, FAAProjectConfigKey);
        public static void SetEPAOConfig<T>(this ScenarioContext context, T value) => Set(context, value, EPAOProjectConfigKey);
        public static void SetCampaignsConfig<T>(this ScenarioContext context, T value) => Set(context, value, CampaignsConfigKey);
        public static void SetAskConfig<T>(this ScenarioContext context, T value) => Set(context, value, AskConfigKey);
        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver) => Replace(context, webDriver, WebDriverKey);      
        private static void Replace<T>(ScenarioContext context, T value, string key) => context.Replace(key, value);
        private static void Set<T>(ScenarioContext context, T value, string key) => context.Set(value, key);
        #endregion

        #region Getters
        public static T GetRoatpConfig<T>(this ScenarioContext context) => Get<T>(context, RoatpProjectConfigKey);
        public static T GetFATConfig<T>(this ScenarioContext context) => Get<T>(context, FATProjectConfigKey);
        public static T GetRegistrationConfig<T>(this ScenarioContext context) => Get<T>(context, RegistrationProjectConfigKey);
        public static T GetMailinatorConfig<T>(this ScenarioContext context) => Get<T>(context, MailinatorConfigKey);
        public static T GetTprConfig<T>(this ScenarioContext context) => Get<T>(context, TprProjectConfigKey);
        public static T GetTestProjectConfig<T>(this ScenarioContext context) => Get<T>(context, TestProjectConfigKey);
        public static T GetApprovalsConfig<T>(this ScenarioContext context) => Get<T>(context, ApprovalsProjectConfigKey);
        public static T GetProviderConfig<T>(this ScenarioContext context) => Get<T>(context, ProviderConfigKey);
        public static T GetProviderPermissionConfig<T>(this ScenarioContext context) => Get<T>(context, ProviderPermissionConfigKey);
        public static T GetTransfersConfig<T>(this ScenarioContext context) => Get<T>(context, TransfersProjectConfigKey);
        public static T GetRAAV1Config<T>(this ScenarioContext context) => Get<T>(context, RAAV1ProjectConfigKey);
        public static T GetRAAV2QAConfig<T>(this ScenarioContext context) => Get<T>(context, RAAV2QAProjectConfigKey);
        public static T GetFAAConfig<T>(this ScenarioContext context) => Get<T>(context, FAAProjectConfigKey);
        public static T GetSupportConsoleConfig<T>(this ScenarioContext context) => Get<T>(context, SupportConsoleProjectConfigKey);
        public static T GetEPAOConfig<T>(this ScenarioContext context) => Get<T>(context, EPAOProjectConfigKey);
        public static T GetCampaignsConfig<T>(this ScenarioContext context) => Get<T>(context, CampaignsConfigKey);
        public static T GetAskConfig<T>(this ScenarioContext context) => Get<T>(context, AskConfigKey);
        public static IWebDriver GetWebDriver(this ScenarioContext context) => Get<IWebDriver>(context, WebDriverKey);
        public static T Get<T>(ScenarioContext context, string key) => context.Get<T>(key);
        #endregion
    }
}
