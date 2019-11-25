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
    public class CheckTheParentLinkSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private HelpShapeTheirCareerPage helpShapeTheirCareerPage ;
        #endregion
        public CheckTheParentLinkSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }


        [Given(@"I launch Help Shape Their Future Parents page")]
        public void GivenILaunchHelpShapeTheirFutureParentsPage()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.LaunchParentPage();
            TestContext.Progress.WriteLine("Navigating to Help Shape Their Future");
            
        }
        
        [Then(@"I verify the Header on Parets page")]
        public void ThenIVerifyTheHeaderOnParetsPage()
        {
            helpShapeTheirCareerPage  = new HelpShapeTheirCareerPage(_context);
            helpShapeTheirCareerPage.CheckHelpShapeTheirCareerHeader();
        }
    }
}
