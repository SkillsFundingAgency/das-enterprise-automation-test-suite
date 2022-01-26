using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport.Helper
{
    public class AfterTestRunReportHelper
    {
        public static void ReportAfterTestRun(List<string> list, string directoryPath, string fileNamePrefix)
        {
            if (list.Count == 0) return;

            List<string> distinctList = list.ToHashSet().ToList();

            string fileName = $"{fileNamePrefix}_{DateTime.Now:HH-mm-ss-fffff}.txt";

            string parentdirectoryPath = Directory.GetParent(directoryPath).FullName;

            TestContext.Progress.WriteLine($"***************{distinctList.Count} data should be available in {parentdirectoryPath}\\{fileName}***************");

            for (int i = 0; i < distinctList.Count; i++) TestContext.Progress.WriteLine($"{i + 1} - {distinctList[i]}");

            try
            {
                TestAttachmentHelper.AddTestAttachment(parentdirectoryPath, fileName, (x) => File.WriteAllLines(x, distinctList));
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Exception occurred while writing data in AfterTestRun - {parentdirectoryPath}" + ex);
            }
        }
    }
}