using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CheckHireAnApprinticeLinkSteps
    {
         #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private HireAnApprenticePage  hireAnApprenticePage;
        #endregion
        public CheckHireAnApprinticeLinkSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }
        [Given(@"I launch Hire An Apprentice page")]
        public void GivenILaunchHireAnApprenticePage()
        {
           fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.FocusOnEmployerHowDoTheyWorkMenu();
            TestContext.Progress.WriteLine("Navigating to Hire An Apprentice page");
            fireItUpHomePage.ClicKHireAnApprenticeLink();
        }
        
        [Then(@"I verify the title for Hire An Apprentice page")]
        public void ThenIVerifyTheTitleForHireAnApprenticePage()
        {
            hireAnApprenticePage = new HireAnApprenticePage(_context);
            hireAnApprenticePage.CheckHireAnApprenticeHeaderTitle();
        }
    }
}
