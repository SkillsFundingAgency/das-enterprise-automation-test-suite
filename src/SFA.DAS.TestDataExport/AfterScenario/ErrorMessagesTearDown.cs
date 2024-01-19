namespace SFA.DAS.TestDataExport.AfterScenario;

[Binding]
public class ErrorMessagesTearDown(ScenarioContext context)
{
    [AfterScenario(Order = 102)]
    public void ReportErrorMessages()
    {
        if (context.TestError != null) throw new Exception(string.Join(Environment.NewLine, context.Get<ObjectContext>().GetAfterScenarioExceptions().Select(x => x?.Message)));
    }
}