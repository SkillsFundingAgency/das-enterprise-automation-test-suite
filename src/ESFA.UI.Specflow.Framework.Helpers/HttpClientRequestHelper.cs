using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.UI.Specflow.Framework.Helpers
{
    public class HttpClientRequestHelper
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<string> ExecuteHttpPostRequest(string requestUri, string postData, string accessToken = "")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(postData, Encoding.UTF8, "application/json")
            };

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var postRequestResponse = await Client.SendAsync(requestMessage);
            var content = await postRequestResponse.Content.ReadAsStringAsync();
            postRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public static async Task<string> ExecuteHttpGetRequest(string requestUri, string accessToken = "")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var getRequestResponse = await Client.SendAsync(requestMessage);
            var content = await getRequestResponse.Content.ReadAsStringAsync();
            getRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public static async Task<string> ExecuteHttpPutRequest(string requestUri, string putData, string accessToken = "")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new StringContent(putData, Encoding.UTF8, "application/json")
            };

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var putRequestResponse = await Client.SendAsync(requestMessage);
            var content = await putRequestResponse.Content.ReadAsStringAsync();
            putRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public static async Task ExecuteHttpDeleteRequest(string requestUri, string deleteData, string accessToken = "")
        {
            HttpRequestMessage requestMessage;
            if (string.IsNullOrEmpty(deleteData))
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri);
            }
            else
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri)
                {
                    Content = new StringContent(deleteData, Encoding.UTF8, "application/json")
                };

                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var deleteRequestResponse = await Client.SendAsync(requestMessage);
                deleteRequestResponse.EnsureSuccessStatusCode();
            }
        }

        public static async Task<string> ExecuteHttpPatchRequest(string requestUri, string patchData, string accessToken = "")
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
            {
                Content = new StringContent(patchData, Encoding.UTF8, "application/json")
            };

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage patchRequestResponse = await Client.SendAsync(requestMessage);
            String content = await patchRequestResponse.Content.ReadAsStringAsync();
            patchRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public static string ConvertTheObjectsToJsonFormat(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}