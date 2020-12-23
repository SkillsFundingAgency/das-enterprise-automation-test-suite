using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.API.Framework
{
    public static class UrlConfig
    {
        public static string FATV2_BaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-gateway.apprenticeships.education.gov.uk/";
    }
}
