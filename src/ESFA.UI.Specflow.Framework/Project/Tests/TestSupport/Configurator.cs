using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    public static class Configurator
    {
        private readonly static IConfigurationRoot _config;

        static Configurator()
        {
            _config = InitializeConfig();
        }

        public static string GetBrowser()
        {
            return _config.GetSection(nameof(JsonConfig.Browser)).Value;
        }

        public static string GetBaseUrl()
        {
            return _config.GetSection(nameof(JsonConfig.BaseUrl)).Value;
        }

        private static IConfigurationRoot InitializeConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.Development.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        internal static class JsonConfig
        {
            internal static string BaseUrl;

            internal static string Browser;
        }
    }   
}