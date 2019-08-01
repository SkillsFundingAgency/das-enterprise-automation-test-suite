using Microsoft.Extensions.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.IO;

namespace SFA.DAS.UI.Framework.TestSupport
{
    internal static class Configurator
    {
        internal readonly static IConfigurationRoot config;

        static Configurator()
        {
            config = InitializeConfig();
        }

        internal static string GetBrowser()
        {
            return config.GetSection(nameof(FrameworkConfig.Browser)).Value;
        }

        internal static string GetBaseUrl()
        {
            return config.GetSection(nameof(FrameworkConfig.BaseUrl)).Value;
        }

        internal static TimeOutConfig GetTimeOut()
        {
            return config.GetSection(nameof(TimeOutConfig)).Get<TimeOutConfig>();
        }

        internal static BrowserStackSetting GetBrowserStackSetting()
        {
            return config.GetSection(nameof(BrowserStackSetting)).Get<BrowserStackSetting>();
        }

        private static IConfigurationRoot InitializeConfig()
        {
            var envName = GetEnvironmentName();

            return ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile("appsettings.BrowserStack.json", true)
            .AddJsonFile("appsettings.Project.json", true)
            .AddJsonFile("appsettings.Project.BrowserStack.json", true)
            .AddJsonFile($"appsettings.{envName}.json", true)
            .AddEnvironmentVariables()
            .AddUserSecrets("BrowserStackSecrets")
            .AddUserSecrets($"{envName}Secrets")
            .AddUserSecrets("MongoDbSecrets")
            .Build();
        }

        private static string GetEnvironmentName()
        {
            return ConfigurationBuilder()
                .AddJsonFile("appsettings.Environment.json", true)
                .Build()
                .GetSection("Hosting:Environment").Value;
        }

        private static IConfigurationBuilder ConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory());
        }
    }
}