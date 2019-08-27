using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    public class ProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private readonly ApprovalsConfig _config;

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _objectContext = _context.Get<ObjectContext>();
            _webDriver = context.GetWebDriver();
        }

        [When(@"the provider adds Ulns and approves the cohorts")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohorts()
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript($"window.open('{_config.AP_ProviderAppUrl}','_blank');");
        }

    }
}
