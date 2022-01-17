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
    public class TestDataCollectionHelper
    {
        private readonly ObjectContext _objectContext;
        private readonly string _scenarioTitle;
        private static string _directory;

        public TestDataCollectionHelper(ScenarioContext context)
        {
            _scenarioTitle = context.ScenarioInfo.Title;
            _objectContext = context.Get<ObjectContext>();
            _directory = _objectContext.GetDirectory();
        }

        public void ReportTestData()
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

        public void WriteRecords(string fileName, Action<string> action)
        {
            string filePath = Path.Combine(_directory, fileName);

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
    }
}