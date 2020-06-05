using CsvHelper;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataTearDown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public TestDataTearDown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 10)]
        public void CollectTestData()
        {
            _objectContext.SetAfterScenarioExceptions(new List<Exception>());
            
            string fileName = $"{DateTime.Now:HH-mm-ss}_{_context.ScenarioInfo.Title}.txt".RemoveSpace();

            string directory = _objectContext.GetDirectory();

            string filePath = Path.Combine(directory, fileName);
            
            List<TestData> records = new List<TestData>();

            var testDatas = _objectContext.GetAll();

            testDatas.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testDatas[x.Key].ToString() }));
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    using (var csv = new CsvWriter(writer))
                    {
                        csv.WriteRecords(records);
                        writer?.Flush();
                    }
                }
                TestContext.AddTestAttachment(filePath, fileName);
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Exception occurred while collecting testdata - {filePath}" + ex);

                _objectContext.SetAfterScenarioException(ex);
            }
        }
    }
}