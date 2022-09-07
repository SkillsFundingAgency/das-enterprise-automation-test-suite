using SFA.DAS.FrameworkHelpers;
using System.Text.RegularExpressions;

namespace SFA.DAS.ConfigurationBuilder
{
    public static class EnvironmentConfig
    {
        public static string EnvironmentName => Configurator.EnvironmentName;

        public static bool IsATEnvironment => EnvironmentName.CompareToIgnoreCase("at");

        public static bool IsTestEnvironment => EnvironmentName.CompareToIgnoreCase("test");

        public static bool IsTest2Environment => EnvironmentName.CompareToIgnoreCase("test2");

        public static bool IsPPEnvironment => EnvironmentName.CompareToIgnoreCase("pp");

        public static bool IsDemoEnvironment => EnvironmentName.CompareToIgnoreCase("demo");

        public static string ReplaceEnvironmentName(string x) => Regex.Replace(x, "{environmentname}", EnvironmentName.ToLower());
    }
}