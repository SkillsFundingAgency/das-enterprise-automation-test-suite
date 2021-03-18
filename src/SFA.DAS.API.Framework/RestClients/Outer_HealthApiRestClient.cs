using RestSharp;
using SFA.DAS.API.Framework.Helpers;
using System.Net;

namespace SFA.DAS.API.Framework.RestClients
{
    public class Outer_HealthApiRestClient
    {
        private readonly string _baseUrl;

        public Outer_HealthApiRestClient(string baseurl) => _baseUrl = baseurl;

        public IRestResponse Ping(HttpStatusCode expectedResponse) => Execute($"/ping", expectedResponse);

        public IRestResponse CheckHealth(HttpStatusCode expectedResponse) => Execute($"/health", expectedResponse);

        private IRestResponse Execute(string resource, HttpStatusCode expectedResponse)
        {
            var restResponse = new RestClient(_baseUrl)
                .Execute(
                new RestRequest
                {
                    Method = Method.GET,
                    Resource = resource
                });

            AssertHelper.AssertResponse(expectedResponse, restResponse);

            return restResponse;
        }
    }
}
