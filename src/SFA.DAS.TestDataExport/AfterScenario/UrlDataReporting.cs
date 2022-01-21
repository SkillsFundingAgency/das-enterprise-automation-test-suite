using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.IO;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;

namespace SFA.DAS.TestDataExport.AfterScenario
{
    [Binding]
    public class UrlDataReporting
    {
        private readonly ObjectContext _objectContext;
        private static List<string> _urls;

        public UrlDataReporting(ScenarioContext context) => _objectContext = context.Get<ObjectContext>();

        [BeforeTestRun(Order = 10)]
        public static void InitVariable() => _urls = new List<string>();

        [AfterScenario(Order = 98)]
        public void CollectUrlData()
        {
            string fileName = $"Urldata_{DateTime.Now:HH-mm-ss-fffff}.txt";

            var urldataset = _objectContext.GetAll().GetValue<List<string>>(UrlKeyHelper.AuthUrlKey);

            if (urldataset == null || urldataset?.Count == 0) return;

            List<string> distinctUrls = urldataset.ToHashSet().ToList();

            lock (_urls) { _urls.AddRange(distinctUrls); }

            TestRunReportHelper.WriteRecords(_objectContext, fileName, (x) => { File.WriteAllLines(x, distinctUrls); });
        }

        [AfterTestRun(Order = 10)]
        public static void ReportUrlCollection() => TestRunReportHelper.ReportAfterTestRun(_urls, "UrlCollection");

    }
}