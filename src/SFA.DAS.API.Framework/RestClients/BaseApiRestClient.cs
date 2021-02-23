using RestSharp;
using SFA.DAS.API.Framework.Helpers;
using System.Collections.Generic;

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

        public IRestResponse Execute() => restClient.Execute(restRequest);

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
