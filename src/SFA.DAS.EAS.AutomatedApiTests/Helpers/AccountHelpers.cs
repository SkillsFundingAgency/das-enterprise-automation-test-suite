using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SFA.DAS.EAS.AutomatedApiTests.Helpers
{
    /// <summary>
    /// This helpers will need to be updated as it's predicated that there will be database 
    /// setup and tear down to allow for tests to be run consistently.
    /// </summary>
    public static class AccountHelpers
    {
        public static string GetHashedAccountId()
        {
            return ConfigurationHelper.Instance.Configuration["HashedAccountId"];
        }

        public async static Task<HttpClient> GetAccountRestClient()
        {
            var tenant = ConfigurationHelper.Instance.Configuration["Tenant"];
            var identifierUri = ConfigurationHelper.Instance.Configuration["IdentifierUri"];
            var clientId = ConfigurationHelper.Instance.Configuration["ClientId"];
            var clientSecret = ConfigurationHelper.Instance.Configuration["ClientSecret"];
            var apiBaseUrl = ConfigurationHelper.Instance.Configuration["ApiBaseUrl"];

            var client = new HttpClient();
            client.BaseAddress = new Uri(apiBaseUrl);
            var authenticationResult = await AuthenticationHelper.GetAuthenticationResult(clientId, clientSecret, identifierUri, tenant);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
            return client;
        }
    }
}
