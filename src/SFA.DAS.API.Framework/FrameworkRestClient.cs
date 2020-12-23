using RestSharp;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework
{
    public class FrameworkRestClient
    {
        private RestClient _restClient;

        private RestRequest _restRequest;

        public FrameworkRestClient(string baseurl) => CreateRestClient(baseurl);

        public void CreateGetRestRequest(string resource)
        {
            _restRequest.Method = Method.GET;
            _restRequest.Resource = resource;
        }

        public void Addheaders(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                _restRequest.AddHeader(item.Key, item.Value);
            }
        }

        public IRestResponse Execute() => _restClient.Execute(_restRequest);

        private void CreateRestClient(string baseurl)
        {
            _restClient = new RestClient(baseurl);

            _restRequest = new RestRequest();
        }
    }
}
