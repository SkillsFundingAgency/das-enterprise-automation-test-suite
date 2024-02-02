using System.Threading.Tasks;

namespace SFA.DAS.TestDataExport.Helper;

public class TryCatchExceptionHelper(ObjectContext objectContext)
{
    public void AfterScenarioException(Action action)
    {
        try
        {
            action.Invoke();
        }
        catch (Exception ex)
        {
            SetAfterScenarioException(ex);
        }
    }

    public async void AfterScenarioException(Task task)
    {
        try
        {
            await task;
        }
        catch (Exception ex)
        {
            SetAfterScenarioException(ex);
        }
    }

    private void SetAfterScenarioException(Exception ex) => objectContext.SetAfterScenarioException(ex);
}
