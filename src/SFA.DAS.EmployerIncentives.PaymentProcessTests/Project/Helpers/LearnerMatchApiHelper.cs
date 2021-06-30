using Newtonsoft.Json;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class LearnerMatchApiHelper
    {
        protected HttpClient httpClient;
        protected string baseUrl;

        public LearnerMatchApiHelper(EIPaymentProcessConfig config)
        {
            baseUrl = config.EI_ApiStubBaseUrl;
            httpClient = new HttpClient();
        }

        public async Task SetupResponse(long uln, long ukprn, LearnerSubmissionDto expectedResponse)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(expectedResponse), Encoding.UTF8, "application/json");
            var url = WebUtility.UrlEncode($"/learner-match/api/v1/{ukprn}/{uln}?");
            var response = await httpClient.PostAsync($"{baseUrl}/api-stub/save?httpMethod=Get&url={url}", stringContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task SetupResponse(long uln, long ukprn, string expectedResponse)
        {
            var url = WebUtility.UrlEncode($"/learner-match/api/v1/{ukprn}/{uln}?");
            var response = await httpClient.PostAsync($"{baseUrl}/api-stub/save?httpMethod=Get&url={url}", new StringContent(expectedResponse, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMapping(long uln, long ukprn)
        {
            var url = WebUtility.UrlEncode($"/learner-match/api/v1/{ukprn}/{uln}?");
            var response = await httpClient.DeleteAsync($"{baseUrl}/api-stub/delete?httpMethod=Get&url={url}");
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            } 
        }
    }
}
