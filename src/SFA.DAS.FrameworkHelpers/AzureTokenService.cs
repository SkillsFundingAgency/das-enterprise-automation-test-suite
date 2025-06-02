using Azure.Core;
using Azure.Identity;
using System.Threading.Tasks;

namespace SFA.DAS.FrameworkHelpers
{
    public static class AzureTokenService
    {
        //private static readonly string tenantId = "3aacc835-4b83-483d-841d-cd787f6f1486";  //FCS
        //private static readonly string tenantId = "1a92889b-8ea1-4a16-8132-347814051567"; //CDS

        public static string GetDatabaseAuthToken(string tenantid) => GetAzureToken("https://database.windows.net/", tenantid).Result;

        public static string GetDatabaseAuthToken() => GetAzureToken("https://database.windows.net/").Result;

        public static string GetAppServiceAuthToken(string resource) => GetAzureToken(resource).Result;

        private static async Task<string> GetAzureToken(string resource, string tenantid)
        {
            // Create DefaultAzureCredentialOptions and specify the tenant ID
            var options = new DefaultAzureCredentialOptions
            {
                SharedTokenCacheTenantId = tenantid,
                VisualStudioTenantId = tenantid,
                VisualStudioCodeTenantId = tenantid,
                ManagedIdentityClientId = tenantid,
                InteractiveBrowserTenantId = tenantid,
            };

            var tokenCredential = new DefaultAzureCredential(options);

            var accessToken = await tokenCredential.GetTokenAsync(new TokenRequestContext(scopes: new string[] { resource + "/.default" }) { });

            return accessToken.Token;
        }

        private static async Task<string> GetAzureToken(string resource)
        {
            var tokenCredential = new DefaultAzureCredential();

            var accessToken = await tokenCredential.GetTokenAsync(new TokenRequestContext(scopes: new string[] { resource + "/.default" }) { });

            return accessToken.Token;
        }
    }
}