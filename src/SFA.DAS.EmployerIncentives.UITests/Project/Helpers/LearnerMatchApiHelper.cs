using Newtonsoft.Json;
using SFA.DAS.EmployerIncentives.UITests.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class LearnerMatchApiHelper
    {
        protected HttpClient HttpClient;
        protected string BaseUrl;

        public LearnerMatchApiHelper(EIConfig config)
        {
            BaseUrl = config.EI_ApiStubBaseUrl;
            HttpClient = new HttpClient();
        }

        public async Task SetupResponse(long uln, long ukprn, LearnerSubmissionDto expectedResponse)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(expectedResponse), Encoding.UTF8, "application/json");
            var url = $"/learner-match/api/v1/{ukprn}/{uln}?";
            var response = await HttpClient.PostAsync($"{BaseUrl}/api-stub/save?httpMethod=Get&url={WebUtility.UrlEncode(url)}", stringContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task SetupResponse(long uln, long ukprn, string expectedResponse)
        {
            var url = $"/learner-match/api/v1/{ukprn}/{uln}?";
            var response = await HttpClient.PostAsync($"{BaseUrl}/api-stub/save?httpMethod=Get&url={WebUtility.UrlEncode(url)}", new StringContent(expectedResponse, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
        }
    }
}
