using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NavigatingToHomePageSelectingApprenticeshipSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private HowMuchIsItGoingToCostPage howMuchIsItGoingToCostPage;
        private WhatIsAnApprenticeshipPage whatIsAnApprenticeshipPage;
        #endregion
        public NavigatingToHomePageSelectingApprenticeshipSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }
        [Given(@"I Focus on the link Are Apprenticeship Right For You")]
        public void GivenIFocusOnTheLinkAreApprenticeshipRightForYou()
        {
            whatIsAnApprenticeshipPage = new WhatIsAnApprenticeshipPage(_context);
            whatIsAnApprenticeshipPage.FocusOnAreApprenticeshipRightForYou();
        }
    }
}
