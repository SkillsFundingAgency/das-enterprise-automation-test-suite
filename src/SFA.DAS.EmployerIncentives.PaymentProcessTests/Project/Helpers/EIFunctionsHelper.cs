using Newtonsoft.Json;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EIFunctionsHelper(EIPaymentProcessConfig config)
    {
        protected HttpClient httpClient = new();
        protected string baseUrl = config.EI_FunctionsBaseUrl;
        public string AuthenticationCode { get; set; } = config.EI_FunctionsAppCode;

        public async Task Withdraw(long uln, long accountLegalEntityId, WithdrawalType withdrawalType)
        {
            var request = new WithdrawRequest
            {
                WithdrawalType = withdrawalType,
                Applications =
                [
                    new()
                    {
                        AccountLegalEntityId = accountLegalEntityId,
                        ULN = uln
                    }
                ],
                ServiceRequest = new ServiceRequest { TaskId = "AUTOMATED", DecisionReference = "TESTS", TaskCreatedDate = DateTime.Now }
            };

            var jsonRequest = JsonConvert.SerializeObject(request);

            var response = await httpClient.PostAsync($"{baseUrl}/api/withdraw?code={AuthenticationCode}", new StringContent(jsonRequest, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task Reinstate(long uln, long accountLegalEntityId)
        {
            var request = new ReinstateApplicationRequest
            {
                Applications =
                [
                    new()
                    {
                        AccountLegalEntityId = accountLegalEntityId,
                        ULN = uln,
                        ServiceRequest = new ServiceRequest
                        { TaskId = "AUTOMATED", DecisionReference = "TESTS", TaskCreatedDate = DateTime.Now }
                    }
                ]
            };
            var response = await httpClient.PostAsync($"{baseUrl}/api/reinstate?code={AuthenticationCode}", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task TriggerEmploymentCheck(long accountLegalEntityId, long uln)
        {
            var request = new EmploymentCheckRequest
            {
                CheckType = RefreshEmploymentCheckType.InitialEmploymentChecks.ToString(),
                Applications =
                    [
                        new()
                        {
                            ULN = uln,
                            AccountLegalEntityId = accountLegalEntityId
                        }
                    ],
                ServiceRequest = new ServiceRequest
                {
                    DecisionReference = "ABC123",
                    TaskCreatedDate = DateTime.Now,
                    TaskId = "ZZZ999"
                }
            };
            var requests = new List<EmploymentCheckRequest> { request };

            var response = await httpClient.PostAsync($"{baseUrl}/api/employmentchecks?code={AuthenticationCode}", new StringContent(JsonConvert.SerializeObject(requests), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public class Application
        {
            public long AccountLegalEntityId { get; set; }
            public long ULN { get; set; }
            public ServiceRequest ServiceRequest { get; set; }
        }

        public class WithdrawRequest
        {
            public WithdrawalType WithdrawalType { get; set; }
            public Application[] Applications { get; set; }
            public ServiceRequest ServiceRequest { get; set; }
        }

        public class ReinstateApplicationRequest
        {
            public Application[] Applications { get; set; }
        }

        public class EmploymentCheckRequest
        {
            public string CheckType { get; set; }
            public List<Application> Applications { get; set; }
            public ServiceRequest ServiceRequest { get; set; }
        }

        public enum RefreshEmploymentCheckType
        {
            InitialEmploymentChecks,
            EmployedAt365DaysCheck
        }

        public class ServiceRequest
        {
            public string TaskId { get; set; }
            public string DecisionReference { get; set; }
            public DateTime? TaskCreatedDate { get; set; }
        }
    }
}
