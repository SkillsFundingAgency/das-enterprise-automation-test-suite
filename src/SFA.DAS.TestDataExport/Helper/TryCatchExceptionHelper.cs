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
            objectContext.SetAfterScenarioException(ex);
        }
    }
}
