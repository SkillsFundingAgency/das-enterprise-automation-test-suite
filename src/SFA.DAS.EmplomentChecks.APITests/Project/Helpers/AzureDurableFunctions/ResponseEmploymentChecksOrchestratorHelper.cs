using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers.AzureDurableFunctions
{
    public class ResponseEmploymentChecksOrchestratorHelper
    {
        private readonly EmploymentCheckOutputInterfaceHelper _checkOutputInterfaceHelper;

        public ResponseEmploymentChecksOrchestratorHelper(ScenarioContext context)
        {
            _checkOutputInterfaceHelper = context.Get<EmploymentCheckOutputInterfaceHelper>();
        }

        public async Task Run(bool continueOnFailure = false)
        {
            await _checkOutputInterfaceHelper.StartResponseEmploymentChecksOrchestrator();
            if (continueOnFailure) await _checkOutputInterfaceHelper.WaitUntilStopped();
            else await _checkOutputInterfaceHelper.WaitUntilComplete();
        }
    }
}
