using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project
{
    [Binding]
    public class CampaignsHelperSetUp
    {
        private readonly ScenarioContext _context;
        public CampaignsHelperSetUp(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 22)]
        public void SetUpHelpers()
        {
            var WebDriver = _context.GetWebDriver();
            _context.Set(new FormCompletionCampaignsHelper(WebDriver));
            _context.Set(new PageInteractionCampaignsHelper(WebDriver));
        }

    }
}
