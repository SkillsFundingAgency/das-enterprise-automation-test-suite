using System;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EILearnerMatchHelper : EIFunctionAppHelper
    {
        public EILearnerMatchHelper(EIPaymentProcessConfig config) : base(config)
        {
        }

        public async Task StartLearnerMatchOrchestrator()
        {
            await StartOrchestrator("api/orchestrators/LearnerMatchingOrchestrator");
        }

        public async Task WaitUntilComplete(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(1), false,"Completed");
        }

        public async Task WaitUntilStopped(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(3), true, "Completed", "Failed");
        }
    }
}
