using System;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public class BrowserStackTearDownHelper
{
    private readonly ScenarioContext _context;
    private readonly ObjectContext _objectContext;
    private readonly BrowserStackReportingService _browserStackReport;

    public BrowserStackTearDownHelper(ScenarioContext context)
    {
        _context = context;
        _objectContext = context.Get<ObjectContext>();
        context.TryGetValue(out _browserStackReport);
    }

    public void MarkTestStatus()
    {
        if (IsCloudExecution()) MarkTestStatus(_context.TestError == null);
    }

    private void MarkTestStatus(bool testStatus)
    {
        try
        {
            _browserStackReport.MarkTestStatus(GetSessionId(), testStatus, _context.TestError?.Message);
        }
        catch (Exception ex)
        {
            _objectContext.SetBrowserstackResponse();
            _objectContext.SetAfterScenarioException(ex);
        }
    }


    public void UpdateTestName(string name) { if (IsCloudExecution()) _browserStackReport.UpdateTestName(GetSessionId(), name); }

    private string GetSessionId() => (_context.GetWebDriver() as WebDriver).SessionId.ToString();

    private bool IsCloudExecution() => _objectContext.GetBrowser().IsCloudExecution();
}

