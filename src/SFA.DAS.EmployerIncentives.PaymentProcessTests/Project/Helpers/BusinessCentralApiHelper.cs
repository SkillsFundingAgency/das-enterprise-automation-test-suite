using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class BusinessCentralApiHelper
    {
        protected HttpClient httpClient;
        protected string baseUrl;
        private readonly StopWatchHelper _stopWatchHelper;

        public BusinessCentralApiHelper(ScenarioContext context)
        {
            var eiConfig = context.GetEIPaymentProcessConfig<EIPaymentProcessConfig>();
            baseUrl = eiConfig.EI_ApiStubBaseUrl;
            httpClient = new HttpClient();
            _stopWatchHelper = context.Get<StopWatchHelper>();
        }

        public async Task AcceptAllPayments()
        {
            _stopWatchHelper.Start("SetupBusinessCentralApiToAcceptAllPayments");

            const string url = "/businesscentral/payments/requests?api-version=2020-10-01";

            var nullContent = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{baseUrl}/api-stub/save?httpMethod=Post&url={WebUtility.UrlEncode(url)}&httpStatusCode=202", nullContent);
            response.EnsureSuccessStatusCode();

            _stopWatchHelper.Stop("SetupBusinessCentralApiToAcceptAllPayments");
        }

    }
}
