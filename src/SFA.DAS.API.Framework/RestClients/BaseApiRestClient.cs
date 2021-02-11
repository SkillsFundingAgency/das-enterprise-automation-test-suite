using RestSharp;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class BaseApiRestClient
    {
        protected RestClient _restClient;

        protected RestRequest _restRequest;

        public abstract void CreateRestRequest(Method method, string resource, string payload);

        public IRestResponse Execute() => _restClient.Execute(_restRequest);

        protected void Addheader(string key, string value) => _restRequest.AddHeader(key, value);

        protected void Addheaders(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                Addheader(item.Key, item.Value);
            }
        }

        protected void AddPayload(string payload)
        {
            if (!string.IsNullOrEmpty(payload))
            {
                if (payload.EndsWith(".json")) { _restRequest.AddJsonBody(JsonHelper.ReadAllText(payload)); }

                else { _restRequest.AddJsonBody(payload); }
            }
        }
    }
}
