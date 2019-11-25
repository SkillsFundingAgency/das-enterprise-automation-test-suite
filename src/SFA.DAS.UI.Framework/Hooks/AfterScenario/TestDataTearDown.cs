using CsvHelper;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
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
            try
            {
                _objectContext.SetAfterScenarioExceptions(new List<Exception>());

                DateTime dateTime = DateTime.Now;

                string fileName = ($"{dateTime.ToString("HH-mm-ss")}_{_context.ScenarioInfo.Title}.txt").RemoveSpace();

                string directory = _objectContext.GetDirectory();

                string filePath = Path.Combine(directory, fileName);

                List<TestData> records = new List<TestData>();

                var testDatas = _objectContext.GetAll();

                testDatas.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testDatas[x.Key].ToString() }));

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
                _objectContext.SetAfterScenarioException(ex);
            }
        }
    }
}
