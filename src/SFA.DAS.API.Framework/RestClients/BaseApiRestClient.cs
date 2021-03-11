using RestSharp;
using SFA.DAS.API.Framework.Helpers;
using System.Collections.Generic;
using System.Net;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class BaseApiRestClient
    {
        protected RestClient restClient;

        protected RestRequest restRequest;

        protected abstract void AddResource(string resource);

        protected abstract void AddAuthHeaders();

        public void CreateRestRequest(Method method, string resource, string payload)
        {
            restRequest.Method = method;

            AddResource(resource);

            restRequest.Parameters.Clear();

            AddAuthHeaders();

            if (!string.IsNullOrEmpty(payload))
            {
                if (payload.EndsWith(".json")) { restRequest.AddJsonBody(JsonHelper.ReadAllText(payload)); }

                else { restRequest.AddJsonBody(payload); }
            }
        }

        public IRestResponse Execute(HttpStatusCode expectedResponse)
        {
            var _restResponse = restClient.Execute(restRequest);

            AssertHelper.AssertResponse(expectedResponse, _restResponse);

            return _restResponse;
        }

        protected IRestResponse Execute<T>(Method method, string resource, T payload, HttpStatusCode expectedResponse)
        {
            CreateRestRequest(method, resource, JsonHelper.Serialize(payload));

            return Execute(expectedResponse);
        }

        protected IRestResponse Execute(string resource, HttpStatusCode expectedResponse) => Execute(Method.GET, resource, string.Empty, expectedResponse);

        protected void Addheader(string key, string value) => restRequest.AddHeader(key, value);

        protected void Addheaders(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                Addheader(item.Key, item.Value);
            }
        }
    }
}
