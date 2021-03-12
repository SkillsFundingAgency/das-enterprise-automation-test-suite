using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class BusinessCentralApiHelper
    {
        protected HttpClient httpClient;
        protected string baseUrl;

        public BusinessCentralApiHelper(EIConfig config)
        {
            baseUrl = config.EI_ApiStubBaseUrl;
            httpClient = new HttpClient();
        }

        public async Task SetupAcceptAllRequests()
        {
            const string url = "/businesscentral/payments/requests?api-version=2020-10-01";

            var nullContent = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{baseUrl}/api-stub/save?httpMethod=Post&url={WebUtility.UrlEncode(url)}&httpStatusCode=202", nullContent);
            response.EnsureSuccessStatusCode();
        }

    }
}
