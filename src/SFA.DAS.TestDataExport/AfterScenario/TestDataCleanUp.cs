using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using System.Collections.Generic;
using SFA.DAS.TestDataCleanup.Project.Helpers.StepsHelper;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataCleanUp
    {
        private readonly ScenarioContext _context;

        public TestDataCleanUp(ScenarioContext context) => _context = context;

        [AfterScenario(Order = 100)]
        public void CleanUpTestData()
        {
            if (_context.TestError != null)
            {
                var dbNameToTearDown = _context.Get<ObjectContext>().GetDbNameToTearDown();

                if (dbNameToTearDown.Count > 0)
                {
                    var testDataCleanUpStepsHelper = new TestdataCleanupStepsHelper(_context);

                    if (dbNameToTearDown.TryGetValue(CleanUpDbName.EasUsersTestDataCleanUp, out HashSet<string> emails))
                    {
                        foreach (var email in emails) testDataCleanUpStepsHelper.CleanUpAllDbTestData(email);
                        
                        return;
                    }
                }
            }
        }
    }
}