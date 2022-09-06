namespace SFA.DAS.ProvideFeedback.UITests.Project;

public abstract class BaseHooks
{
    protected readonly ObjectContext _objectContext;
    protected readonly ScenarioContext _context;
    protected readonly TryCatchExceptionHelper _tryCatch;

    public BaseHooks(ScenarioContext context)
    {
        _context = context;
        _objectContext = context.Get<ObjectContext>();
        _tryCatch = context.Get<TryCatchExceptionHelper>();
    }
}
