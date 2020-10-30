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
        private const string RegistrationProjectConfigKey = "registrationprojectconfigkey";
        private const string TprProjectConfigKey = "tprprojectconfigkey";
        private const string ProviderLeadRegistrationConfigKey = "providerleadregistrationconfigkey";
        private const string RoatpProjectConfigKey = "roatpprojectconfigkey";
        private const string SupportConsoleProjectConfigKey = "supportconsoleprojectconfigkey";
        private const string ConsolidatedSupportProjectConfigKey = "consolidatedsupportprojectconfigkey";
        private const string RAAV1ProjectConfigKey = "raav1projectconfigkey";
        private const string RAAV2QAProjectConfigKey = "raav2qaprojectconfigkey";
        private const string ApprovalsProjectConfigKey = "approvalsprojectconfigkey";
        private const string FAAProjectConfigKey = "faaprojectconfigkey";
        private const string ProviderPermissionConfigKey = "providerpermissionconfigkey";
        private const string PerfTestProviderPermissionsConfigKey = "perftestproviderpermissionconfigkey";
        private const string TransfersProjectConfigKey = "transfersprojectconfigkey";
        private const string ChangeOfPartyConfigKey = "changeofpartyconfigkey";
        private const string EPAOProjectConfigKey = "epaoprojectconfigkey";
        private const string ProviderFeedbackConfigKey = "providerfeedbackprojectconfigkey";
        private const string ARProjectConfigKey = "arprojectconfigkey";
        private const string EIProjectConfigKey = "eiprojectconfigkey";
        #endregion

        #region Setters
        public static void SetRoatpConfig<T>(this ScenarioContext context, T value) => Set(context, value, RoatpProjectConfigKey);
        public static void SetRegistrationConfig<T>(this ScenarioContext context, T value) => Set(context, value, RegistrationProjectConfigKey);
        public static void SetTprConfig<T>(this ScenarioContext context, T value) => Set(context, value, TprProjectConfigKey);
        public static void SetProviderLeadRegistrationConfig<T>(this ScenarioContext context, T value) => Set(context, value, ProviderLeadRegistrationConfigKey);
        public static void SetApprovalsConfig<T>(this ScenarioContext context, T value) => Set(context, value, ApprovalsProjectConfigKey);
        public static void SetProviderConfig<T>(this ScenarioContext context, T value) => Set(context, value, ProviderConfigKey);
        public static void SetProviderPermissionConfig<T>(this ScenarioContext context, T value) => Set(context, value, ProviderPermissionConfigKey);
        public static void SetPerfTestProviderPermissionsConfig<T>(this ScenarioContext context, T value) => Set(context, value, PerfTestProviderPermissionsConfigKey);
        public static void SetTransfersConfig<T>(this ScenarioContext context, T value) => Set(context, value, TransfersProjectConfigKey);
        public static void SetChangeOfPartyConfig<T>(this ScenarioContext context, T value) => Set(context, value, ChangeOfPartyConfigKey);
        public static void SetSupportConsoleConfig<T>(this ScenarioContext context, T value) => Set(context, value, SupportConsoleProjectConfigKey);
        public static void SetConsolidatedSupportConfig<T>(this ScenarioContext context, T value) => Set(context, value, ConsolidatedSupportProjectConfigKey);
        public static void SetRAAV1Config<T>(this ScenarioContext context, T value) => Set(context, value, RAAV1ProjectConfigKey);
        public static void SetRAAV2QAConfig<T>(this ScenarioContext context, T value) => Set(context, value, RAAV2QAProjectConfigKey);
        public static void SetFAAConfig<T>(this ScenarioContext context, T value) => Set(context, value, FAAProjectConfigKey);
        public static void SetEPAOConfig<T>(this ScenarioContext context, T value) => Set(context, value, EPAOProjectConfigKey);
        public static void SetProviderFeedbackConfig<T>(this ScenarioContext context, T value) => Set(context, value, ProviderFeedbackConfigKey);
        public static void SetARConfig<T>(this ScenarioContext context, T value) => Set(context, value, ARProjectConfigKey);
        public static void SetEIConfig<T>(this ScenarioContext context, T value) => Set(context, value, EIProjectConfigKey);
        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver) => Replace(context, webDriver, WebDriverKey);      
        private static void Replace<T>(ScenarioContext context, T value, string key) => context.Replace(key, value);
        private static void Set<T>(ScenarioContext context, T value, string key) => context.Set(value, key);
        #endregion

        #region Getters
        public static T GetRoatpConfig<T>(this ScenarioContext context) => Get<T>(context, RoatpProjectConfigKey);
        public static T GetRegistrationConfig<T>(this ScenarioContext context) => Get<T>(context, RegistrationProjectConfigKey);
        public static T GetTprConfig<T>(this ScenarioContext context) => Get<T>(context, TprProjectConfigKey);
        public static T GetProviderLeadRegistrationConfig<T>(this ScenarioContext context) => Get<T>(context, ProviderLeadRegistrationConfigKey);
        public static T GetApprovalsConfig<T>(this ScenarioContext context) => Get<T>(context, ApprovalsProjectConfigKey);
        public static T GetProviderConfig<T>(this ScenarioContext context) => Get<T>(context, ProviderConfigKey);
        public static T GetProviderPermissionConfig<T>(this ScenarioContext context) => Get<T>(context, ProviderPermissionConfigKey);
        public static T GetChangeOfPartyConfig<T>(this ScenarioContext context) => Get<T>(context, ChangeOfPartyConfigKey);
        public static T GetPerfTestProviderPermissionsConfig<T>(this ScenarioContext context) => Get<T>(context, PerfTestProviderPermissionsConfigKey);
        public static T GetTransfersConfig<T>(this ScenarioContext context) => Get<T>(context, TransfersProjectConfigKey);
        public static T GetRAAV1Config<T>(this ScenarioContext context) => Get<T>(context, RAAV1ProjectConfigKey);
        public static T GetRAAV2QAConfig<T>(this ScenarioContext context) => Get<T>(context, RAAV2QAProjectConfigKey);
        public static T GetFAAConfig<T>(this ScenarioContext context) => Get<T>(context, FAAProjectConfigKey);
        public static T GetSupportConsoleConfig<T>(this ScenarioContext context) => Get<T>(context, SupportConsoleProjectConfigKey);
        public static T GetConsolidatedSupportConfig<T>(this ScenarioContext context) => Get<T>(context, ConsolidatedSupportProjectConfigKey);
        public static T GetEPAOConfig<T>(this ScenarioContext context) => Get<T>(context, EPAOProjectConfigKey);
        public static T GetProviderFeedbackConfig<T>(this ScenarioContext context) => Get<T>(context, ProviderFeedbackConfigKey);
        public static T GetARConfig<T>(this ScenarioContext context) => Get<T>(context, ARProjectConfigKey);
        public static T GetEIConfig<T>(this ScenarioContext context) => Get<T>(context, EIProjectConfigKey);
        public static IWebDriver GetWebDriver(this ScenarioContext context) => Get<IWebDriver>(context, WebDriverKey);
        public static T Get<T>(ScenarioContext context, string key) => context.GetValue<T>(key);
        #endregion
    }
}
