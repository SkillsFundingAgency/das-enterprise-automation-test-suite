using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public static class ScenarioContextExtension
{
    #region Constants
    private const string WebDriverKey = "webdriverkey";
    private const string ProviderConfigKey = "providerconfigkey";
    private const string RoatpProjectConfigKey = "roatpprojectconfigkey";
    private const string ManagingStandatdsProjectConfigKey = "managingstandardsprojectconfigkey";
    private const string SupportConsoleProjectConfigKey = "supportconsoleprojectconfigkey";
    private const string ConsolidatedSupportProjectConfigKey = "consolidatedsupportprojectconfigkey";
    private const string RAAV1ProjectConfigKey = "raav1projectconfigkey";
    private const string ApprovalsProjectConfigKey = "approvalsprojectconfigkey";
    private const string FAAProjectConfigKey = "faaprojectconfigkey";
    private const string ProviderPermissionConfigKey = "providerpermissionconfigkey";
    private const string PerfTestProviderPermissionsConfigKey = "perftestproviderpermissionconfigkey";
    private const string TransfersProjectConfigKey = "transfersprojectconfigkey";
    private const string ChangeOfPartyConfigKey = "changeofpartyconfigkey";
    private const string ARProjectConfigKey = "arprojectconfigkey";
    private const string EIProjectConfigKey = "eiprojectconfigkey";
    private const string ApprenticeCommitmentsConfigKey = "apprenticecommitmentsconfigkey";
    private const string PortableFlexiJobProviderConfigKey = "portableflexijobproviderconfigkey";
    #endregion

    #region Setters
    public static void SetManagingStandardsConfig<T>(this ScenarioContext context, T value) => Set(context, value, ManagingStandatdsProjectConfigKey);
    public static void SetApprovalsConfig<T>(this ScenarioContext context, T value) => Set(context, value, ApprovalsProjectConfigKey);
    public static void SetProviderConfig<T>(this ScenarioContext context, T value) => Set(context, value, ProviderConfigKey);
    public static void SetProviderPermissionConfig<T>(this ScenarioContext context, T value) => Set(context, value, ProviderPermissionConfigKey);
    public static void SetPerfTestProviderPermissionsConfig<T>(this ScenarioContext context, T value) => Set(context, value, PerfTestProviderPermissionsConfigKey);
    public static void SetTransfersConfig<T>(this ScenarioContext context, T value) => Set(context, value, TransfersProjectConfigKey);
    public static void SetChangeOfPartyConfig<T>(this ScenarioContext context, T value) => Set(context, value, ChangeOfPartyConfigKey);
    public static void SetPortableFlexiJobProviderConfig<T>(this ScenarioContext context, T value) => Set(context, value, PortableFlexiJobProviderConfigKey);
    public static void SetSupportConsoleConfig<T>(this ScenarioContext context, T value) => Set(context, value, SupportConsoleProjectConfigKey);
    public static void ReplaceSupportConsoleConfig<T>(this ScenarioContext context, T value) => Replace(context, value, SupportConsoleProjectConfigKey);
    public static void SetConsolidatedSupportConfig<T>(this ScenarioContext context, T value) => Set(context, value, ConsolidatedSupportProjectConfigKey);
    public static void SetRAAV1Config<T>(this ScenarioContext context, T value) => Set(context, value, RAAV1ProjectConfigKey);
    public static void SetFAAConfig<T>(this ScenarioContext context, T value) => Set(context, value, FAAProjectConfigKey);
    public static void SetARConfig<T>(this ScenarioContext context, T value) => Set(context, value, ARProjectConfigKey);
    public static void SetEIConfig<T>(this ScenarioContext context, T value) => Set(context, value, EIProjectConfigKey);
    public static void SetApprenticeCommitmentsConfig<T>(this ScenarioContext context, T value) => Set(context, value, ApprenticeCommitmentsConfigKey);
    public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver) => Replace(context, webDriver, WebDriverKey);
    private static void Replace<T>(ScenarioContext context, T value, string key) => context.Replace(key, value);
    private static void Set<T>(ScenarioContext context, T value, string key) => context.Set(value, key);
    #endregion

    #region Getters
    public static T GetManagingStandardsConfig<T>(this ScenarioContext context) => Get<T>(context, ManagingStandatdsProjectConfigKey);
    public static T GetRoatpConfig<T>(this ScenarioContext context) => Get<T>(context, RoatpProjectConfigKey);
    public static T GetApprovalsConfig<T>(this ScenarioContext context) => Get<T>(context, ApprovalsProjectConfigKey);
    public static T GetProviderConfig<T>(this ScenarioContext context) => Get<T>(context, ProviderConfigKey);
    public static T GetProviderPermissionConfig<T>(this ScenarioContext context) => Get<T>(context, ProviderPermissionConfigKey);
    public static T GetChangeOfPartyConfig<T>(this ScenarioContext context) => Get<T>(context, ChangeOfPartyConfigKey);
    public static T GetPortableFlexiJobProviderConfig<T>(this ScenarioContext context) => Get<T>(context, PortableFlexiJobProviderConfigKey);
    public static T GetPerfTestProviderPermissionsConfig<T>(this ScenarioContext context) => Get<T>(context, PerfTestProviderPermissionsConfigKey);
    public static T GetTransfersConfig<T>(this ScenarioContext context) => Get<T>(context, TransfersProjectConfigKey);
    public static T GetRAAV1Config<T>(this ScenarioContext context) => Get<T>(context, RAAV1ProjectConfigKey);
    public static T GetFAAConfig<T>(this ScenarioContext context) => Get<T>(context, FAAProjectConfigKey);
    public static T GetSupportConsoleConfig<T>(this ScenarioContext context) => Get<T>(context, SupportConsoleProjectConfigKey);
    public static T GetConsolidatedSupportConfig<T>(this ScenarioContext context) => Get<T>(context, ConsolidatedSupportProjectConfigKey);
    public static T GetARConfig<T>(this ScenarioContext context) => Get<T>(context, ARProjectConfigKey);
    public static T GetEIConfig<T>(this ScenarioContext context) => Get<T>(context, EIProjectConfigKey);
    public static T GetApprenticeCommitmentsConfig<T>(this ScenarioContext context) => Get<T>(context, ApprenticeCommitmentsConfigKey);
    public static IWebDriver GetWebDriver(this ScenarioContext context) => Get<IWebDriver>(context, WebDriverKey);
    public static T Get<T>(ScenarioContext context, string key) => context.GetValue<T>(key);
    #endregion
}
