using System;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EILearnerMatchHelper(EIPaymentProcessConfig config) : EIFunctionAppHelper(config)
    {
        public async Task StartLearnerMatchOrchestrator()
        {
            await StartOrchestrator("api/orchestrators/LearnerMatchingOrchestrator");
        }

        public async Task WaitUntilComplete(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(2), false, "Completed");
        }

        public async Task WaitUntilStopped(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(5), true, "Completed", "Failed");
        }
    }
}
