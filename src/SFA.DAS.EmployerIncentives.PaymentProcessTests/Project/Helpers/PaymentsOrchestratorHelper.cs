using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class PaymentsOrchestratorHelper(ScenarioContext context)
    {
        private readonly EIPaymentsProcessHelper _eiPaymentsProcessHelper = context.Get<EIPaymentsProcessHelper>();
        private readonly StopWatchHelper _stopWatchHelper = context.Get<StopWatchHelper>();

        public async Task Run()
        {
            _stopWatchHelper.Start("RunPaymentsOrchestrator");
            await _eiPaymentsProcessHelper.StartPaymentProcessOrchestrator();
            await _eiPaymentsProcessHelper.WaitUntilWaitingForPaymentApproval();
            _stopWatchHelper.Stop("RunPaymentsOrchestrator");
        }

        public async Task Approve()
        {
            _stopWatchHelper.Start("RunApprovePaymentsOrchestrator");
            await _eiPaymentsProcessHelper.ApprovePayments();
            await _eiPaymentsProcessHelper.WaitUntilComplete();
            _stopWatchHelper.Stop("RunApprovePaymentsOrchestrator");
        }
    }
}
