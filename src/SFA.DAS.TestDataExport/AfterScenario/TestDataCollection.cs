using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataCollection
    {
        private readonly ObjectContext _objectContext;
        private readonly string _scenarioTitle;
        private readonly ScenarioContext _context;
        private static string _directory;
        private static List<string> _urls;
        private readonly TestDataCollectionHelper _testDataCollectionHelper;

        public TestDataCollection(ScenarioContext context)
        {
            _context = context;
            _scenarioTitle = context.ScenarioInfo.Title;
            _objectContext = context.Get<ObjectContext>();
            _directory = _objectContext.GetDirectory();
            _testDataCollectionHelper = new TestDataCollectionHelper(context);
        }

        [BeforeTestRun]
        public static void BeforeTestRun() => _urls = new List<string>();

        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (_urls.Count == 0) return;

            string fileName = $"UrlCollection_{DateTime.Now:HH-mm-ss-fffff}.txt";

            string filePath = Path.Combine(_directory, fileName);

            File.WriteAllLines(filePath, _urls);

            TestContext.AddTestAttachment(filePath, fileName);
        }

        [AfterStep(Order = 10)]
        public void AfterStep()
        {
            var stepInfo = _context.StepContext.StepInfo;

            _objectContext.SetAfterStepInformation($"-> {StepOutcome()}: {stepInfo.StepDefinitionType} {stepInfo.Text}");
        }

        [AfterScenario(Order = 99)]
        public void CollectTestData() => _testDataCollectionHelper.CollectTestData();
        
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

            _testDataCollectionHelper.WriteRecords(fileName, (x) =>
            {
                using (var writer = new StreamWriter(x))
                {
                    writer.WriteLine(strJson);
                    writer?.Flush();
                }
            });
        }

        private string StepOutcome() => _context.TestError != null ? "ERROR" : "Done";
    }
}