using System;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.IO;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class UrlDataReporting
    {
        private readonly ScenarioContext _context;
        private static List<string> _urls;

        public UrlDataReporting(ScenarioContext context) => _context = context;

        [BeforeTestRun(Order = 10)]
        public static void InitVariable() => _urls = new List<string>();

        [AfterScenario(Order = 98)]
        public void CollectUrlData()
        {
            var objectContext = _context.Get<ObjectContext>();

            _context.Get<TryCatchExceptionHelper>().AfterScenarioException(() =>
            {
                string fileName = $"Urldata_{DateTime.Now:HH-mm-ss-fffff}.txt";

                var urldataset = objectContext.GetAll().GetValue<List<string>>(UrlKeyHelper.AuthUrlKey);

                if (urldataset == null || urldataset?.Count == 0) return;

                List<string> distinctUrls = urldataset.ToHashSet().ToList();

                lock (_urls) { _urls.AddRange(distinctUrls); }

                TestRunReportHelper.WriteRecords(objectContext, fileName, (x) => { File.WriteAllLines(x, distinctUrls); });
            });
        }

        [AfterTestRun(Order = 10)]
        public static void ReportUrlCollection() => TestRunReportHelper.ReportAfterTestRun(_urls, "UrlCollection");
    }
}