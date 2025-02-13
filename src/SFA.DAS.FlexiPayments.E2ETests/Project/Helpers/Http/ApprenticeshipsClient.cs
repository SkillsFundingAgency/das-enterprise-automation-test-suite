using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using Newtonsoft.Json;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.Http
{
    internal class ApprenticeshipsClient
    {
        private HttpClient _apiClient;
        private readonly string _functionKey;

        public ApprenticeshipsClient(ScenarioContext context)
        {
            var _config = context.GetPaymentsSimplificationConfig<PaymentsSimplificationConfig>();
            var baseUrl = _config.ApprenticeshipAzureFunctionBaseUrl;

            _apiClient = HttpClientProvider.GetClient(baseUrl);
            _functionKey = _config.ApprenticeshipAzureFunctionKey;
        }

        public async Task WithdrawApprenticeship(WithdrawApprenticeshipRequestBody body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/WithdrawApprenticeship?code={_functionKey}");
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await _apiClient.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"Expected HTTP 200 OK response from Withdrawal request, but got {response.StatusCode}");
        }
    }

    internal class WithdrawApprenticeshipRequestBody
    {
        public long UKPRN { get; set; }
        public string ULN { get; set; }
        public string Reason { get; set; }
        public string ReasonText { get; set; }
        public DateTime LastDayOfLearning { get; set; }
        public string ProviderApprovedBy { get; set; }
    }
}
