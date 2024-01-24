using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace SFA.DAS.ConfigurationBuilder
{
    public static class Configurator
    {
        private static readonly IConfigurationRoot _config;

        private static readonly IConfigurationRoot _hostingConfig;

        public static readonly bool IsVstsExecution;

        internal static readonly string EnvironmentName;

        private static readonly string ChromeWebDriver;

        private static readonly string GeckoWebDriver;

        private static readonly string EdgeWebDriver;

        private static readonly string ProjectName;

        static Configurator()
        {
            _hostingConfig = InitializeHostingConfig();
            IsVstsExecution = TestsExecutionInVsts();
            ChromeWebDriver = GetHostingConfigSection("CHROMEWEBDRIVER");
            GeckoWebDriver = GetHostingConfigSection("GECKOWEBDRIVER");
            EdgeWebDriver = GetHostingConfigSection("EDGEWEBDRIVER");
            EnvironmentName = GetEnvironmentName();
            ProjectName = GetProjectName();
            _config = InitializeConfig();
        }

        public static (string chromeWebDriver, string geckoWebDriver, string edgeWebDriver) GetDriverLocation() => (ChromeWebDriver, GeckoWebDriver, EdgeWebDriver);

        internal static IConfigurationRoot GetConfig() => _config;

        private static IConfigurationRoot InitializeConfig()
        {
            var builder = ConfigurationBuilder()
                .AddOptionalJsonFiles(
                [
                    "appsettings.DbConfig.json",
                    "appsettings.TimeOutConfig.json",
                    "appsettings.NServiceBusConfig.json",
                    "appsettings.BrowserStack.json",
                    "appsettings.Mailinator.json",
                    "appsettings.ApiFramework.json",
                    "appsettings.AdminConfig.json",
                    "appsettings.ProviderConfig.json",
                    "appsettings.Project.json",
                    "appsettings.Project.BrowserStack.json",
                    $"appsettings.{EnvironmentName}.json",
                    "appsettings.TestExecution.json"
                ]);

            if (!IsVstsExecution)
            {
                builder
                    .AddUserSecrets("BrowserStackSecrets")
                    .AddUserSecrets($"{EnvironmentName}_Secrets")
                    .AddUserSecrets($"{ProjectName}_Secrets")
                    .AddUserSecrets($"{ProjectName}_{EnvironmentName}_Secrets")
                    .AddUserSecrets("MongoDbSecrets")
                    .AddUserSecrets("TestExecutionSecrets");
            }

            return builder.Build();
        }

        private static IConfigurationBuilder AddOptionalJsonFiles(this IConfigurationBuilder builder, List<string> paths)
        {
            foreach (var path in paths) builder.AddJsonFile(path, true);

            return builder;
        }

        private static IConfigurationRoot InitializeHostingConfig() => ConfigurationBuilder()
                .AddJsonFile("appsettings.Environment.json", true)
                .AddEnvironmentVariables()
                .Build();

        private static IConfigurationBuilder ConfigurationBuilder() => new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

        private static bool TestsExecutionInVsts() => !string.IsNullOrEmpty(GetAgentMachineName());

        private static string GetAgentMachineName() => GetHostingConfigSection("AGENT_MACHINENAME");

        private static string GetEnvironmentName() => IsVstsExecution ? GetHostingConfigSection("ResourceEnvironmentName") : GetHostingConfigSection("local_EnvironmentName");

        private static string GetProjectName() => GetHostingConfigSection("ProjectName");

        public static string GetDeploymentRequestedFor() => GetHostingConfigSection("RELEASE_DEPLOYMENT_REQUESTEDFOR");

        private static string GetHostingConfigSection(string name) => _hostingConfig.GetSection(name)?.Value;
    }
}