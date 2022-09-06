namespace SFA.DAS.ProvideFeedback.UITests.Project;

[Binding, Scope(Tag = "employerfeedback")]
public class EmployerFeedbackHooks : BaseHooks
{
    private EmployerFeedbackSqlHelper _employerFeedbackSqlHelper;
    
    public EmployerFeedbackHooks(ScenarioContext context) : base(context) { }

    [BeforeScenario(Order = 21)]
    public void SetUpHelpers()
    {
        _employerFeedbackSqlHelper = new EmployerFeedbackSqlHelper(_context.Get<DbConfig>());

        _context.Set(_employerFeedbackSqlHelper);
    }

    [AfterScenario(Order = 33)]
    public void ClearDownEmployerFeedbackResult() => _tryCatch.AfterScenarioException(() => _employerFeedbackSqlHelper.ClearDownEmployerFeedbackResult(_objectContext.GetUniqueSurveyCode()));
}
