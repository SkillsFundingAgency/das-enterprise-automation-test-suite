using System;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EIPaymentsProcessHelper : EIFunctionAppHelper
    {
        public EIPaymentsProcessHelper(EIPaymentProcessConfig config) : base(config)
        {
        }

        public async Task StartPaymentProcessOrchestrator()
        {
            await StartOrchestrator($"api/orchestrators/IncentivePaymentOrchestrator");
        }

        public async Task WaitUntilWaitingForPaymentApproval(TimeSpan? timeout = null)
        {
            await WaitUntilCustomStatus("WaitingForPaymentApproval", timeout ?? TimeSpan.FromMinutes(1));
        }

        public async Task WaitUntilComplete(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(1), false, "Completed");
        }

        public async Task ApprovePayments()
        {
            await CallHttpTrigger($"api/orchestrators/approvePayments/{OrchestratorStartResponse.Id}");
        }

        public async Task RejectPayments()
        {
            await CallHttpTrigger($"api/orchestrators/rejectPayments/{OrchestratorStartResponse.Id}");
        }
    }
}
