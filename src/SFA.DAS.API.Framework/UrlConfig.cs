using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.API.Framework
{
    public static class UrlConfig
    {
        public static string OuterApiBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-gateway.apprenticeships.education.gov.uk/";

        public static string Inner_CommitmentsApiBaseUrl => $"https://{EnvironmentConfig.EnvironmentName}-commitments-api.apprenticeships.education.gov.uk/";

        public static string MangeIdentitybaseUrl(string tenant) => $"https://login.microsoftonline.com/{tenant}/oauth2/token/";
    }
}
