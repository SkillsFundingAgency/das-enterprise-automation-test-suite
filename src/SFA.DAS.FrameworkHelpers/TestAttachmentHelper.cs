using System;
using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace SFA.DAS.FrameworkHelpers
{
    public class TestAttachmentHelper
    {
        public void AddTestDataAttachment(string directoryPath, Dictionary<string, object> testrecords)
        {
            string fileName = $"TESTDATA_{DateTime.Now:HH-mm-ss-fffff}.txt";

            List<TestData> records = new List<TestData>();

            var testdataset = testrecords;

            testdataset.ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = testdataset[x.Key].ToString() }));

            AddTestAttachment(directoryPath, fileName, (x) =>
            {
                using (var writer = new StreamWriter(x))
                {
                    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                    csv.WriteRecords(records);

                    writer?.Flush();
                };
            });
        }

        public static void AddTestAttachment(string directoryPath, string fileName, Action<string> action)
        {
            string filePath = Path.Combine(directoryPath, fileName);

            action(filePath);

            TestContext.AddTestAttachment(filePath, fileName);

            TestContext.Progress.WriteLine($"***************{filePath} sucessfully created***************");
        }
    }
}