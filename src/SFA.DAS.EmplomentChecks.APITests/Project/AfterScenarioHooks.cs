using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    [Binding]
    public  class AfterScenarioHooks(ScenarioContext context)
    {
        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();

        [AfterScenario(Order = 101)]
        public void DeleteTestExecutionData()
        {
            var scenarioName = context.ScenarioInfo.Title[..10];

            _employmentChecksSqlDbHelper.DeleteEmploymentCheck(scenarioName);
        }

    }
}
