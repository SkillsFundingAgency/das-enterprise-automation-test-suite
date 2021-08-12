using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class LevyTransfersStepsHelper 
    {
        private readonly IWebDriver _webDriver;
        private readonly ScenarioContext _context;

        public LevyTransfersStepsHelper(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
        }

        public bool DoesConfirmationBoxContainSubstring(By locator, String subString)
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            String actualSubstring = _webDriver.FindElement(locator).Text;
            bool result = actualSubstring.Contains(subString);
            return result;

        }
    }
}
