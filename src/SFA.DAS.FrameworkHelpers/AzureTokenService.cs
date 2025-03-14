using Azure.Core;
using Azure.Identity;
using System.Threading.Tasks;

namespace SFA.DAS.FrameworkHelpers
{
    public static class AzureTokenService
    {
        private static readonly string tenantId = "3aacc835-4b83-483d-841d-cd787f6f1486";  //FCS
        //private static readonly string tenantId = "1a92889b-8ea1-4a16-8132-347814051567"; //CDS

        public static string GetDatabaseAuthToken() => GetAzureToken("https://database.windows.net/").Result;

        public static string GetAppServiceAuthToken(string resource) => GetAzureToken(resource).Result;

        private static async Task<string> GetAzureToken(string resource)
        {
            // Create DefaultAzureCredentialOptions and specify the tenant ID
            var options = new DefaultAzureCredentialOptions
            {
                SharedTokenCacheTenantId = tenantId,
                VisualStudioTenantId = tenantId,
                VisualStudioCodeTenantId = tenantId,
                ManagedIdentityClientId = tenantId,
                InteractiveBrowserTenantId = tenantId,
            };

            var tokenCredential = new DefaultAzureCredential(options);

            var accessToken = await tokenCredential.GetTokenAsync(new TokenRequestContext(scopes: new string[] { resource + "/.default" }) { });

            return accessToken.Token;
        }
    }
}