using CsvHelper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FrameworkHelpers
{
    public class ReportTestDataHelper
    {
        public void ReportTestData(string directoryPath, Dictionary<string, object> testrecords)
        {
            string fileName = $"TESTDATA_{DateTime.Now:HH-mm-ss-fffff}.txt";

            List<TestData> records = new List<TestData>();

            var testdataset = testrecords;

            testdataset.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testdataset[x.Key].ToString() }));

            TestAttachmentHelper.AddTestAttachment(directoryPath, fileName, (x) =>
            {
               using (var writer = new StreamWriter(x))
               {
                   using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                   csv.WriteRecords(records);

                   writer?.Flush();
               };
           });
        }
    }
}