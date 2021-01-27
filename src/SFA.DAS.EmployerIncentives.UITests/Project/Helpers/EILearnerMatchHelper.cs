using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EILearnerMatchHelper
    {
        private OrchestratorStartResponse _orchestratorStartResponse;
        private HttpClient _httpClient;
        private string _baseUrl;
        private string _authenticationCode;

        public EILearnerMatchHelper(EIConfig config)
        {
            _baseUrl = config.EI_PaymentsAppBaseUrl;
            _authenticationCode = config.EI_PaymentsAppCode;
            _httpClient = new HttpClient();
        }

        public async Task StartLearnerMatchOrchestrator()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/orchestrators/LearnerMatchingOrchestrator?code={_authenticationCode}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            _orchestratorStartResponse = JsonConvert.DeserializeObject<OrchestratorStartResponse>(json);
        }

        public async Task WaitUntilComplete(TimeSpan? timeout)
        {
            using var cts = new CancellationTokenSource();
            if (timeout != null)
            {
                cts.CancelAfter(timeout.Value);
            }

            while (!cts.Token.IsCancellationRequested)
            {
                var response = await _httpClient.GetAsync(_orchestratorStartResponse.StatusQueryGetUri);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orchestratorStatusResponse = JsonConvert.DeserializeObject<OrchestratorStatusResponse>(json);
                if (orchestratorStatusResponse.RuntimeStatus == "Completed")
                {
                    return;
                }

                await Task.Delay(TimeSpan.FromMilliseconds(100));
            }
        }
    }
}
