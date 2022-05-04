using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.AzureDurableFunctions;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers
{
    public class Helper
    {
        public EmploymentCheckOutputInterfaceHelper EmploymentCheckOutputInterfaceHelper => _context.Get<EmploymentCheckOutputInterfaceHelper>();
        private readonly ScenarioContext _context;

        public Helper(ScenarioContext context)
        {
            _context = context;
            context.Set(new ResponseEmploymentChecksOrchestratorHelper(context));
        }
    }
}
