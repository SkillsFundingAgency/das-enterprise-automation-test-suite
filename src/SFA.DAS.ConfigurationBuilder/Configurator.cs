using Microsoft.Extensions.Configuration;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace SFA.DAS.ConfigurationBuilder
{
    public static class Configurator
    {
        private static readonly IConfigurationRoot _config;

        public static readonly bool IsAdoExecution;

        internal static readonly string EnvironmentName;

        private static readonly string ChromeWebDriver;

        private static readonly string GeckoWebDriver;

        private static readonly string EdgeWebDriver;

        private static readonly string ProjectName;

        static Configurator()
        {
            IsAdoExecution = TestPlatformFinder.IsAdoExecution;

            if (IsAdoExecution)
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
                .AddMandatoryJsonFiles(
                [
                    "Config",
                    "AdminConfig",
                    "ProviderConfig",
                    "TimeOutConfig",
                    "TestExecution",
                    "NServiceBusConfig",
                    "BrowserStack",
                    "ApiFramework"
                ])
                .AddProjectJsonFiles(
                [
                    "Project"
                ]);

            if (!IsAdoExecution)
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

        private static IConfigurationBuilder AddMandatoryJsonFiles(this IConfigurationBuilder builder, List<string> files)
        {
            foreach (var file in files)
            {
                var path = FileHelper.GetSingleConfigJson(file);

                builder.AddJsonFile(path, false);
            }

            return builder;
        }

        private static IConfigurationBuilder AddProjectJsonFiles(this IConfigurationBuilder builder, List<string> files)
        {
            foreach (var file in files)
            {
                var path = FileHelper.GetProjectConfigJson(file);

                builder.AddJsonFile(path, true);
            }

            return builder;
        }

        private static (string environmentName, string ProjectName) GetLocalHostingConfig()
        {
            var builder = ConfigurationBuilder().AddJsonFile($"{FileHelper.GetLocalSettingsFilePath("appsettings.Environment.json")}").Build();

            var e = builder.GetSection("local_EnvironmentName").Value;

            var p = builder.GetSection("ProjectName").Value;

            return (e, p);
        }

        private static IConfigurationBuilder ConfigurationBuilder() => new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

        public static string GetDeploymentRequestedFor() => Environment.GetEnvironmentVariable("RELEASE_DEPLOYMENT_REQUESTEDFOR");
    }
}