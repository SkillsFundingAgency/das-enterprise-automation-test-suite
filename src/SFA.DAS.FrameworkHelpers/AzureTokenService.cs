using Microsoft.Azure.Services.AppAuthentication;

namespace SFA.DAS.FrameworkHelpers
{
    public static class AzureTokenService
    {
        public static string GetDatabaseAuthToken() => GetAzureToken("https://database.windows.net/");

        public static string GetAppServiceAuthToken(string resource) => GetAzureToken(resource);

        private static string GetAzureToken(string resource) => new AzureServiceTokenProvider().GetAccessTokenAsync(resource).Result;
    }
}