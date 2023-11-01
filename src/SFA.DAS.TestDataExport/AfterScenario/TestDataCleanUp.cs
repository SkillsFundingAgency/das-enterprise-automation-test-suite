using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.TestDataCleanup.Project.Helpers.StepsHelper;

namespace SFA.DAS.TestDataExport.AfterScenario;

[Binding]
public class TestDataCleanUp
{
    private readonly ScenarioContext _context;

    public TestDataCleanUp(ScenarioContext context) => _context = context;

    [AfterScenario(Order = 98)]
    public void CleanUpTestData()
    {
        if (_context.TestError == null && _context.ScenarioInfo.Tags.Contains("regression"))
        {
            _context.Get<TryCatchExceptionHelper>().AfterScenarioException(() =>
            {
                var dbNameToTearDown = _context.Get<ObjectContext>().GetDbNameToTearDown();

                if (dbNameToTearDown.Count > 0)
                {
                    if (dbNameToTearDown.TryGetValue(CleanUpDbName.EasUsersTestDataCleanUp, out HashSet<string> emails))

                        new TestdataCleanupStepsHelper(_context).CleanUpAllDbTestData(emails);
                }
            });
        }
    }
}