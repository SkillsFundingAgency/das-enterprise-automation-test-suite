using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class LearnerMatchOrchestratorHelper(ScenarioContext context)
    {
        private readonly EILearnerMatchHelper _eiLearnerMatchHelper = context.Get<EILearnerMatchHelper>();
        private readonly StopWatchHelper _stopWatchHelper = context.Get<StopWatchHelper>();
        private readonly IEIDataSnapper _dataSnapper = context.Get<IEIDataSnapper>();

        public async Task Run(bool continueOnFailure = false)
        {
            _stopWatchHelper.Start("RunLearnerMatchOrchestrator");

            await _eiLearnerMatchHelper.StartLearnerMatchOrchestrator();
            if (continueOnFailure) await _eiLearnerMatchHelper.WaitUntilStopped();
            else await _eiLearnerMatchHelper.WaitUntilComplete();

            await _dataSnapper.TakeDataSnapshot();

            _stopWatchHelper.Stop("RunLearnerMatchOrchestrator");
        }
    }
}
