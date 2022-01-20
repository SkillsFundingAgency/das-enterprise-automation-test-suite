using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.Helper
{
    public class AfterTestRunReportHelper
    {
        internal static void ReportAfterTestRun(List<string> list, string fileNamePrefix)
        {
            if (list.Count == 0) return;

            List<string> distinctList = list.ToHashSet().ToList();

            string fileName = $"{fileNamePrefix}_{DateTime.Now:HH-mm-ss-fffff}.txt";

            string filePath = Path.Combine(Configurator.GetAgentTempDir(), "TestResults", fileName);

            TestContext.Progress.WriteLine($"filePath - {filePath}");

            TestContext.Progress.WriteLine($"{distinctList.Count} data are available in {fileName} from the test suite execution");

            for (int i = 0; i < distinctList.Count; i++) TestContext.Progress.WriteLine($"{i + 1} - {distinctList[i]}");

            try
            {
                File.WriteAllLines(filePath, distinctList);

                TestContext.AddTestAttachment(filePath, fileName);
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Exception occurred while writing data in AfterTestRun - {filePath}" + ex);
            }
        }
    }
}