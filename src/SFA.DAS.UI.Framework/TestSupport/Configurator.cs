using Microsoft.Extensions.Configuration;
using System.IO;

namespace SFA.DAS.UI.Framework.TestSupport
{
    internal static class Configurator
    {
        private readonly static IConfigurationRoot _config;

        private readonly static IConfigurationRoot _hostingConfig;

        internal static bool IsVstsExecution;

        static Configurator()
        {
            _hostingConfig = InitializeHostingConfig();
            IsVstsExecution = TestsExecutionInVsts();
            _config = InitializeConfig();
        }

        internal static IConfigurationRoot GetConfig()
        {
            return _config;
        }

        private static IConfigurationRoot InitializeConfig()
        {
            var EnvironmentName = GetEnvironmentName();

            var ProjectName = _hostingConfig.GetSection("ProjectName").Value;

            return ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile("appsettings.BrowserStack.json", true)
            .AddJsonFile("appsettings.Project.json", true)
            .AddJsonFile("appsettings.Project.BrowserStack.json", true)
            .AddJsonFile($"appsettings.{EnvironmentName}.json", true)
            .AddEnvironmentVariables()
            .AddUserSecrets("BrowserStackSecrets")
            .AddUserSecrets($"{ProjectName}_{EnvironmentName}_Secrets")
            .AddUserSecrets("MongoDbSecrets")
            .Build();
        }

        private static IConfigurationRoot InitializeHostingConfig()
        {
            return ConfigurationBuilder()
                .AddJsonFile("appsettings.Environment.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        private static IConfigurationBuilder ConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory());
        }

        private static bool TestsExecutionInVsts()
        {
            return !string.IsNullOrEmpty(GetAgentMachineName());
        }

        private static string GetAgentMachineName()
        {
            return _hostingConfig.GetSection("AGENT_MACHINENAME")?.Value;
        }

        private static string GetEnvironmentName()
        {
            return IsVstsExecution ?
                   _hostingConfig.GetSection("RELEASE_ENVIRONMENTNAME")?.Value :
                   _hostingConfig.GetSection("local_EnvironmentName").Value;
        }
    }
}