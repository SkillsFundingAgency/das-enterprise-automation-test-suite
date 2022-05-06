using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.AzureDurableFunctions;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers
{
    public class Helper
    {
        public EmploymentCheckOrchestrationHelper EmploymentCheckOrchestrationHelper => _context.Get<EmploymentCheckOrchestrationHelper>();
        private readonly ScenarioContext _context;

        public Helper(ScenarioContext context)
        {
            _context = context;
            context.Set(new ResponseEmploymentChecksOrchestratorHelper(context));
        }
    }
}
