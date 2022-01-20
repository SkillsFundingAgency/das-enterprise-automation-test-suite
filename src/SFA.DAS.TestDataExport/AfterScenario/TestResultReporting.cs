using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestResultReporting
    {
        private readonly ScenarioContext _context;
        private readonly string _scenarioTitle;
        private static List<string> _scenarioTitles;

        public TestResultReporting(ScenarioContext context)
        {
            _context = context;
            _scenarioTitle = context.ScenarioInfo.Title;
        }

        [BeforeTestRun(Order = 11)]
        public static void InitVariable() => _scenarioTitles = new List<string>();

        [AfterTestRun(Order = 10)]
        public static void ReportTestResult() => AfterTestRunReportHelper.ReportAfterTestRun(_scenarioTitles, "ScenarioTitle");

        [AfterScenario(Order = 99)]
        public void CaptureScenarioTitle()
        {
            if (_context.TestError != null) _scenarioTitles.Add(_scenarioTitle);
        }

    }
}