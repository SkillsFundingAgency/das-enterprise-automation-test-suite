using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CheckTheLinkTheRightApprenticeshipSteps
    {

        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private TheRightApprenticeshipPage theApprenticeshipPage;
        #endregion
        public CheckTheLinkTheRightApprenticeshipSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
        }
        [Given(@"I launch The Right Apprenticeship page")]
        public void GivenILaunchTheRightApprenticeshipPage()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.LaunchEmployerMenu();
            TestContext.Progress.WriteLine("Navigating to The Right Apprenticeship page");
            fireItUpHomePage.ClickTheRightApprenticeshipLink();
        }
        
        [Then(@"I verify the title for The Right Apprenticeship  page")]
        public void ThenIVerifyTheTitleForTheRightApprenticeshipPage()
        {
            theApprenticeshipPage = new TheRightApprenticeshipPage(_context);
            theApprenticeshipPage.CheckTheRighApprenticeshipTitle();
        }
    }
}
