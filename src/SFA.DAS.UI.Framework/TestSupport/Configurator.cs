using Microsoft.Extensions.Configuration;
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

        internal static TimeOut GetTimeOut()
        {
            return config.GetSection(nameof(TimeOut)).Get<TimeOut>();
        }

        internal static BrowserStackSetting GetBrowserStackSetting()
        {
            return config.GetSection(nameof(BrowserStackSetting)).Get<BrowserStackSetting>();
        }

        private static IConfigurationRoot InitializeConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.BrowserStack.json", true)
                .AddJsonFile("appsettings.Development.json", true)
                .AddJsonFile("appsettings.TestProject.BrowserStack.json", true)
                .AddEnvironmentVariables()
                .AddUserSecrets("BrowserStackSecrets")
                .AddUserSecrets("TestProjectSecrets")
                .AddUserSecrets("MongoDbSecrets")
                .Build();
        }
    }
}