using Newtonsoft.Json;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EIFunctionsHelper
    {
        protected HttpClient httpClient;
        protected string baseUrl;

        public EIFunctionsHelper(EIPaymentProcessConfig config)
        {
            baseUrl = config.EI_FunctionsBaseUrl;
            httpClient = new HttpClient();
        }

        public async Task Withdraw(long uln, long accountLegalEntityId, WithdrawalType withdrawalType)
        {
            var request = new WithdrawRequest
            {
                WithdrawalType = withdrawalType,
                ULN = uln,
                AccountLegalEntityId = accountLegalEntityId
            };

            var response = await httpClient.PostAsync($"{baseUrl}/api/withdraw", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public class WithdrawRequest
        {
            public WithdrawalType WithdrawalType { get; set; }
            public long AccountLegalEntityId { get; set; }
            public long ULN { get; set; }
        }
    }
}
