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
            
            var list = _scenarioTitles.Select(x => $"FullyQualifiedName~{x}|").ToList().ToString("").TrimEnd('|');

            AfterTestRunReportHelper.ReportAfterTestRun(new List<string> { list }, "ScenarioTitle");
        }

        [AfterScenario(Order = 99)]
        public void CaptureScenarioTitle()
        {
            if (_context.TestError != null) 
            {
                int requiredLength = 20;

                var x = Regex.Replace(RegexHelper.TrimAnySpace(_context.ScenarioInfo.Title), @"-", "_");

                _scenarioTitles.Add((x.Length <= requiredLength) ? x : x.Substring(0, requiredLength));
            }
        }
    }
}