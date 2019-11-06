using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class CheckPreparingAndMonitoringSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private PreparingAndMonitoringPage preparingAndMonitoringPage;
        #endregion
        public CheckPreparingAndMonitoringSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I launch Preparing And Monitoring page")]
        public void GivenILaunchPreparingAndMonitoringPage()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.LaunchEmployerMenu();
            TestContext.Progress.WriteLine("Navigating to Preparing And Monitoring page");
            fireItUpHomePage.ClickPreparingAndMonitoringLink();
        }
        
        [Then(@"I verify the title for Preparing And Monitoring page")]
        public void ThenIVerifyTheTitleForPreparingAndMonitoringPage()
        {
            preparingAndMonitoringPage = new PreparingAndMonitoringPage(_context);
            preparingAndMonitoringPage.CheckPreparingAndMonitoringHeader();
        }
    }
}
