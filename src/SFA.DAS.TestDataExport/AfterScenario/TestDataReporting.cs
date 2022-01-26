using CsvHelper;
using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.IO;
using SFA.DAS.ConfigurationBuilder;
using System.Globalization;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using SFA.DAS.TestDataCleanup;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class TestDataReporting
    {
        private readonly ScenarioContext _context;

        public TestDataReporting(ScenarioContext context) => _context = context;

        [AfterScenario(Order = 99)]
        public void CollectTestData()
        {
            var objectContext = _context.Get<ObjectContext>();

            _context.Get<TryCatchExceptionHelper>().AfterScenarioException(() => 
            {
                string fileName = $"TESTDATA_{DateTime.Now:HH-mm-ss-fffff}.txt";

                List<TestData> records = new List<TestData>();

                var testdataset = objectContext.GetAll();

                testdataset.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testdataset[x.Key].ToString() }));

                TestRunReportHelper.WriteRecords(objectContext, fileName, (x) =>
                {
                    using (var writer = new StreamWriter(x))
                    {
                        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                        csv.WriteRecords(records);

                        writer?.Flush();
                    };
                });
            });
        }
    }
}