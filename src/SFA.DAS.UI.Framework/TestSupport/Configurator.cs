using Microsoft.Extensions.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
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

        internal static PayeAccountDetails GetPayeAccountDetails()
        {
            return config.GetSection(nameof(PayeAccountDetails)).Get<PayeAccountDetails>();
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