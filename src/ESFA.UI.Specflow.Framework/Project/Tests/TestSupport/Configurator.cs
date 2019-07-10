using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Specialized;
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

        public static string GetBrowserstackServerName()
        {
            return _config.GetSection(nameof(JsonConfig.BrowserstackServerName)).Value;

        }
        public static string GetBrowserstackUsername()
        {
            return _config.GetSection(nameof(JsonConfig.BrowserstackUsername)).Value;

        }

        public static string GetBrowserstackPassword()
        {
            return _config.GetSection(nameof(JsonConfig.BrowserstackPassword)).Value;
        }

        public static string GetBrowserstackBrowser()
        {
            return _config.GetSection(nameof(JsonConfig.BrowserstackBrowser)).Value;
        }

        public static string GetBrowserstackOs()
        {
            return _config.GetSection(nameof(JsonConfig.Os)).Value;

        }

        public static string GetBrowserstackProject()
        {
            return _config.GetSection(nameof(JsonConfig.BrowserstackProjectName)).Value;
        }

        public static string GetResolution()
        {
            return _config.GetSection(nameof(JsonConfig.Resolution)).Value;

        }

        public static string GetBrowserstackbrowserVersion()
        {
            return _config.GetSection(nameof(JsonConfig.BrowserstackBrowserVersion)).Value;
        }

        public static string GetBrowserstackOsversion()
        {
            return _config.GetSection(nameof(JsonConfig.OsVersion)).Value;
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

            internal static string BrowserstackUsername;

            internal static string BrowserstackPassword;

            internal static string BrowserstackBrowser;

            internal static string BrowserstackServerName;

            internal static string BrowserstackProjectName;

            internal static string Os;

            internal static string OsVersion;

            internal static string BrowserstackBrowserVersion;

            internal static string Resolution;
        }
    }
}