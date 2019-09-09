using Microsoft.Extensions.Configuration;
using System;

namespace SFA.DAS.EAS.AutomatedApiTests.Helpers
{
    public class ConfigurationHelper
    {
        public IConfiguration Configuration;
        private ConfigurationHelper(string outputPath)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        private static ConfigurationHelper instance;
        public static ConfigurationHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationHelper(Environment.CurrentDirectory);
                }
                return instance;
            }
        }
    }
}
