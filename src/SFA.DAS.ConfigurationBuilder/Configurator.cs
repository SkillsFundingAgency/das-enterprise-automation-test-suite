using Microsoft.Extensions.Configuration;
using System.IO;

namespace SFA.DAS.ConfigurationBuilder
{
    public static class Configurator
    {
        private readonly static IConfigurationRoot _config;

        private readonly static IConfigurationRoot _hostingConfig;

        public readonly static bool IsVstsExecution;

        public readonly static string ChromeWebDriver;

        public readonly static string GeckoWebDriver;

        public readonly static string IEWebDriver;

        public readonly static string EnvironmentName;

        public readonly static string ProjectName;

        static Configurator()
        {
            _hostingConfig = InitializeHostingConfig();
            IsVstsExecution = TestsExecutionInVsts();
            ChromeWebDriver = GetHostingConfigSection("ChromeWebDriver");
            GeckoWebDriver = GetHostingConfigSection("GeckoWebDriver");
            IEWebDriver = GetHostingConfigSection("IEWebDriver");
            EnvironmentName = GetEnvironmentName();
            ProjectName = GetProjectName();
            _config = InitializeConfig();
        }

        internal static IConfigurationRoot GetConfig() => _config;

        private static IConfigurationRoot InitializeConfig()
        {
            return ConfigurationBuilder()
            .AddJsonFile("appsettings.DbConfig.json", true)
            .AddJsonFile("appsettings.TimeOutConfig.json", true)
            .AddJsonFile("appsettings.NServiceBusConfig.json",true)
            .AddJsonFile("appsettings.BrowserStack.json", true)
            .AddJsonFile("appsettings.ApiFramework.json",true)
            .AddJsonFile("appsettings.Project.json", true)
            .AddJsonFile("appsettings.Project.BrowserStack.json", true)
            .AddJsonFile($"appsettings.{EnvironmentName}.json", true)
            .AddJsonFile("appsettings.TestExecution.json", true)
            .AddUserSecrets("BrowserStackSecrets")
            .AddUserSecrets($"{ProjectName}_Secrets")
            .AddUserSecrets($"{ProjectName}_{EnvironmentName}_Secrets")
            .AddUserSecrets("MongoDbSecrets")
            .AddUserSecrets($"Db_{EnvironmentName}_Secrets")
            .AddUserSecrets("TestExecutionSecrets")
            .Build();
        }

        private static IConfigurationRoot InitializeHostingConfig() => ConfigurationBuilder()
                .AddJsonFile("appsettings.Environment.json", true)
                .AddEnvironmentVariables()
                .Build();

        private static IConfigurationBuilder ConfigurationBuilder() => new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

        private static bool TestsExecutionInVsts() => !string.IsNullOrEmpty(GetAgentMachineName());

        private static string GetAgentMachineName() => GetHostingConfigSection("AGENT_MACHINENAME");

        private static string GetEnvironmentName() => IsVstsExecution ? GetHostingConfigSection("RELEASE_ENVIRONMENTNAME") : GetHostingConfigSection("local_EnvironmentName");

        private static string GetProjectName() => GetHostingConfigSection("ProjectName");

        private static string GetHostingConfigSection(string name) => _hostingConfig.GetSection(name)?.Value;
    }
}