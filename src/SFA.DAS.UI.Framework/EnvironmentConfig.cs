using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework
{
    public static class EnvironmentConfig
    {
        public static string EnvironmentName = Configurator.EnvironmentName;

        public static bool IsATEnvironment = EnvironmentName.CompareToIgnoreCase("at");

        public static bool IsTestEnvironment = EnvironmentName.CompareToIgnoreCase("test");

        public static bool IsTest2Environment = EnvironmentName.CompareToIgnoreCase("test2");

        public static bool IsPPEnvironment = EnvironmentName.CompareToIgnoreCase("pp");
    }
}
