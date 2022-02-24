using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EmploymentCheckApiHelper
    {
        protected HttpClient httpClient;
        protected string baseUrl;

        private readonly StopWatchHelper _stopWatchHelper;

        public EmploymentCheckApiHelper(ScenarioContext context)
        {
            var eiConfig = context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>();
            _stopWatchHelper = context.Get<StopWatchHelper>();
            baseUrl = eiConfig.EI_ApiStubBaseUrl;
            httpClient = new HttpClient();
        }

        public async Task SetupPut()
        {
            _stopWatchHelper.Start("SetupEmploymentCheckApiResponse");

            var url = WebUtility.UrlEncode($"/employment-check/RegisterCheck");
            var nullContent = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{baseUrl}/api-stub/save?httpMethod=post&url={url}&httpStatusCode=200", nullContent);
            response.EnsureSuccessStatusCode();

            _stopWatchHelper.Stop("SetupEmploymentCheckApiResponse");
        }

        public async Task DeleteMapping()
        {
            _stopWatchHelper.Start("EmploymentCheckApiDeleteMapping");

            var url = WebUtility.UrlEncode($"/employment-check/RegisterCheck");
            await httpClient.DeleteAsync($"{baseUrl}/api-stub/delete?httpMethod=post&url={url}&httpStatusCode=200");

            _stopWatchHelper.Stop("EmploymentCheckApiApiDeleteMapping");
        }
    }
}
