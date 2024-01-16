using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using System;

namespace SFA.DAS.UI.FrameworkHelpers;

public class CheckPageRetryHelper(IWebDriver webDriver, ScenarioInfo scenarioInfo, ObjectContext objectContext, TimeSpan[] timeSpans) : RetryHelper(webDriver, scenarioInfo, objectContext, timeSpans)
{
}
