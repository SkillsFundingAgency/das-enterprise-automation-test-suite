using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class VerifyWhatIsAnApprenticeshipSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private WhatIsAnApprenticeshipPage whatIsAnApprenticeshipPage;
        #endregion

        public VerifyWhatIsAnApprenticeshipSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I Focus on the link How Do They Work link")]
        public void GivenIFocusOnTheLinkHowDoTheyyWork()
        {
            whatIsAnApprenticeshipPage = new WhatIsAnApprenticeshipPage(_context);
            whatIsAnApprenticeshipPage.FocusOnHowDoTheyWork();
        }
    }
}
