using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public abstract class EIFunctionAppHelper
    {
        protected OrchestratorStartResponse OrchestratorStartResponse;
        protected HttpClient HttpClient;
        protected string BaseUrl;
        protected string AuthenticationCode;

        protected EIFunctionAppHelper(EIConfig config)
        {
            BaseUrl = config.EI_PaymentsAppBaseUrl;
            AuthenticationCode = config.EI_PaymentsAppCode;
            HttpClient = new HttpClient();
        }

        protected async Task StartOrchestrator(string path)
        {
            var response = await HttpClient.GetAsync($"{BaseUrl}/{path}?code={AuthenticationCode}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Unsuccessful request - {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            OrchestratorStartResponse = JsonConvert.DeserializeObject<OrchestratorStartResponse>(json);
        }

        protected async Task CallHttpTrigger(string path)
        {
            var response = await HttpClient.GetAsync($"{BaseUrl}/{path}?code={AuthenticationCode}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }

        protected async Task WaitUntilStatus(string status, TimeSpan? timeout)
        {
            await WaitUntil(x => x.RuntimeStatus == status, timeout);
        }

        protected async Task WaitUntilCustomStatus(string customStatus, TimeSpan? timeout)
        {
            await WaitUntil(x => x.CustomStatus == customStatus, timeout);
        }

        private async Task WaitUntil(Func<OrchestratorStatusResponse, bool> comparison, TimeSpan? timeout)
        {
            using var cts = new CancellationTokenSource();
            if (timeout != null)
            {
                cts.CancelAfter(timeout.Value);
            }

            while (!cts.Token.IsCancellationRequested)
            {
                var response = await HttpClient.GetAsync(OrchestratorStartResponse.StatusQueryGetUri);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var orchestratorStatusResponse = JsonConvert.DeserializeObject<OrchestratorStatusResponse>(json);
                if (comparison(orchestratorStatusResponse))
                {
                    return;
                }

                await Task.Delay(TimeSpan.FromMilliseconds(100));
            }
        }
    }
}
