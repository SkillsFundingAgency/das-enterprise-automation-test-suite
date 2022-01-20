using CsvHelper;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using SFA.DAS.ConfigurationBuilder;
using System.Globalization;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataReporting
    {
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private static List<string> _urls;

        public TestDataReporting(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeTestRun(Order = 10)]
        public static void InitVariable() => _urls = new List<string>();

        [AfterTestRun(Order = 10)]
        public static void ReportUrlCollection() => AfterTestRunReportHelper.ReportAfterTestRun(_urls, "UrlCollection");

        [AfterStep(Order = 10)]
        public void AfterStep()
        {
            var stepInfo = _context.StepContext.StepInfo;

            _objectContext.SetAfterStepInformation($"-> {StepOutcome()}: {stepInfo.StepDefinitionType} {stepInfo.Text}");
        }

        [AfterScenario(Order = 99)]
        public void CollectTestData()
        {
            string fileName = $"TESTDATA_{DateTime.Now:HH-mm-ss-fffff}.txt";

            List<TestData> records = new List<TestData>();

            var testdataset = _objectContext.GetAll();

            testdataset.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testdataset[x.Key].ToString() }));

            WriteRecords(fileName, (x) =>
            {
                using (var writer = new StreamWriter(x))
                {
                    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    csv.WriteRecords(records);
                    writer?.Flush();
                };
            });
        }

        [AfterScenario(Order = 99)]
        public void CollectUrlData()
        {
            string fileName = $"Urldata_{DateTime.Now:HH-mm-ss-fffff}.txt";

            var urldataset = _objectContext.GetAll().GetValue<List<string>>(UrlKeyHelper.AuthUrlKey);

            if (urldataset == null || urldataset?.Count == 0) return;

            List<string> distinctUrls = urldataset.ToHashSet().ToList();

            _urls.AddRange(distinctUrls);

            WriteRecords(fileName, (x) => { File.WriteAllLines(x, distinctUrls); });
        }

        private void WriteRecords(string fileName, Action<string> action)
        {
            string filePath = Path.Combine(_objectContext.GetDirectory(), fileName);

            try
            {
                action(filePath);

                TestContext.AddTestAttachment(filePath, fileName);
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Exception occurred while writing data - {filePath}" + ex);

                _objectContext.SetAfterScenarioException(ex);
            }
        }

        private string StepOutcome() => _context.TestError != null ? "ERROR" : "Done";
    }
}