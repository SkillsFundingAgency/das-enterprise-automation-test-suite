namespace SFA.DAS.TestDataExport.AfterScenario;

[Binding]
public class AfterStepReporting
{
    private readonly ScenarioContext _context;

    public AfterStepReporting(ScenarioContext context) => _context = context;

    [AfterStep(Order = 10)]
    public void AfterStep()
    {
        string StepOutcome() => _context.TestError != null ? "ERROR" : "Done";

        var stepInfo = _context.StepContext.StepInfo;

        var objectContext = _context.Get<ObjectContext>();

        var message = $"-> {StepOutcome()}: {stepInfo.StepDefinitionType} {stepInfo.Text}";

        objectContext.SetAfterStepInformation(message);

        objectContext.SetDebugInformation(message);
    }
}