using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;
namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class VerifyTheYourApprenticeshipPageSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private WhatIsAnApprenticeshipPage whatIsAnApprenticeshipPage;
        #endregion

        public VerifyTheYourApprenticeshipPageSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I Focus on the link Getting Started link")]
        public void GivenIFocusOnTheLinkGettingStartedLink()
        {
            whatIsAnApprenticeshipPage = new WhatIsAnApprenticeshipPage(_context);
            whatIsAnApprenticeshipPage.FocusOnGettingStarted();
        }
    }
}