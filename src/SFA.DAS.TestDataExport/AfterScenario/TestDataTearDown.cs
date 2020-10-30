using CsvHelper;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using SFA.DAS.ConfigurationBuilder;
using System.Globalization;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataTearDown
    {
        private readonly ObjectContext _objectContext;
        private readonly string _scenarioTitle;
        private readonly ScenarioContext _context;

        public TestDataTearDown(ScenarioContext context)
        {
            _context = context;
            _scenarioTitle = context.ScenarioInfo.Title;
            _objectContext = context.Get<ObjectContext>();
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
            _objectContext.ReplaceTestDataList();

            string fileName = $"TESTDATA_{DateTime.Now:HH-mm-ss-fffff}.txt";

            string directory = _objectContext.GetDirectory();

            string filePath = Path.Combine(directory, fileName);
            
            List<TestData> records = new List<TestData>();

            var testdataset = _objectContext.GetAll();

            TestContext.Progress.WriteLine($"{testdataset.Count} test data set are available for {_scenarioTitle}");

            testdataset.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testdataset[x.Key].ToString() }));
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    csv.WriteRecords(records);
                    writer?.Flush();
                }
                TestContext.AddTestAttachment(filePath, fileName);
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Exception occurred while collecting testdata - {filePath}" + ex);

                _objectContext.SetAfterScenarioException(ex);
            }
        }

        private string StepOutcome() => _context.TestError != null ? "ERROR" : "Done";

    }
}