using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers.AzureDurableFunctions
{
    public class ResponseEmploymentChecksOrchestratorHelper
    {
        private readonly EmploymentCheckOrchestrationHelper _checkOrchestrationHelper;

        public ResponseEmploymentChecksOrchestratorHelper(ScenarioContext context)
        {
            _checkOrchestrationHelper = context.Get<EmploymentCheckOrchestrationHelper>();
        }

        public async Task Run(bool continueOnFailure = false)
        {
            await _checkOrchestrationHelper.StartResponseEmploymentChecksOrchestrator();
            if (continueOnFailure) await _checkOrchestrationHelper.WaitUntilStopped();
            else await _checkOrchestrationHelper.WaitUntilComplete();
        }
    }
}
