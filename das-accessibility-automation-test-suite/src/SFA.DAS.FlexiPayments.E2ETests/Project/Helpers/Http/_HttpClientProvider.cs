using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.Http
{
    internal static class HttpClientProvider
    {
        private static Dictionary<string, HttpClient> _apiClients = new Dictionary<string, HttpClient>();

        internal static HttpClient GetClient(string baseUrl)
        {
            if (_apiClients.TryGetValue(baseUrl, out var client))
            {
                return client;
            }

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);

            _apiClients.Add(baseUrl, httpClient);

            return httpClient;
        }
    }
}
