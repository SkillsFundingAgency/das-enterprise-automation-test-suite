using Azure.Core;
using Azure.Identity;
using System.Threading.Tasks;

namespace SFA.DAS.FrameworkHelpers
{
    public static class AzureTokenService
    {
        public static string GetDatabaseAuthToken() => GetAzureToken("https://database.windows.net/").Result;

        public static string GetAppServiceAuthToken(string resource) => GetAzureToken(resource).Result;

        private static async Task<string> GetAzureToken(string resource)
        {
            var tokenCredential = new DefaultAzureCredential();

            var accessToken = await tokenCredential.GetTokenAsync(new TokenRequestContext(scopes: new string[] { resource + "/.default" }) { });

            return accessToken.Token;
        }
    }
}