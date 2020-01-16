using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class VerifyThatYouCanSearchForAnyApprenticeshipSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private WhatIsAnApprenticeshipPage whatIsAnApprenticeshipPage;
        #endregion

        public VerifyThatYouCanSearchForAnyApprenticeshipSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I Click on Find An Apprenticeship option in the Menu Bar Header")]
        public void GivenIClickOnFindAnApprenticeshipOptionInTheMenuBarHeader()
        {
            whatIsAnApprenticeshipPage = new WhatIsAnApprenticeshipPage(_context);
            whatIsAnApprenticeshipPage.ClickOnFindAnApprenticeshipMenuOption();
        }
    }
}
