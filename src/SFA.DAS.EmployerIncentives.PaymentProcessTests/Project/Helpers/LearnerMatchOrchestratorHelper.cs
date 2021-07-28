using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class LearnerMatchOrchestratorHelper
    {
        private readonly EILearnerMatchHelper _eiLearnerMatchHelper;
        private readonly StopWatchHelper _stopWatchHelper;

        public LearnerMatchOrchestratorHelper(ScenarioContext context)
        {
            _eiLearnerMatchHelper = context.Get<EILearnerMatchHelper>();
            _stopWatchHelper = context.Get<StopWatchHelper>();
        }

        public async Task Run(bool continueOnFailure = false)
        {
            _stopWatchHelper.Start("RunLearnerMatchOrchestrator");
            
            await _eiLearnerMatchHelper.StartLearnerMatchOrchestrator();
            if (continueOnFailure) await _eiLearnerMatchHelper.WaitUntilStopped();
            else await _eiLearnerMatchHelper.WaitUntilComplete();

            _stopWatchHelper.Stop("RunLearnerMatchOrchestrator");
        }
    }
}
