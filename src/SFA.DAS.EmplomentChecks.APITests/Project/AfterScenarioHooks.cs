using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    [Binding]
    public  class AfterScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
        }

        [AfterScenario(Order =101)]
        public void DeleteTestExecutionData()
        {
            var scenarioName = _context.ScenarioInfo.Title.Substring(0,10);

            _employmentChecksSqlDbHelper.DeleteEmploymentCheck(scenarioName);
        }

    }
}
