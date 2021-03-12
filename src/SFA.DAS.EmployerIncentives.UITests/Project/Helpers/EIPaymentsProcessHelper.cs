using System;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EIPaymentsProcessHelper : EIFunctionAppHelper
    {
        public EIPaymentsProcessHelper(EIConfig config) : base(config)
        {
        }

        public async Task StartPaymentProcessOrchestrator(short collectionPeriodYear, byte collectionPeriodNumber)
        {
            await StartOrchestrator($"api/orchestrators/IncentivePaymentOrchestrator/{collectionPeriodYear}/{collectionPeriodNumber}");
        }

        public async Task WaitUntilWaitingForPaymentApproval(TimeSpan? timeout = null)
        {
            await WaitUntilCustomStatus("WaitingForPaymentApproval", timeout ?? TimeSpan.FromMinutes(1));
        }

        public async Task WaitUntilComplete(TimeSpan? timeout = null)
        {
            await WaitUntilStatus("Completed", timeout ?? TimeSpan.FromMinutes(1));
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
