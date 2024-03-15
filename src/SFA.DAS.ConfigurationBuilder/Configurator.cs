using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SFA.DAS.ConfigurationBuilder
{
    public static class Configurator
    {
        private static readonly IConfigurationRoot _config;

        public static readonly bool IsAzureExecution;

        internal static readonly string EnvironmentName;

        private static readonly string ChromeWebDriver;

        private static readonly string GeckoWebDriver;

        private static readonly string EdgeWebDriver;

        private static readonly string ProjectName;

        static Configurator()
        {
            IsAzureExecution = TestsExecutionInAzure();

            if (IsAzureExecution) 
            {
                ChromeWebDriver = Environment.GetEnvironmentVariable("CHROMEWEBDRIVER");
                GeckoWebDriver = Environment.GetEnvironmentVariable("GECKOWEBDRIVER");
                EdgeWebDriver = Environment.GetEnvironmentVariable("EDGEWEBDRIVER");
                EnvironmentName = Environment.GetEnvironmentVariable("ResourceEnvironmentName");
            }
            else
            {
                (EnvironmentName, ProjectName) = GetLocalHostingConfig();
            }
            _config = InitializeConfig();
        }

        public static (string chromeWebDriver, string geckoWebDriver, string edgeWebDriver) GetDriverLocation() => (ChromeWebDriver, GeckoWebDriver, EdgeWebDriver);

        internal static IConfigurationRoot GetConfig() => _config;

        private static IConfigurationRoot InitializeConfig()
        {
            var builder = ConfigurationBuilder()
                .AddOptionalJsonFiles(
                [
                    "appsettings.Config.json",
                    "appsettings.TimeOutConfig.json",
                    "appsettings.NServiceBusConfig.json",
                    "appsettings.BrowserStack.json",
                    "appsettings.MailosaurApi.json",
                    "appsettings.ApiFramework.json",
                    "appsettings.AdminConfig.json",
                    "appsettings.ProviderConfig.json",
                    "appsettings.Project.json",
                    "appsettings.Project.BrowserStack.json",
                    $"appsettings.{EnvironmentName}.json",
                    "appsettings.TestExecution.json"
                ]);

            if (!IsAzureExecution)
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

        private static (string environmentName, string ProjectName) GetLocalHostingConfig()
        {
            var builder = ConfigurationBuilder().AddJsonFile($"{GetSettingsFilePath("appsettings.Environment.json")}").Build();

            var e = builder.GetSection("local_EnvironmentName").Value;

            var p = builder.GetSection("ProjectName").Value;

            return (e, p);
        }

        private static IConfigurationBuilder ConfigurationBuilder() => new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

        private static bool TestsExecutionInAzure() => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AGENT_MACHINENAME"));

        public static string GetDeploymentRequestedFor() => Environment.GetEnvironmentVariable("RELEASE_DEPLOYMENT_REQUESTEDFOR");

        private static string GetSettingsFilePath(string fileName) => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"..\..\..\{fileName}");
    }
}