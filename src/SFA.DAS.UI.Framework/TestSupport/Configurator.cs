using Microsoft.Extensions.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.IO;

namespace SFA.DAS.UI.Framework.TestSupport
{
    internal static class Configurator
    {
        private readonly static IConfigurationRoot _config;

        private readonly static IConfigurationRoot _hostingConfig;

        static Configurator()
        {
            _hostingConfig = InitializeHostingConfig();
            _config = InitializeConfig();
        }

        internal static IConfigurationRoot GetConfig()
        {
            return _config;
        }

        internal static TimeOutConfig GetTimeOut()
        {
            return _config.GetSection(nameof(TimeOutConfig)).Get<TimeOutConfig>();
        }

        internal static BrowserStackSetting GetBrowserStackSetting()
        {
            return _config.GetSection(nameof(BrowserStackSetting)).Get<BrowserStackSetting>();
        }

        internal static HostingConfig GetHostingConfig()
        {
            return _hostingConfig.GetSection(nameof(HostingConfig)).Get<HostingConfig>();
        }

        private static IConfigurationRoot InitializeConfig()
        {
            var host = GetHostingConfig();

            return ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile("appsettings.BrowserStack.json", true)
            .AddJsonFile("appsettings.Project.json", true)
            .AddJsonFile("appsettings.Project.BrowserStack.json", true)
            .AddJsonFile($"appsettings.{host?.EnvironmentName}.json", true)
            .AddEnvironmentVariables()
            .AddUserSecrets("BrowserStackSecrets")
            .AddUserSecrets($"{host?.ProjectName}_{host?.EnvironmentName}_Secrets")
            .AddUserSecrets("MongoDbSecrets")
            .Build();
        }

        private static IConfigurationRoot InitializeHostingConfig()
        {
            return ConfigurationBuilder()
                .AddJsonFile("appsettings.Environment.json", true)
                .Build();
        }

        private static IConfigurationBuilder ConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory());
        }
    }
}