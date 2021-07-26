using Newtonsoft.Json;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class LearnerMatchApiHelper
    {
        protected HttpClient httpClient;
        protected string baseUrl;

        private readonly StopWatchHelper _stopWatchHelper;

        public LearnerMatchApiHelper(ScenarioContext context)
        {
            var eiConfig = context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>();
            _stopWatchHelper = context.Get<StopWatchHelper>();
            baseUrl = eiConfig.EI_ApiStubBaseUrl;
            httpClient = new HttpClient();
        }

        public async Task SetupResponse(long uln, long ukprn, LearnerSubmissionDto expectedResponse)
        {
            _stopWatchHelper.Start("SetupLearnerMatchApiResponse");

            var stringContent = new StringContent(JsonConvert.SerializeObject(expectedResponse), Encoding.UTF8, "application/json");
            var url = WebUtility.UrlEncode($"/learner-match/api/v1/{ukprn}/{uln}?");
            var response = await httpClient.PostAsync($"{baseUrl}/api-stub/save?httpMethod=Get&url={url}", stringContent);
            response.EnsureSuccessStatusCode();

            _stopWatchHelper.Stop("SetupLearnerMatchApiResponse");
        }

        public async Task SetupResponse(long uln, long ukprn, string expectedResponse)
        {
            _stopWatchHelper.Start("SetupLearnerMatchApiResponse");

            var url = WebUtility.UrlEncode($"/learner-match/api/v1/{ukprn}/{uln}?");
            var response = await httpClient.PostAsync($"{baseUrl}/api-stub/save?httpMethod=Get&url={url}", new StringContent(expectedResponse, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            _stopWatchHelper.Stop("SetupLearnerMatchApiResponse");
        }

        public async Task DeleteMapping(long uln, long ukprn)
        {
            _stopWatchHelper.Start("LearnerMatchApiDeleteMapping");

            var url = WebUtility.UrlEncode($"/learner-match/api/v1/{ukprn}/{uln}?");
            await httpClient.DeleteAsync($"{baseUrl}/api-stub/delete?httpMethod=Get&url={url}");

            _stopWatchHelper.Stop("LearnerMatchApiDeleteMapping");
        }
    }
}
