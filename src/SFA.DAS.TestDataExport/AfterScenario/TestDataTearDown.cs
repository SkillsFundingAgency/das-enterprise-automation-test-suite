using CsvHelper;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using SFA.DAS.ConfigurationBuilder;
using System.Globalization;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.AfterScenario
{
     [Binding]
    public class TestDataTearDown
    {
        private readonly ObjectContext _objectContext;
        private readonly string _scenarioTitle;
        private readonly ScenarioContext _context;
        private static List<string> _urls;

        public TestDataTearDown(ScenarioContext context)
        {
            _context = context;
            _scenarioTitle = context.ScenarioInfo.Title;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeTestRun]
        public static void BeforeTestRun() => _urls = new List<string>();

        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (_urls.Count == 0) return;

            string fileName = $"UrlCollection_{DateTime.Now:HH-mm-ss-fffff}.txt";

            string filePath = Path.Combine($"{Configurator.GetAgentTempDir()}\\TestResults", fileName);

            TestContext.Progress.WriteLine($"filePath - {filePath}");

            TestContext.Progress.WriteLine($"{_urls.Count} url data set are available for the test suite execution");

            try
            {
                File.WriteAllLines(filePath, _urls);

                TestContext.AddTestAttachment(filePath, fileName);
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Exception occurred while writing UrlCollection data in AfterTestRun - {filePath}" + ex);
            }
        }


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

            TestContext.Progress.WriteLine($"{testdataset.Count} test data set are available for {_scenarioTitle}");

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
            string fileName = $"URLDATA_{DateTime.Now:HH-mm-ss-fffff}.json";

            List<TestData> records = new List<TestData>();

            var urldataset = _objectContext.GetAll().GetValue<List<string>>(UrlKeyHelper.AuthUrlKey);

            if (urldataset == null || urldataset?.Count == 0) return;

            List<string> distinctUrls = urldataset.ToHashSet().ToList();

            TestContext.Progress.WriteLine($"{urldataset?.Count} url data set are available for {_scenarioTitle}");

            for (int i = 0; i < distinctUrls.Count; i++) 
            {
                var url = distinctUrls[i].ToString();

                _urls.Add(url);

                records.Add(new TestData { Key = i, Value = url });  
            };

            string strJson = JsonHelper.Serialize(records);

            WriteRecords(fileName, (x) =>
            {
                using (var writer = new StreamWriter(x))
                {
                    writer.WriteLine(strJson);
                    writer?.Flush();
                }
            });
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