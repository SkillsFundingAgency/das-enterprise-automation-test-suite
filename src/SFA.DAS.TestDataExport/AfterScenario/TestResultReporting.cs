using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestResultReporting
    {
        private readonly ScenarioContext _context;
        private static List<string> _scenarioTitles;

        public TestResultReporting(ScenarioContext context) => _context = context;

        [BeforeTestRun(Order = 11)]
        public static void InitVariable() => _scenarioTitles = new List<string>();

        [AfterTestRun(Order = 10)]
        public static void ReportTestResult()
        {
            if (_scenarioTitles.Count == 0) return;

            var list = _scenarioTitles.Select(x => $"{x}|");

            var x = string.Join("|", list);

            x = string.Join("FullyQualifiedName~", x);

            AfterTestRunReportHelper.ReportAfterTestRun(new List<string> { x }, "ScenarioTitle");
        }

        [AfterScenario(Order = 99)]
        public void CaptureScenarioTitle()
        {
            if (_context.TestError != null) _scenarioTitles.Add(GetScenarioTitle());
        }

        private string GetScenarioTitle()
        {
            var x = RegexHelper.TrimAnySpace(_context.ScenarioInfo.Title);

            x = Regex.Replace(x, @"-", "_");

            return (x.Length <= 20) ? x : x.Substring(0, 20);
        }
    }
}