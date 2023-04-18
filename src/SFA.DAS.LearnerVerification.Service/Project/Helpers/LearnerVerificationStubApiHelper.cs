using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SFA.DAS.LearnerVerification.Service.Project.Helpers.Models;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers
{
    public class LearnerVerificationStubApiHelper
    {
        protected HttpClient httpClient;
        protected string baseUrl;

        public LearnerVerificationStubApiHelper(ScenarioContext context)
        {
            var lvConfig = context.GetLearnerVerificationProcessConfig<LearnerVerificationConfig>();
            baseUrl = lvConfig.LV_ApiStubBaseUrl;
            httpClient = new HttpClient();
        }

        public async Task SetupOkResponse(LearnerVerificationParameters parameters, LearnerVerificationResponse expectedResponse)
        {
            await SetupResponseWithHttpStatusCode(parameters, JsonConvert.SerializeObject(expectedResponse), HttpStatusCode.OK);
        }

        public async Task SetupServerErrorResponse(LearnerVerificationParameters parameters)
        {
            await SetupResponseWithHttpStatusCode(parameters, "{}", HttpStatusCode.InternalServerError);
        }

        public async Task SetupResponseWithHttpStatusCode(LearnerVerificationParameters parameters, string expectedResponse, HttpStatusCode statusCode)
        {
            var stringContent = new StringContent(expectedResponse, Encoding.UTF8, "application/json");
            string url = ConstructEncodedApiUrl(parameters);
            var response = await httpClient.PostAsync($"{baseUrl}/api-stub/save?httpMethod=Get&url={url}&httpStatusCode={(int)statusCode}", stringContent);
            response.EnsureSuccessStatusCode();
        }

        private static string ConstructEncodedApiUrl(LearnerVerificationParameters parameters)
        {
            var url = WebUtility.UrlEncode($"/api/learnerdetails/verify?uln={parameters.Uln}&firstName={parameters.FirstName}&lastName={parameters.LastName}");
            if (parameters.Gender != null)
            {
                url += $"&gender={parameters.Gender}";
            }
            if (parameters.DateOfBirth != null)
            {
                url += $"&dateOfBirth={parameters.DateOfBirth?.ToString("yyyy-MM-dd")}";
            }
            var urlEncoded = WebUtility.UrlEncode(url);
            return urlEncoded;
        }

        public async Task DeleteMapping(LearnerVerificationParameters parameters)
        {
            string url = ConstructEncodedApiUrl(parameters);
            var response = await httpClient.DeleteAsync($"{baseUrl}/api-stub/delete?httpMethod=Get&url={url}");
            response.EnsureSuccessStatusCode();
        }
    }
}