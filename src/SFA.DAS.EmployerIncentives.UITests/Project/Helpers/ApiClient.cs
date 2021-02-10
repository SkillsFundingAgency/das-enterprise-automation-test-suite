using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SFA.DAS.Api.Common.Infrastructure;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class ApiClient
    {
        private HttpClient _httpClient;
        private EIConfig _configuration;
        private AzureClientCredentialHelper _azureClientCredentialHelper;

        public ApiClient(EIConfig config)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(config.EI_ApiBaseUrl);
            _configuration = config;
            _azureClientCredentialHelper = new AzureClientCredentialHelper();
        }

        public async Task Post<TData>(string url, TData data)
        {
            await AddAuthenticationHeader();

            var stringContent = data != null ? new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json") : null;

            var response = await _httpClient.PostAsync(url, stringContent)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        public async Task Patch<TData>(string url, TData data)
        {
            await AddAuthenticationHeader();

            var stringContent = data != null ? new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json") : null;

            var response = await _httpClient.PatchAsync(url, stringContent)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        private async Task AddAuthenticationHeader()
        {
            var accessToken = await _azureClientCredentialHelper.GetAccessTokenAsync(_configuration.EI_ApiIdentifier);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
