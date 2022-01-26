using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class FailedTestReporting
    {
        private readonly ScenarioContext _context;
        private static List<string> _scenarioTitles;

        public FailedTestReporting(ScenarioContext context) => _context = context;

        [BeforeTestRun(Order = 11)]
        public static void InitVariable() => _scenarioTitles = new List<string>();

        [AfterScenario(Order = 97)]
        public void CaptureScenarioTitle()
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
        public static void ReportTestResult()
        {
            if (_scenarioTitles.Count == 0) return;
            
            var list = _scenarioTitles.Select(x => $"FullyQualifiedName~{x}|").ToList().ToString("").TrimEnd('|');

            AfterTestRunReportHelper.ReportAfterTestRun(new List<string> { list }, "ScenarioTitle");
        }
    }
}