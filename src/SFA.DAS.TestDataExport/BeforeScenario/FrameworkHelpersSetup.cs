namespace SFA.DAS.TestDataExport.BeforeScenario;

[Binding]
public class FrameworkHelpersSetup
{
    private readonly ScenarioContext _context;
    private readonly string[] _tags;

    public FrameworkHelpersSetup(ScenarioContext context) { _context = context; _tags = _context.ScenarioInfo.Tags; }

    [BeforeScenario(Order = 1)]
    public void SetUpFrameworkHelpers()
    {
        var objectContext = _context.Get<ObjectContext>();

        _context.Set(new TryCatchExceptionHelper(objectContext));

        objectContext.SetTestDataList(_tags);
    }

    [BeforeScenario(Order = 12)]
    public void DataSetUpHelpers() => _context.Set(new ApprenticePPIDataHelper(_tags, _context.Get<MailosaurUser>()));
}