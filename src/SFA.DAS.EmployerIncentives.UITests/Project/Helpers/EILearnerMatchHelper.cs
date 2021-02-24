using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EILearnerMatchHelper : EIFunctionAppHelper
    {
        public EILearnerMatchHelper(EIConfig config) : base(config)
        {
            BaseUrl = config.EI_PaymentsAppBaseUrl;
            AuthenticationCode = config.EI_PaymentsAppCode;
            HttpClient = new HttpClient();
        }

        public async Task StartLearnerMatchOrchestrator()
        {
            await StartOrchestrator("api/orchestrators/LearnerMatchingOrchestrator");
        }

        public async Task WaitUntilComplete(TimeSpan? timeout)
        {
            await WaitUntilStatus("Completed", timeout);
        }
    }
}
