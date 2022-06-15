namespace SFA.DAS.ProvideFeedback.UITests.Project;

[Binding]
public class Hooks
{
    private readonly ObjectContext _objectContext;
    private ProvideFeedbackSqlHelper _providerFeedbackSqlHelper;
    private readonly ScenarioContext _context;
    
    private readonly TryCatchExceptionHelper _tryCatch;
    
    public Hooks(ScenarioContext context)
    {
        _context = context;
        _objectContext = context.Get<ObjectContext>();
        _tryCatch = context.Get<TryCatchExceptionHelper>();
    }

    [BeforeScenario(Order = 21)]
    public void SetUpHelpers()
    {
        _providerFeedbackSqlHelper = new ProvideFeedbackSqlHelper(_context.Get<DbConfig>());

        _context.Set(_providerFeedbackSqlHelper);
    }

    [AfterScenario(Order = 33)]
    public void ClearDownEmployerFeedbackResult() => _tryCatch.AfterScenarioException(() => _providerFeedbackSqlHelper.ClearDownEmployerFeedbackResult(_objectContext.GetUniqueSurveyCode()));
}
