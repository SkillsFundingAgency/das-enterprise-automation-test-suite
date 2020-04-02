using System;
using OpenQA.Selenium.Remote;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class BrowserStackTearDownHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly BrowserStackReportingService _browserStackReport;

        public BrowserStackTearDownHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _browserStackReport = context.Get<BrowserStackReportingService>();
        }

        public void InformBrowserStackOnFailure()
        {
            if (_context.TestError != null)
            {
                var browser = _objectContext.GetBrowser();
                var errorMessage = _context.TestError.Message;

                switch (true)
                {
                    case bool _ when browser.IsCloudExecution():
                        try
                        {
                            _browserStackReport.MarkTestAsFailed(GetSessionId(), errorMessage);
                        }
                        catch (Exception ex)
                        {
                            _objectContext.SetBrowserstackResponse();
                            _objectContext.SetAfterScenarioException(ex);
                        }
                        break;
                }
            }
        }

        public void UpdateTestName(string name)
        {
            _browserStackReport.UpdateTestName(GetSessionId(), name);
        }

        private string GetSessionId()
        {
            var webDriver = _context.GetWebDriver();
            RemoteWebDriver remoteWebDriver = (RemoteWebDriver)webDriver;
            return remoteWebDriver.SessionId.ToString();
        }
    }
}

