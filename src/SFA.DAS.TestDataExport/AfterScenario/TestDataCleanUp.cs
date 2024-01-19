using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.TestDataCleanup.Project.Helpers.StepsHelper;

namespace SFA.DAS.TestDataExport.AfterScenario;

[Binding]
public class TestDataCleanUp(ScenarioContext context)
{
    [AfterScenario(Order = 98)]
    public void CleanUpTestData()
    {
        if (context.TestError == null && context.ScenarioInfo.Tags.Contains("regression"))
        {
            context.Get<TryCatchExceptionHelper>().AfterScenarioException(() =>
            {
                var dbNameToTearDown = context.Get<ObjectContext>().GetDbNameToTearDown();

                if (dbNameToTearDown.Count > 0)
                {
                    if (dbNameToTearDown.TryGetValue(CleanUpDbName.EasUsersTestDataCleanUp, out HashSet<string> emails))

                        new TestdataCleanupStepsHelper(context).CleanUpAllDbTestData(emails);
                }
            });
        }
    }
}