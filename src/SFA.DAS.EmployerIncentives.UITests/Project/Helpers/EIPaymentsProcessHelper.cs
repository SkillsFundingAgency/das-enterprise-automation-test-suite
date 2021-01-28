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
            await StartOrchestrator($"orchestrators/IncentivePaymentOrchestrator/{collectionPeriodYear}/{collectionPeriodNumber}");
        }

        public async Task WaitUntilWaitingForPaymentApproval(TimeSpan? timeout)
        {
            await WaitUntilCustomStatus("Completed", timeout);
        }

        public async Task WaitUntilComplete(TimeSpan? timeout)
        {
            await WaitUntilStatus("Completed", timeout);
        }

        public async Task ApprovePayments()
        {
            await CallHttpTrigger($"orchestrators/approvePayments/{OrchestratorStartResponse.Id}");
        }

        public async Task RejectPayments()
        {
            await CallHttpTrigger($"orchestrators/rejectPayments/{OrchestratorStartResponse.Id}");
        }
    }
}
