using Microsoft.Extensions.Configuration;
using System.IO;

namespace SFA.DAS.ConfigurationBuilder
{
    public static class Configurator
    {
        private readonly static IConfigurationRoot _config;

        private readonly static IConfigurationRoot _hostingConfig;

        public readonly static bool IsVstsExecution;

        public readonly static string DriverLocation;

        public readonly static string EnvironmentName;

        public readonly static string ProjectName;

        static Configurator()
        {
            _hostingConfig = InitializeHostingConfig();
            IsVstsExecution = TestsExecutionInVsts();
            DriverLocation = GetDriverLocation();
            EnvironmentName = GetEnvironmentName();
            ProjectName = GetProjectName();
            _config = InitializeConfig();
        }

        internal static IConfigurationRoot GetConfig() => _config;

        private static IConfigurationRoot InitializeConfig()
        {
            return ConfigurationBuilder()
            .AddJsonFile("appsettings.MongoDbConfig.json", true)
            .AddJsonFile("appsettings.TimeOutConfig.json", true)
            .AddJsonFile("appsettings.BrowserStack.json", true)
            .AddJsonFile("appsettings.Project.json", true)
            .AddJsonFile("appsettings.Project.BrowserStack.json", true)
            .AddJsonFile($"appsettings.{EnvironmentName}.json", true)
            .AddJsonFile("appsettings.TestExecution.json", true)
            .AddUserSecrets("BrowserStackSecrets")
            .AddUserSecrets($"{ProjectName}_Secrets")
            .AddUserSecrets($"{ProjectName}_{EnvironmentName}_Secrets")
            .AddUserSecrets("MongoDbSecrets")
            .Build();
        }

        private static IConfigurationRoot InitializeHostingConfig() => ConfigurationBuilder()
                .AddJsonFile("appsettings.Environment.json", true)
                .AddEnvironmentVariables()
                .Build();

        private static IConfigurationBuilder ConfigurationBuilder() => new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

        private static bool TestsExecutionInVsts() => !string.IsNullOrEmpty(GetAgentMachineName());

        private static string GetDriverLocation() => string.IsNullOrEmpty(GetAgentReleaseDirectory()) ? string.Empty : Path.Combine(GetAgentReleaseDirectory(), GetDefinitionName()); 

        private static string GetAgentReleaseDirectory() => GetHostingConfigSection("AGENT_RELEASEDIRECTORY");

        private static string GetDefinitionName() => GetHostingConfigSection("BUILD_DEFINITIONNAME");

        private static string GetAgentMachineName() => GetHostingConfigSection("AGENT_MACHINENAME");

        private static string GetEnvironmentName() => IsVstsExecution ? GetHostingConfigSection("RELEASE_ENVIRONMENTNAME") : GetHostingConfigSection("local_EnvironmentName");

        private static string GetProjectName() => GetHostingConfigSection("ProjectName");

        private static string GetHostingConfigSection(string name) => _hostingConfig.GetSection(name)?.Value;
    }
}