namespace SFA.DAS.TestDataExport.AfterScenario;

[Binding]
public class AfterStepReporting(ScenarioContext context)
{
    [AfterStep(Order = 10)]
    public void AfterStep()
    {
        string StepOutcome() => context.TestError != null ? "ERROR" : "Done";

        var stepInfo = context.StepContext.StepInfo;

        var objectContext = context.Get<ObjectContext>();

        var message = $"-> {StepOutcome()}: {stepInfo.StepDefinitionType} {stepInfo.Text}";

        objectContext.SetAfterStepInformation(message);

        objectContext.SetDebugInformation(message);
    }
}