using RestSharp;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class BaseApiRestClient
    {
        protected RestClient _restClient;

        protected RestRequest _restRequest;

        public abstract void CreateRestRequest(Method method, string resource, string payload);

        public void Addheaders(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                _restRequest.AddHeader(item.Key, item.Value);
            }
        }

        public IRestResponse Execute() => _restClient.Execute(_restRequest);

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
