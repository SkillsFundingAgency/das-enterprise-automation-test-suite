using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using System.Collections.Generic;
using SFA.DAS.TestDataCleanup.Project.Helpers.StepsHelper;
using System.Linq;
using SFA.DAS.TestDataCleanup;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataCleanUp
    {
        private readonly ScenarioContext _context;

        public TestDataCleanUp(ScenarioContext context) => _context = context;

        //Can test this once all the pipelines have access to all db's
        //[AfterScenario(Order = 98)]
        public void CleanUpTestData()
        {
            if (_context.TestError == null && _context.ScenarioInfo.Tags.Contains("regression"))
            {
                var dbNameToTearDown = _context.Get<ObjectContext>().GetDbNameToTearDown();

                if (dbNameToTearDown.Count > 0)
                {
                    if (dbNameToTearDown.TryGetValue(CleanUpDbName.EasUsersTestDataCleanUp, out HashSet<string> emails))
                    {
                        foreach (var email in emails) new TestdataCleanupStepsHelper(_context).CleanUpAllDbTestData(email);
                        
                        return;
                    }
                }
            }
        }
    }
}