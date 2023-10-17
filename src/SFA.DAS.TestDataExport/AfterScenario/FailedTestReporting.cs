namespace SFA.DAS.TestDataExport.AfterScenario;

[Binding]
public class FailedTestReporting
{
    private readonly ScenarioContext _context;
    private static List<string> _scenarioTitles;
    private static string _directoryPath;

    public FailedTestReporting(ScenarioContext context) { _context = context; _directoryPath = _context.Get<ObjectContext>().GetDirectory(); }

    [BeforeTestRun(Order = 11)]
    public static void InitVariable() => _scenarioTitles = new List<string>();

    [AfterScenario(Order = 97)]
    public void CaptureFailedScenarioTitle()
    {
        if (_context.TestError != null)
        {
            _context.Get<TryCatchExceptionHelper>().AfterScenarioException(() =>
            {
                int requiredLength = 20;

                var x = TestContext.CurrentContext.Test.Name;

                lock (_scenarioTitles) { _scenarioTitles.Add((x.Length <= requiredLength) ? x : x.Substring(0, requiredLength)); }
            });
        }
    }

    [AfterTestRun(Order = 11)]
    public static void ReportFailedScenariosTitle()
    {
        if (_scenarioTitles.Count == 0) return;

        var list = _scenarioTitles.Select(x => $"FullyQualifiedName~{x}|").ToList().ToString("").TrimEnd('|');

        list = $"({list})&FullyQualifiedName!~TestDataPreparation";

        AfterTestRunReportHelper.ReportAfterTestRun(new List<string> { list }, _directoryPath, "FailedScenarios");
    }
}