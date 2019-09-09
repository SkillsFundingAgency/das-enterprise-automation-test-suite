using CsvHelper;
using OpenQA.Selenium.Remote;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{

    public class TestData
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    [Binding]
    public class ScreenshotTeardown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;


        public ScreenshotTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 10)]
        public void CollectTestData()
        {
            DateTime dateTime = DateTime.Now;

            string fileName = dateTime.ToString("HH-mm-ss")
                   + "_"
                   + _context.ScenarioInfo.Title
                   + ".csv";
            string directory = AppDomain.CurrentDomain.BaseDirectory
                + "../../"
                + "\\Project\\Screenshots\\"
                + dateTime.ToString("dd-MM-yyyy")
                + "\\";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string filePath = Path.Combine(directory, fileName);

            List<TestData> records = new List<TestData>();

            _objectContext.GetAll().ToList().ForEach(x => records.Add(new TestData { Key = x.Key, Value = x.Value.ToString() }));

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(records);
            }
            TestContext.AddTestAttachment(filePath, fileName);
        }

        [AfterScenario(Order = 11)]

        public void TakeScreenshotOnFailure()
        {
            var scenarioTitle = _context.ScenarioInfo.Title;
            var options = _context.Get<FrameworkConfig>();
            var browser = _objectContext.GetBrowser();
            if (_context.TestError != null)
            {
                switch (true)
                {
                    case bool _ when browser.IsCloudExecution():
                        RemoteWebDriver remoteWebDriver = (RemoteWebDriver)_context.GetWebDriver();
                        BrowserStackTeardown.MarkTestAsFailed(remoteWebDriver, options.BrowserStackSetting, scenarioTitle, _context.TestError.Message);
                        break;
                    default:
                        var webDriver = _context.GetWebDriver();
                        ScreenshotHelper.TakeScreenShot(webDriver, scenarioTitle, true);
                        break;
                }
            }
        }
    }
}
