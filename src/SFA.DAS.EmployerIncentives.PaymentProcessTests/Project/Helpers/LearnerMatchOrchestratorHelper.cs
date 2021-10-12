using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class LearnerMatchOrchestratorHelper
    {
        private readonly EILearnerMatchHelper _eiLearnerMatchHelper;
        private readonly StopWatchHelper _stopWatchHelper;
        private readonly IEIDataSnapper _dataSnapper;

        public LearnerMatchOrchestratorHelper(ScenarioContext context)
        {
            _eiLearnerMatchHelper = context.Get<EILearnerMatchHelper>();
            _stopWatchHelper = context.Get<StopWatchHelper>();
            _dataSnapper = context.Get<IEIDataSnapper>();
        }

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
